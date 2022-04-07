using AppMobileGSB.Droid.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileGSB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageList : ContentPage
    {
        public PageList()
        {
            InitializeComponent();
            List<Echantillon> listview = EchantillonServices.QuerySelectListEchantillons();
            lsview.ItemsSource = listview;
        }

        private async void btnQuitter_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
            
        }
    }
}