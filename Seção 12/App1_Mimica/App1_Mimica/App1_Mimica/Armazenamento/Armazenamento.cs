using System;
using System.Collections.Generic;
using System.Text;
using App1_Mimica.Model;

namespace App1_Mimica.Armazenamento
{
    public class Armazenamento
    {
        public static Jogo Jogo { get; set; }

        public static short RodadaAtual { get; set; }

        public static string[][] Palavras =
        {
            //Facil Pontuação 1
            new string[]{"Olho", "Língua", "Chinelo", "Milho," , "Pênalti", "Bola", "Ping-pong" },
            //Medio Pontuação 3
            new string[]{"Carpinteiro", "Persiana", "Amarelo", "Bandeira", "Abelha" },
            //Dificil Pontuação 5
            new string[]{"Cisterna" , "Lanterna", "Paralelepípedo", "Batman vs Superman" , "Notebook"},
        };

    }
}
