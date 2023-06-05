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
    public partial class PaginaPicker : ContentPage
    {
        public PaginaPicker()
        {
            InitializeComponent();
        }

        private void Picker_MudouIndice(object sender, EventArgs e)
        {
            Picker obj = (Picker)sender;

            //pegar o item(objeto) que foi selecionado
            lblResultado.Text = obj.SelectedItem.ToString() + " - " + obj.SelectedIndex.ToString();
        }
    }
}