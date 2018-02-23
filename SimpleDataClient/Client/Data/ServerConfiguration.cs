
using SimpleDataClient.Client.Structure;
using SimpleDataClient.Client.Structure.Data;
using SimpleDataClient.Structure.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataClient.Client.Data
{
    [Serializable]
    public class ServerConfiguration : IServerConfiguration, IConfigRepository
    {
        private ServerConfiguration _self;

        private string _server;
        private string _database;
        private string _username;
        private string _password;
        private int _port;

        [Category("Server Credentials")]
        public string Database { get { return _database; } set { _database = value; } }
        [Category("Server Credentials"), PasswordPropertyText(true)]
        public string Password { get { return _password; } set { _password = value; } }
        [Category("Server Credentials")]
        public int Port { get { return _port; } set { _port = value; } }
        [Category("Server Credentials")]
        public string Server { get { return _server; } set { _server = value; } }
        [Category("Server Credentials")]
        public string Username { get { return _username; } set { _username = value; } }

        public ServerConfiguration()
        {
            Load();
        }
        public void Save()
        {
            try
            {

                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("server.config", FileMode.Create, FileAccess.ReadWrite);
                formatter.Serialize(stream, this);
                stream.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IServerConfiguration Load()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("server.config", FileMode.OpenOrCreate, FileAccess.Read);
            try
            {
                if (File.Exists("server.config"))
                {
                    var file = File.ReadLines("server.config");
                    if(file.ToList().Count != 0)
                    {
                        _self = (ServerConfiguration)formatter.Deserialize(stream);
                        this.Server = _self.Server;
                        this.Database = _self.Database;
                        this.Username = _self.Username;
                        this.Password = _self.Password;
                        this.Port = _self.Port;
                        stream.Close();
                       
                    }
                    return _self;
                }
                else
                {
                    return null;
                }

               
            }
            catch
            {
                stream.Close();
                return null;
            }
        }
    }
}
