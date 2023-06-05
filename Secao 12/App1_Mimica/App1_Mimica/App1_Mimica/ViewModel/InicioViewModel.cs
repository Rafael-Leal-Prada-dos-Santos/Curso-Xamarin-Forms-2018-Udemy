using App1_Mimica.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1_Mimica.Armazenamento;

namespace App1_Mimica.ViewModel
{
    public class InicioViewModel : ViewModelBase
    {
        public Jogo Jogo { get; set; }

        public Command Comando_Iniciar_Jogo { get; set; }

        public InicioViewModel() 
        {
            Comando_Iniciar_Jogo = new Command(IniciarJogo);
            Jogo = new Jogo();
            Jogo.Grupo1 = new Grupo();
            Jogo.Grupo2 = new Grupo();
        }

        private void IniciarJogo() 
        {
            Armazenamento.Armazenamento.Jogo = Jogo;
            Armazenamento.Armazenamento.RodadaAtual = 1;


            App.Current.MainPage = new View.Jogo(Jogo.Grupo1);
        }
    }
}
