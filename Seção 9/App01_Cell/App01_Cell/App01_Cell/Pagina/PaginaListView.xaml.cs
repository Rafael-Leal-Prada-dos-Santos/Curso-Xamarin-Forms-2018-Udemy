using App01_Cell.Modelo;
using App01_Cell.Pagina.Detalhe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_Cell.Pagina
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaListView : ContentPage
    {
        List<Funcionario> funcionarios;
        public PaginaListView()
        {
            InitializeComponent();

            PopularListaFuncionarios();
        }

        private void PopularListaFuncionarios()
        {
            funcionarios = new List<Funcionario>();

            funcionarios.Add(new Funcionario() { Nome = "José", Cargo = "Presidente da Empresa" });
            funcionarios.Add(new Funcionario() { Nome = "Maria", Cargo = "Gerente de Vendas" });
            funcionarios.Add(new Funcionario() { Nome = "Elaine", Cargo = "Gerente de Marketing" });
            funcionarios.Add(new Funcionario() { Nome = "Felipe", Cargo = "Entregador" });
            funcionarios.Add(new Funcionario() { Nome = "João", Cargo = "Vendedor" });

            listaFuncionario.ItemsSource = funcionarios;
        }

        private void Item_Selecionado(object sender, SelectedItemChangedEventArgs args)
        {
            ListView lv = sender as ListView;

            Funcionario funcionaroSelecionado = (Funcionario)args.SelectedItem;

            Navigation.PushAsync(new DetalhesFuncionario(funcionaroSelecionado));
        }

        private void Ferias_Clicado(object sender, EventArgs args)
        {
            MenuItem item = sender as MenuItem;

            Funcionario funcionario = item.CommandParameter as Funcionario;

            DisplayAlert("Titulo: " + funcionario.Nome, "Mensagem: " + " - " + funcionario.Cargo, "OK");
        }

        private void Abono_Clicado(object sender, EventArgs args)
        {

        }
    }
}