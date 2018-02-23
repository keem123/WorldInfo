using SimpleDataClient.Client.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDataClient.Client.Structure.Data
{
    public interface ICommandHandler
    {
        int LastInsertedID { get; set; }
        int CommandID { get; set; }
        CommandResult Result { get; set; }
        string ResponseMessage { get; set; }
    }
}
