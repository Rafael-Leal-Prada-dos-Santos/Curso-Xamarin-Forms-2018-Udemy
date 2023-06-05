using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using App1_Vagas.Banco;
using System.IO;
using App1_Vagas.Droid.Banco;

//Assinatura que direciona o dependency service para localizar as implementações de interface
[assembly: Dependency(typeof(Caminho))]

namespace App1_Vagas.Droid.Banco
{
    public class Caminho : ICaminho
    {
        public string ObterCaminho(string nomeArquivoBanco)
        {
            string caminhoDaPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string caminhoBanco = Path.Combine(caminhoDaPasta, nomeArquivoBanco);

          return caminhoBanco;
        }
    }
}