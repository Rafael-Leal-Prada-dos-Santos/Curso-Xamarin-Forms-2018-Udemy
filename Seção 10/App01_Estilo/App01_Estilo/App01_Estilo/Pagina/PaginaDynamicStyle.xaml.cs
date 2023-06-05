using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_Estilo.Pagina
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaDynamicStyle : ContentPage
    {
        public PaginaDynamicStyle()
        {
            InitializeComponent();
        }

        private void MudarCor_Clicado(object sender, EventArgs e)
        {
            this.Resources["lblColor"] = Color.Orange;

            this.Resources["lbl"] = this.Resources["newLbl"];
        }
    }
}