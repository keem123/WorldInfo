using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldModel.Enumerations;
using WorldModel.Infrastructure.Data;

namespace WorldModel.Data
{
    /// <summary>
    /// Country
    /// </summary>
    public class Country : NotifyBase , ICountry
    {
        private string _code;
        private string _name;
        private Continent _continent;
        private string _region;
        private decimal _surfaceArea;
        private int _indipendenceYear;
        private int _population;
        private decimal _lifeExpenctancy;
        private decimal _gnp;
        private decimal _gnpOld;
        private string _localName;
        private string _governmentForm;
        private string _headOfState;
        private int _capital;
        private string _code2;
        private List<City> _cities;
        private List<CountryLanguage> _language;
        
        public string Code { get { return _code; } set { _code = value; TriggerProperty("Code"); } }
        public string Name { get { return _name; } set { _name = value; TriggerProperty("Name"); } }
        public Continent Continent { get { return _continent; } set { _continent = value; TriggerProperty("Continent"); } }
        public string Region { get { return _region; } set { _region = value; TriggerProperty("Region"); } }
        public decimal SurfaceArea { get { return _surfaceArea; } set { _surfaceArea = value; TriggerProperty("SurfaceArea"); } }
        public int IndependenceYear { get { return _indipendenceYear; } set { _indipendenceYear = value; TriggerProperty("IndependenceYear"); } }
        public int Population { get { return _population; } set { _population = value; TriggerProperty("Population"); } }
        public decimal LifeExpectancy { get { return _lifeExpenctancy; } set { _lifeExpenctancy = value; TriggerProperty("LifeExpectancy"); } }
        public decimal GNP { get { return _gnp; } set { _gnp = value; TriggerProperty("GNP"); } }
        public decimal GNPOld { get { return _gnpOld; } set { _gnpOld = value; TriggerProperty("GNPOld"); } }
        public string LocalName { get { return _localName; } set { _localName = value; TriggerProperty("LocalName"); } }
        public string GovernmentForm { get { return _governmentForm; } set { _governmentForm = value; TriggerProperty("GovernmentForm"); } }
        public string HeadOfState { get { return _headOfState; } set { _headOfState = value; TriggerProperty("HeadOfState"); } }
        public int Capital { get { return _capital; } set { _capital = value; TriggerProperty("Capital"); } }
        public string Code2 { get { return _code2; } set { _code2 = value; TriggerProperty("Code2"); } }

        public List<City> Cities { get { return _cities; } set { _cities = value; TriggerProperty("Cities"); } }
        public List<CountryLanguage> Languages { get { return _language; } set { _language = value; TriggerProperty("Languages"); } }
    }
}
