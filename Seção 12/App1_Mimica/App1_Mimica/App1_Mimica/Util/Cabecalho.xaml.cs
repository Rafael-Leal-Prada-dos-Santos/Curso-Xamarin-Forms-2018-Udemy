using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Mimica.Util
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cabecalho : ContentView
    {
        public Cabecalho()
        {
            InitializeComponent();

            BindingContext = new ViewModel.CabecalhoViewModel();
        }

        public void SairEvento(object sender, EventArgs e) 
        {
            var viewmodel = (ViewModel.CabecalhoViewModel)this.BindingContext;
            if (viewmodel.Comando_Sair.CanExecute(null)) 
            {
                viewmodel.Comando_Sair.Execute(null);
            }
        }

    }
}