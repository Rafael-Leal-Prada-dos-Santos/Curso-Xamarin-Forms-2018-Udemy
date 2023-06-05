using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1_ConsultarCep.Servico.Modelo;

namespace App1_ConsultarCep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs e) 
        {

            string cep = CEP.Text.Trim();
            if (EhValido(cep)) 
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        RESULTADO.Text = $"Endereço: {end.bairro}, {end.localidade}, {end.uf}, {end.logradouro}";
                    }
                    else 
                    {
                        DisplayAlert("Erro", "O endereço não foi encontrado para o cep informado.", "OK");
                    }
                    
                }
                catch (Exception ex) 
                {
                    DisplayAlert("Erro crítico", ex.Message, "OK");
                }

            }
        }

        private bool EhValido(string cep) 
        {
            if(cep.Length != 8)
            {
                DisplayAlert("Cep inválido", "Cep deve conter 8 caracteres.", "OK");
                return false;
            }

            int novoCep = 0;

            if (!int.TryParse(cep, out novoCep)) 
            {
                DisplayAlert("Cep inválido", "Cep deve ser composto apenas por números", "OK");
                return false;
            }

            return true;
        }

    }
}
