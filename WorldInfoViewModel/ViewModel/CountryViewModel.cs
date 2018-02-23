using SimpleDataClient.Client.Data;
using SimpleDataClient.Client.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorldInfoViewModel.Commands;
using WorldModel;
using WorldModel.Data;
using WorldModel.Events;
using WorldModel.Repository;

namespace WorldInfoViewModel
{
    public class CountryViewModel : NotifyBase
    {
        ICommand LoadCommand { get; set; }

        private Country _currentCountry;
        private ObservableCollection<Country> _countryList;

        public Country CurrentCountry { get { return _currentCountry; } set { _currentCountry = value; TriggerProperty("CurrentCountry"); } }
        public ObservableCollection<Country> CountryList { get { return _countryList; } set { _countryList = value; TriggerProperty("CountryList"); } }
        CountryRepository ctrl = new CountryRepository();

        public CountryViewModel()
        {
            CurrentCountry = new Country();
            CountryList = new ObservableCollection<Country>();
            DataClient dc = new DataClient();
            ServerConfiguration comf = new ServerConfiguration() { Server = "localhost", Database = "World", Username = "root", Password = "admin", Port = 3306 };
            dc.Initialize(comf);
            ctrl.OnCountryLoaded += Ctrl_OnCountryLoaded;
            ctrl.RegisterServer(dc);
            ctrl.LoadCountries();
            LoadCommand = new RelayCommand(LoadCountry);
        }



        public void LoadCountry(object parameter)
        {

        }

        private void Ctrl_OnCountryLoaded(object sender, CountryLoadedEventArgs e)
        {
           
            CountryList = new ObservableCollection<Country>(e.List);
        }

    }
}
