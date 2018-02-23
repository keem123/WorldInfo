using SimpleDataClient.Client.Structure;
using SimpleDataClient.Client.Structure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataClient.Structure.Repository
{
    public interface IConfigRepository
    {
        void Save();
        IServerConfiguration Load();
    }
}
