using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_TipoPaginaXF.TipoPagina.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Navigation1 : ContentPage
    {
        public Navigation1()
        {
            InitializeComponent();
        }

        private void MudarParaPaginaDois(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Navigation2());
        }

        private void ChamarModal(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Modal());
        }
    }
}