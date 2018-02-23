using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldModel.Data;
using WorldModel.Enumerations;

namespace WorldModel.Infrastructure.Data
{
    public interface ICountry
    {
        string Code { get; set; }
        string Name { get; set; }
        Continent Continent { get; set; }
        string Region { get; set; }
        decimal SurfaceArea { get; set; }
        int IndependenceYear { get; set; }
        int Population { get; set; }
        decimal LifeExpectancy { get; set; }
        decimal GNP { get; set; }
        decimal GNPOld { get; set; }
        string LocalName { get; set; }
        string GovernmentForm { get; set; }
        string HeadOfState { get; set; }
        int Capital { get; set; }
        string Code2 { get; set; }
        List<City> Cities { get; set; }
        List<CountryLanguage> Languages { get; set; }
    }
}
