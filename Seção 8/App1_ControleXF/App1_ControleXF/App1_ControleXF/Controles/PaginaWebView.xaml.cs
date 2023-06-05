using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_ControleXF.Controles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaWebView : ContentPage
    {
        public PaginaWebView()
        {
            InitializeComponent();
        }

        private void Pesquisar_Clicado(object sender, EventArgs e)
        {
            navegador.Source = enderecoSite.Text;
        }

        private void Proximo_Clicado(object sender, EventArgs e)
        {
            if (navegador.CanGoForward) 
            {
                navegador.GoForward();
            }
        }

        private void Voltar_Clicado(object sender, EventArgs e)
        {
            if (navegador.CanGoBack)
            {
                navegador.GoBack();
            }
        }

        private void WebView_Carregado(object sender, WebNavigatedEventArgs e)
        {
            lblStatus.Text = "Finalizadp.";
        }

        private void WebView_Carregando(object sender, WebNavigatingEventArgs e)
        {
            lblStatus.Text = "Carregando...";
        }
    }
}