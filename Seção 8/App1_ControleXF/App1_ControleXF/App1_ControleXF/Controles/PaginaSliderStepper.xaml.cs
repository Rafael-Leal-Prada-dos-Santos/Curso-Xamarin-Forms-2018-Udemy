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
    public partial class PaginaSliderStepper : ContentPage
    {
        public PaginaSliderStepper()
        {
            InitializeComponent();
        }

        private void Slider_MudouValor(object sender, ValueChangedEventArgs e)
        {
            lblResultadoSlider.Text = e.NewValue.ToString();
        }

        private void Stepper_MudouValor(object sender, ValueChangedEventArgs e)
        {
            lblResultadoStepper.Text = e.NewValue.ToString();
        }
    }
}