using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Clipboard;
using Xamarin.Forms;

namespace ExemploClipboard
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void Copiar(System.Object sender, System.EventArgs e)
        {
            CrossClipboard.Current.SetText(entryTexto.Text);
        }

        async void Colar(System.Object sender, System.EventArgs e)
        {
            lblColar.Text = await CrossClipboard.Current.GetTextAsync();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if(!string.IsNullOrEmpty(await CrossClipboard.Current.GetTextAsync()))
            {
                string clipboard = await CrossClipboard.Current.GetTextAsync();

               var resposta = await Application.Current
             .MainPage.DisplayAlert("Atenção", $"Deseja copiar o valor {clipboard} ?", "Sim", "Não");

                if(resposta)
                    lblColar.Text = await CrossClipboard.Current.GetTextAsync();
            }
        }

        
    }
}
