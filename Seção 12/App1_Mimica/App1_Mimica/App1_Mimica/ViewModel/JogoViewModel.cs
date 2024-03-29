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
        public string NumeroGrupo { get; set; }

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

        private bool _botaoIniciarVisivel { get; set; }
        public bool BotaoIniciarVisivel 
        {
            get => _botaoIniciarVisivel;
            set 
            {
                _botaoIniciarVisivel = value;
                PropriedadeMudada("BotaoIniciarVisivel");
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

            if (grupo == Armazenamento.Armazenamento.Jogo.Grupo1)
            {
                NumeroGrupo = "Grupo 1";
            }
            else 
            {
                NumeroGrupo = "Grupo 2";
            }

            ConteinerContagemVisivel = false;
            BotaoIniciarVisivel = false;
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

            var numNivel = Armazenamento.Armazenamento.Jogo.NivelNumerico;
            if (numNivel == 0) 
            {
                //Aleatório
                Random rd = new Random();
                int nivelAleatorio = rd.Next(0, 3);

                int indice = rd.Next(0, Armazenamento.Armazenamento.Palavras[nivelAleatorio].Length);
                Palavra = Armazenamento.Armazenamento.Palavras[nivelAleatorio][indice];
                PalavraPontuacao =  (byte)((nivelAleatorio == 0) ? 1 : (nivelAleatorio == 1) ? 3 : 5);
            }
            if (numNivel == 1)
            {
                //Fácil
                Random rd = new Random();

                int indice = rd.Next(0, Armazenamento.Armazenamento.Palavras[numNivel - 1].Length);
                Palavra = Armazenamento.Armazenamento.Palavras[numNivel - 1][indice];
                PalavraPontuacao = 1;
            }
            if (numNivel == 2)
            {
                //Médio

                Random rd = new Random();

                int indice = rd.Next(0, Armazenamento.Armazenamento.Palavras[numNivel - 1].Length);
                Palavra = Armazenamento.Armazenamento.Palavras[numNivel - 1][indice];
                PalavraPontuacao = 3;
            }
            if (numNivel == 3)
            {
                //Difícil
                Random rd = new Random();

                int indice = rd.Next(0, Armazenamento.Armazenamento.Palavras[numNivel - 1].Length);
                Palavra = Armazenamento.Armazenamento.Palavras[numNivel - 1][indice];
                PalavraPontuacao = 5;
            }


            BtnMostrarVisivel = false;
            BotaoIniciarVisivel = true;
        }



        private void IniciarJogo()
        {
            BotaoIniciarVisivel = false;
            ConteinerContagemVisivel = true;

            int i = Armazenamento.Armazenamento.Jogo.TempoPalavra;

            TextoContagem = i.ToString();
            i--;

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
            else
            {
                App.Current.MainPage = new View.Jogo(grupo);
            }
           
        }
    }
}
