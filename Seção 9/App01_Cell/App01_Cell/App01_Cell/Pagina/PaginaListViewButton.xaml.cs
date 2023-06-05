using App01_Cell.Modelo;
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
    public partial class PaginaListViewButton : ContentPage
    {
        List<Funcionario> funcionarios;
        public PaginaListViewButton()
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

        private void Ferias_Clicado(object sender, EventArgs e)
        {
            Button item = sender as Button;

            Funcionario funcionario = item.CommandParameter as Funcionario;

            DisplayAlert("Titulo: " + funcionario.Nome, "Mensagem: " + " - " + funcionario.Cargo, "OK");
        }
    }
}