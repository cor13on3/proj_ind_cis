using App1.Models;
using App1.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class WykladowcyViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; set; }

        private IDataStore<Wykladowca> _dataStore;
        public ObservableCollection<Wykladowca> Items { get; set; }
        public WykladowcaSzczegoly Szczegoly { get; set; }

        public WykladowcyViewModel()
        {
            Title = "Wykładowcy";
            Items = new ObservableCollection<Wykladowca>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            _dataStore = GetDataStore<Wykladowca>();

            var items = new Wykladowca[]
            {
                new Wykladowca{ Id = "1", Imie = "Andrjej", Nazwisko = "Buda", NazwaPelna = "Andrjej Buda"},
                new Wykladowca{ Id = "2", Imie = "Rafael", Nazwisko = "Triskov", NazwaPelna = "Rafael Triskov"},
            };
            foreach (var item in items)
                _dataStore.AddItemAsync(item);
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await _dataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}