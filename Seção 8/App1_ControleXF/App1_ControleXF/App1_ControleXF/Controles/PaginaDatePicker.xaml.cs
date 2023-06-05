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
    public partial class PaginaDatePicker : ContentPage
    {
        public PaginaDatePicker()
        {
            InitializeComponent();
        }

        private void Data_Selecionada(object sender, DateChangedEventArgs e)
        {
            lblResultado.Text = e.OldDate.ToString("dd/MM/yyyy") +" > " + e.NewDate.ToString("dd/MM/yyyy") ;
        }
    }
}