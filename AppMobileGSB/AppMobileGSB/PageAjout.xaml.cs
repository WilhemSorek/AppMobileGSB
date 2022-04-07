using AppMobileGSB.Droid.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileGSB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAjout : ContentPage
    {
        public PageAjout()
        {
            InitializeComponent();
        }

        private async void btnAjout_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(Entrystock.Text, out int result))
            {
             await EchantillonServices.addEchantillon(Entrycode.Text, Entrylibelle.Text, int.Parse(Entrystock.Text));
                        textviewMessage.IsVisible = true;
            
                        textviewMessage.Text = "Echantillon ajouté";
            }
            else
            {
                textviewMessage.IsVisible = true;
                textviewMessage.Text = "Ajout impossible, La quantité doit être un chiffre";
            }
           
        }

        private async void btnQuitter_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}