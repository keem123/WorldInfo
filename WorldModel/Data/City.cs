using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldModel.Infrastructure.Data;

namespace WorldModel.Data
{
    public class City : NotifyBase, ICity
    {
        private int _id;
        private string _name;
        private string _countryCode;
        private string _district;
        private int _population;
        
        public int ID { get { return _id; } set{ _id = value; TriggerProperty("ID"); } }
        public string Name { get { return _name; } set { _name = value; TriggerProperty("Name"); } }
        public string CountryCode { get { return _countryCode; } set { _countryCode = value; TriggerProperty("CountryCode"); } }
        public string District { get { return _district; } set { _district = value; TriggerProperty("District"); } }
        public int Population { get { return _population; } set { _population = value; TriggerProperty("Population"); } }
    }
}
