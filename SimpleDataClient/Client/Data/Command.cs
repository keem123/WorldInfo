using SimpleDataClient.Client.Structure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleDataClient.Client.Categories;

namespace SimpleDataClient.Client.Data
{
    public class Command : ICommandHandler
    {
        public int CommandID
        {
            get;
            set;
        }

        public int LastInsertedID
        {
            get;
            set;
        }

        public string ResponseMessage
        {
            get;
            set;
        }

        public CommandResult Result
        {
            get;
            set;
        }
    }
}
