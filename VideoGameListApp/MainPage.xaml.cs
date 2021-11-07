using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using VideoGameListApp.Views;

namespace VideoGameListApp
{
    public partial class MainPage : ContentPage
    {
        private ContentPage _pageWithTheList = new GameListView();
        public MainPage()
        {
            InitializeComponent();
        }

        private async void GoToGamePage(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(_pageWithTheList);
        }
    }
}
