using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2_SOAPClient
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            int numero1 = int.Parse(Num1.Text);
            int numero2 = int.Parse(Num2.Text);

            txtTexto.Text = DependencyService.Get<IServiceSOAP>().Somar(numero1, numero2);
        }
    }
}
