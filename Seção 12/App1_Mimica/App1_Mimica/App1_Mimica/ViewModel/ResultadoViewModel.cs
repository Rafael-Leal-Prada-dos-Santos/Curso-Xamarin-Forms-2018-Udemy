using System;
using System.Collections.Generic;
using System.Text;
using App1_Mimica.Model;
using Xamarin.Forms;

namespace App1_Mimica.ViewModel
{
    public class ResultadoViewModel : ViewModelBase
    {
        public Jogo Jogo { get; set; }

        public Command Comando_JogarNovamente { get; set; }
        public ResultadoViewModel() 
        {
            Jogo = Armazenamento.Armazenamento.Jogo;
            Comando_JogarNovamente = new Command(JogarNovamente);
        }

        private void JogarNovamente() 
        {
            App.Current.MainPage = new View.Inicio();
        }
    }
}
