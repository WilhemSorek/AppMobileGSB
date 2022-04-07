using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Xamarin.Forms;
using System.IO;
using SQLite;
using AppMobileGSB.Droid.Model;
using Xamarin.Essentials;

namespace AppMobileGSB
{
    public partial class MainPage : ContentPage
    {
        public  MainPage()
        {
            InitializeComponent();
            EchantillonServices.Init();
        }
       
      

        private async void btnAjout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageAjout());
        }

        private async void btnList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageList());
        }

        private async void btnMaj_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageMaj());
        }
    }
}