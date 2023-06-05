using App1_Vagas.Banco;
using App1_Vagas.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Vagas.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MinhaVagasCadastradas : ContentPage
    {
        private List<Vaga> Lista { get; set; }
        public MinhaVagasCadastradas()
        {
            InitializeComponent();
            AtualizarDados();
        }

        private void Editar_Clicado(object sender, EventArgs e)
        {
            Label label = sender as Label;

            TapGestureRecognizer gesto = label.GestureRecognizers.FirstOrDefault() as TapGestureRecognizer;

            Vaga vaga = gesto.CommandParameter as Vaga;

            _ = Navigation.PushAsync(new CadastroVaga(this, vaga));
        }

        private void Excluir_Clicado(object sender, EventArgs e)
        {
            Label label = sender as Label;

            TapGestureRecognizer gesto = label.GestureRecognizers.FirstOrDefault() as TapGestureRecognizer;

            Vaga vaga = gesto.CommandParameter as Vaga;

            BancoDeDados banco = new BancoDeDados();
            banco.Exclusao(vaga);

            AtualizarDados();
        }

        public void AtualizarDados()
        {
            BancoDeDados bancoDados = new BancoDeDados();
            Lista = bancoDados.Consultar();
            ListaVagas.ItemsSource = Lista;
            lblContadorVagas.Text = $"{Lista.Count} vagas encontradas";
        }

        private void Pesquisar_TextoModificado(object sender, TextChangedEventArgs e)
        {
            string pesquisa = e.NewTextValue;

            if (string.IsNullOrEmpty(pesquisa))
            {
                ListaVagas.ItemsSource = Lista;
            }

            List<Vaga> listaFiltrada = Lista.Where(l => l.NomeVaga.ToUpper().Contains(pesquisa.ToUpper())).ToList();

            ListaVagas.ItemsSource = listaFiltrada;
        }

        

    }
}