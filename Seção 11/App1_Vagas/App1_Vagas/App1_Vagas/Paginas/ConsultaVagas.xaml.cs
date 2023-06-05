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
    public partial class ConsultaVagas : ContentPage
    {
        private List<Vaga> Lista { get; set; }
        public ConsultaVagas()
        {
            InitializeComponent();
            AtualizarDados();
        }

        public async void IrPaginaAdicionarVagas(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CadastroVaga(this));
        }

        public async void IrPaginaMinhasVagas(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MinhaVagasCadastradas());
        }

        public async void MaisDetalhes_Clicado(object sender, EventArgs e)
        {
            Label label = sender as Label;

            TapGestureRecognizer gesto = label.GestureRecognizers.FirstOrDefault() as TapGestureRecognizer;

            Vaga vaga = gesto.CommandParameter as Vaga;

            await Navigation.PushAsync(new DetalhesVaga(vaga));
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