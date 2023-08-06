using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App3_JWTAsync.Model;
using App3_JWTAsync.Service;

namespace App3_JWTAsync
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ObterToken(object sender, EventArgs e)
        {
           string resultado = await JWTService.ObterToken(nome.Text, senha.Text);

            lblToken.Text = resultado;
        }

        private async void VerificarToken(object sender, EventArgs e)
        {
            string resultado = await JWTService.Verificar();

            lblRestulado.Text = resultado;
        }
    }
}
