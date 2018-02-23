using SimpleDataClient.Client.Data;
using SimpleDataClient.Client.Structure;
using SimpleDataClient.Client.Structure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataClient.Structure.Repository
{
    public interface IDataClientRepository<config,command> 
        where config : IServerConfiguration
        where command : DbCommand
    {
        Task<DataTable> LoadData(string query);
        Task<DataTable> LoadData(command cmd);
        void Initialize(config data);
        Command ExecuteCommand(command cmd);
        List<ICommandHandler> ExecuteCommands(Dictionary<int, command> commandlist);

    }
}
