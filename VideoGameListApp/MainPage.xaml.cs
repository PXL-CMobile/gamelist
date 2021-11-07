using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VideoGameListApp
{
    public partial class MainPage : ContentPage
    {
        private ContentPage _pageWithTheList = new GameListPage();
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
