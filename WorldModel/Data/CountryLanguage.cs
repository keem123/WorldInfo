using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldModel.Infrastructure.Data;

namespace WorldModel.Data
{
    public class CountryLanguage : NotifyBase, ICountryLanguage
    {
        private string _code;
        private string _language;
        private string _isOfficial;
        private decimal _percentage;
        
        public string Code { get { return _code; } set { _code = value; TriggerProperty("Code"); } }
        public string Language { get { return _language; } set { _language = value; TriggerProperty("Language"); } }
        public string IsOfficial { get { return _isOfficial; } set { _isOfficial = value; TriggerProperty("IsOfficial"); } }
        public decimal Percentage { get { return _percentage; } set { _percentage = value; TriggerProperty("Percentage"); } }
    }
}
