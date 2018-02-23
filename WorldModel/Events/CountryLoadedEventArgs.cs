using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldModel.Data;
using WorldModel.Infrastructure.Data;

namespace WorldModel.Events
{
    public class CountryLoadedEventArgs : EventArgs
    {
       public List<Country> List { get; set; }
    }
}
