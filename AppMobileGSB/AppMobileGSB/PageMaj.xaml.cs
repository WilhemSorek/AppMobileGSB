using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobileGSB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageMaj : ContentPage
    {
        public PageMaj()
        {
            InitializeComponent();
        }

        private async void btnSuppr_Clicked(object sender, EventArgs e)
        {
           if(int.TryParse(EntryQte.Text, out int result))
            {
                if(EchantillonServices.VerifQte(Entrycode.Text, result))
                {
                await EchantillonServices.DelEchantillon(Entrycode.Text, result);
                LblMessage.Text = "Quantité supprimée";
                }
                else
                {
                    LblMessage.Text = "Quantité stockée insuffisante";
                }
            }
           else
            {
                LblMessage.Text = "La quantité doit être un nombre";
            }
        }

        private async void btnMaj_Clicked(object sender, EventArgs e)
        {
            if(int.TryParse(EntryQte.Text, out int result))
            {
                 await EchantillonServices.majEchantillon(Entrycode.Text, result);
                            LblMessage.Text = "quantité modifiée";
            }
            else
            {
                LblMessage.Text = "La quantité doit être un nombre";
            }
           
            
        }

        private async void btnQuitter_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();   
        }
    }
}