﻿using App1.Models;
using App1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WykladowcyPage : ContentPage
    {
        private WykladowcyViewModel viewModel;

        public WykladowcyPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new WykladowcyViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Wykladowca;
            if (item == null)
                return;

            viewModel.Szczegoly = new WykladowcaSzczegoly
            {
                NazwaPelna = item.NazwaPelna,
                Specjalizacja = "Grafika",
                Zajecia = new Zajecia[]
                {
                    new Zajecia{Nazwa = "Monitory" },
                    new Zajecia{Nazwa = "Telewizory"}
                }
            };
            await Navigation.PushAsync(new WykladowcaSzczegolyPage(viewModel));

            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}