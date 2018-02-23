using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataClient.Client.Structure.Data
{
    public interface IServerConfiguration
    {
        string Server { get; set; }
        string Database { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        int Port { get; set; }
    }
}
