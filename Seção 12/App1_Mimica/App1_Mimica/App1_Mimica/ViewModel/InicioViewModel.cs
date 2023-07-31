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

        private string _msgErro;
        public string MsgErro 
        { 
            get => _msgErro;
            set { _msgErro = value; PropriedadeMudada(nameof(MsgErro));} 
        }

        public InicioViewModel() 
        {
            Comando_Iniciar_Jogo = new Command(IniciarJogo);
            Jogo = new Jogo();
            Jogo.Grupo1 = new Grupo();
            Jogo.Grupo2 = new Grupo();

            Jogo.TempoPalavra = 180;
            Jogo.Rodadas = 7;
        }

        private void IniciarJogo() 
        {
            StringBuilder sbErro = new StringBuilder();
            string erro = "";
            if (Jogo.TempoPalavra <= 10) 
            {
                sbErro.AppendLine("O tempo mínimo para o tempo da palavra é 10 segundos");
            }
            if (Jogo.Rodadas <= 0) 
            {
                sbErro.AppendLine("O valor mínimo para a quantidade de rodadas é 1");
            }

            if (sbErro.Length > 0)
            {
                MsgErro = sbErro.ToString();
            }
            else 
            {
                Armazenamento.Armazenamento.Jogo = Jogo;
                Armazenamento.Armazenamento.RodadaAtual = 1;


                App.Current.MainPage = new View.Jogo(Jogo.Grupo1);
            }
          
        }
    }
}
