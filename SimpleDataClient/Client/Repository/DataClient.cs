using SimpleDataClient.Client.Structure.Data;
using SimpleDataClient.Structure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;
using SimpleDataClient.Client.Data;
using SimpleDataClient.Client.Categories;

namespace SimpleDataClient.Client.Repository
{
    public class DataClient : IDataClientRepository<IServerConfiguration, DbCommand>
    {
        private IDbConnection _connection { get; set; }

        public Command ExecuteCommand(DbCommand cmd)
        {
            Command temp = new Command();
            try
            {
                _connection.Open();
                cmd.Connection = (DbConnection)_connection;
                cmd.ExecuteNonQuery();
                temp.ResponseMessage = "Success";
                temp.LastInsertedID = (int)((MySqlCommand)cmd).LastInsertedId;
                temp.Result = CommandResult.Success;
            }
            catch(Exception ex)
            {
                temp.Result = CommandResult.Error;
                temp.ResponseMessage = ex.Message;
            }
            finally
            {
                _connection.Close();
            }
            return temp;
        }

        public List<ICommandHandler> ExecuteCommands(Dictionary<int, DbCommand> commandlist)
        {
            List<ICommandHandler> temp = new List<ICommandHandler>();
            _connection.Open();
           var transaction = _connection.BeginTransaction();
            commandlist.Values.ToList().ForEach(x => 
            {
                try
                {
                    x.Connection = (DbConnection)_connection;
                    x.ExecuteNonQuery();
                    temp.Add(new Command
                    {
                        CommandID = commandlist.First(z => z.Value.CommandText == x.CommandText).Key,
                        LastInsertedID = (int)((MySqlCommand)x).LastInsertedId,
                        ResponseMessage = "Success",
                        Result = CommandResult.Success
                    });
                }
                catch(Exception ex)
                {
                    temp.Add(new Command
                    {
                        CommandID = commandlist.First(z => z.Value.CommandText == x.CommandText).Key,
                        LastInsertedID = (int)((MySqlCommand)x).LastInsertedId,
                        ResponseMessage = ex.Message,
                        Result = CommandResult.Success
                    });
                }
                finally
                {

                }
            });

            try
            {
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
            _connection.Close();
            return temp;

        }

        public void Initialize(IServerConfiguration data)
        {
            var ConnectionString = new MySqlConnectionStringBuilder()
            {
                Server = data.Server,
                Database = data.Database,
                UserID = data.Username,
                Password = data.Password,
                Port = (uint)data.Port
            };
            _connection = new MySqlConnection(ConnectionString.ConnectionString);
        }

        public async Task<DataTable> LoadData(DbCommand cmd)
        {
            await Task.Delay(100);
            cmd.Connection = (DbConnection)_connection;
            IDbDataAdapter adap = new MySqlDataAdapter((MySqlCommand)cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            return ds.Tables[0];
        }

        public async Task<DataTable> LoadData(string query)
        {
            await Task.Delay(100);
            IDbCommand cmd = new MySqlCommand(query);
            cmd.Connection = _connection;
            IDbDataAdapter adap = new MySqlDataAdapter((MySqlCommand)cmd);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            return ds.Tables[0];
        }
    }
}
