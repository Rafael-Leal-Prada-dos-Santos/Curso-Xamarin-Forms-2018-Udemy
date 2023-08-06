using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1_Mimica.ViewModel
{
    public class CabecalhoViewModel
    {
        public Command Comando_Sair { get; set; }

        public CabecalhoViewModel()
        {
            Comando_Sair = new Command(Sair);
        }

        private void Sair(object obj)
        {
            App.Current.MainPage = new View.Inicio();
        }
    }
}
