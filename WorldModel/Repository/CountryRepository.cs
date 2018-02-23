using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldModel.Events;
using WorldModel.Infrastructure.Repository;
using MySql.Data.MySqlClient;
using System.Data;
using WorldModel.Infrastructure.Data;
using WorldModel.Data;
using SimpleDataClient.Client.Repository;
using System.Text.RegularExpressions;
using WorldModel.Enumerations;

namespace WorldModel.Repository
{
    public class CountryRepository : ICountryRepository<City,CountryLanguage>
    {
        public event EventHandler<CountryLoadedEventArgs> OnCountryLoaded;
        private Object _locker;
        private DataClient _client;
        

        public async void LoadCountries()
        {
            List<Country> tempCountryList = new List<Country>();

            string query = @"SELECT 
                            `Code`,
                            `Name`,
                            `Continent`,
                            ifNull(`Region`, '') as `Region`,
                            ifnull(`SurfaceArea`, '') as SurfaceArea,
                            IFNULL(`IndepYear`, 0) AS IndepYear,
                            ifnull(`Population`,'') as Population,
                            IFNULL(`LifeExpectancy`, 0) AS LifeExpectancy,
                            IFNULL(`GNP`, 0) AS GNP,
                            IFNULL(`GNPOld`, 0) AS GNPOld,
                            ifnull( `LocalName`,'') as LocalName,
                            ifnull(`GovernmentForm`,'') as `GovernmentForm`,
                            ifnull(`HeadOfState`,'No head of state') as `HeadOfState`,
                            IFNULL(`Capital`, 0) AS Capital,
                            ifnull( `Code2`,'') as Code2
                        FROM
                            `country`;";

            await Task.Factory.StartNew(new Action(async() => 
            {
                var data = await _client.LoadData(query);
                foreach (DataRow dr in data.Rows)
                {
                    var code = (string)dr["Code"];
                    var continent = (string)dr["Continent"];

                    try
                    {
                        tempCountryList.Add(new Country()
                        {
                            Code = code,
                            Name = (string)dr["Name"],
                            Continent = (Continent)Enum.Parse(typeof(Continent), continent.Replace(" ", "")),
                            Region = (string)dr["Region"],
                            SurfaceArea = Convert.ToDecimal(dr["SurfaceArea"].ToString()),
                            IndependenceYear = Convert.ToInt32(dr["IndepYear"].ToString()),
                            Population = Convert.ToInt32(dr["Population"].ToString()),
                            LifeExpectancy = Convert.ToDecimal(dr["LifeExpectancy"].ToString()),
                            GNP = Convert.ToDecimal(dr["GNP"]),
                            GNPOld = Convert.ToDecimal(dr["GNPOld"].ToString()),
                            LocalName = (string)dr["LocalName"],
                            GovernmentForm = (string)dr["GovernmentForm"],
                            Capital = Convert.ToInt32(dr["Capital"].ToString()),
                            Code2 = (string)dr["Code2"],
                            HeadOfState = (string)dr["HeadOfState"],
                            Languages = await LoadLanguages(code),
                            Cities = await LoadCities(code)
                        });
                    }
                    catch
                    {

                    }

                }
                OnCountryLoaded.DynamicInvoke(this, new CountryLoadedEventArgs()
                {
                    List = tempCountryList
                });

            }));

            
        }

    
        public void RegisterServer(DataClient obj)
        {
            this._client = obj;
        }

        public async Task<List<City>> LoadCities(string Code)
        {
            List<City> TempList = new List<City>();

            MySqlCommand cmd = new MySqlCommand(@"SELECT `ID`,
                                `Name`,
                                `CountryCode`,
                                `District`,
                                `Population`
                            FROM `city`
                            where `CountryCode` = @code");
            cmd.Parameters.AddWithValue(@"code", Code);
            var data = await _client.LoadData(cmd);
            foreach(DataRow dr in data.Rows)
            {
                TempList.Add(new City
                {
                    CountryCode = (string)dr["CountryCode"],
                    District = (string)dr["District"],
                    Name = (string)dr["Name"],
                    Population = Convert.ToInt32(dr["Population"].ToString()),
                    ID = Convert.ToInt32(dr["ID"].ToString())
                         
                });
            }

            return TempList;
        }

        public async Task<List<CountryLanguage>> LoadLanguages(string Code)
        {
            List<CountryLanguage> TempList = new List<CountryLanguage>();


            MySqlCommand cmd = new MySqlCommand(@"SELECT `CountryCode`,
                                    `Language`,
                                    `IsOfficial`,
                                    `Percentage`
                            FROM `countrylanguage`
                            where `CountryCode` = @code");

            cmd.Parameters.AddWithValue(@"code", Code);
            var data = await _client.LoadData(cmd);
            foreach (DataRow dr in data.Rows)
            {
                TempList.Add(new CountryLanguage
                {
                    Code = (string)dr["CountryCode"],
                    Language = (string)dr["Language"],
                    IsOfficial = (string)dr["IsOfficial"],
                    Percentage = Convert.ToDecimal(dr["Percentage"].ToString())
                });
            }
            
            return TempList;
        }
    }
}
