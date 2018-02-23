using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldModel.Data;
using WorldModel.Events;
using WorldModel.Infrastructure.Data;
using SimpleDataClient.Client.Repository;

namespace WorldModel.Infrastructure.Repository
{
    public interface ICountryRepository<C,L>  : IRegisterServer<DataClient>
        where C : City
        where L : CountryLanguage
    {
        void LoadCountries();
        Task<List<C>> LoadCities(string Code);
        Task<List<L>> LoadLanguages(string Code);

        event EventHandler<CountryLoadedEventArgs> OnCountryLoaded;
    }
}
