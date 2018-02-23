using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldModel.Infrastructure.Data
{
    public interface ICountryLanguage
    {
        string Code { get; set; }
        string Language { get; set; }
        string IsOfficial { get; set; }
        decimal Percentage { get; set; }
    }
}
