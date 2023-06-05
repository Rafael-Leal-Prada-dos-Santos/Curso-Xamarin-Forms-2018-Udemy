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
    public partial class PaginaSwitch : ContentPage
    {
        public PaginaSwitch()
        {
            InitializeComponent();
        }

        private void Trocou_Switch(object sender, ToggledEventArgs e)
        {
            lblResultado.Text = DateTime.Now.ToString("HH:mm") + " - " + e.Value;
        }
    }
}