using SimpleDataClient.Client.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldModel
{
    public interface IRegisterServer<Client>
        where Client : DataClient
    {
        void RegisterServer(Client obj);
    }
}
