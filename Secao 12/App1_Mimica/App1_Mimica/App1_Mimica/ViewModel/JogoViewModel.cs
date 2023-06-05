﻿using App1_Mimica.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1_Mimica.ViewModel
{
    public class JogoViewModel : ViewModelBase
    {
        public Grupo Grupo { get; set; }
        public string NomeGrupo { get; set; }

        private string _palavra;
        public string Palavra 
        {
            get => _palavra;
            set 
            {
                _palavra = value;
                PropriedadeMudada("Palavra");
            } 
        }

        private byte _palavraPontuacao;

        public byte PalavraPontuacao 
        {
            get => _palavraPontuacao;
            set 
            {
                _palavraPontuacao = value;
                PropriedadeMudada("PalavraPontuacao");
            }
        }

        private string _textoContagem { get; set; }
        public string TextoContagem 
        {
            get => _textoContagem;
            set 
            {
                _textoContagem = value;
                PropriedadeMudada("TextoContagem");
            } 
        }

        public bool _conteinerContagemVisivel;
        public bool ConteinerContagemVisivel 
        {
            get => _conteinerContagemVisivel;
            set 
            {
                _conteinerContagemVisivel = value;
                PropriedadeMudada("ConteinerContagemVisivel");
            }
        }

        private bool _conteinerIniciarVisivel { get; set; }
        public bool ConteinerIniciarVisivel 
        {
            get => _conteinerIniciarVisivel;
            set 
            {
                _conteinerIniciarVisivel = value;
                PropriedadeMudada("ConteinerIniciarVisivel");
            }
        }



        private bool _btnMostrarVisivel;
        public bool BtnMostrarVisivel 
        {
            get => _btnMostrarVisivel;
            set 
            {
                _btnMostrarVisivel = value;
                PropriedadeMudada("BtnMostrarVisivel");
            }
        }

      

        public Command MostrarPalavra { get; set; }

        public Command Acertou { get; set; }

        public Command Errou { get; set; }

        public Command Iniciar { get; set; }


        public JogoViewModel(Grupo grupo) 
        {
            this.Grupo = grupo;
            NomeGrupo = grupo.Nome;

            ConteinerContagemVisivel = false;
            ConteinerIniciarVisivel = false;
            BtnMostrarVisivel = true;

            Palavra = "************";

            MostrarPalavra = new Command(MostrarPalavraJogo);
            Acertou = new Command(AcertouPalavra);
            Errou = new Command(ErrouPalavra);
            Iniciar = new Command(IniciarJogo);
        }

        private void MostrarPalavraJogo() 
        {

            PalavraPontuacao = 3;

            Palavra = "Sentar";

            BtnMostrarVisivel = false;
            ConteinerIniciarVisivel = true;
        }



        private void IniciarJogo()
        {
            ConteinerIniciarVisivel = false;
            ConteinerContagemVisivel = true;

            int i = Armazenamento.Armazenamento.Jogo.TempoPalavra;

            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                TextoContagem = i.ToString();
                i--;

                if (i < 0) 
                {
                    TextoContagem = "Esgotou o tempo";
                }

                return true;
            });
        }


        private void ErrouPalavra()
        {
            IrProximoGrupo();
        }


        private void AcertouPalavra()
        {
            Grupo.Pontuacao += PalavraPontuacao;
            IrProximoGrupo();
        }

        private void IrProximoGrupo() 
        {
            Grupo grupo;

            if (Armazenamento.Armazenamento.Jogo.Grupo1 == Grupo)
            {
                grupo = Armazenamento.Armazenamento.Jogo.Grupo2;
            }
            else
            {
                grupo = Armazenamento.Armazenamento.Jogo.Grupo1;
                Armazenamento.Armazenamento.RodadaAtual++;
            }

            if (Armazenamento.Armazenamento.RodadaAtual > Armazenamento.Armazenamento.Jogo.Rodadas) 
            {
                App.Current.MainPage = new View.Resultado();
            }

            App.Current.MainPage = new View.Jogo(grupo);
        }
    }
}