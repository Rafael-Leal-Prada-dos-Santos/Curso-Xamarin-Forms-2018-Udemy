using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App01_Cell.Modelo;

namespace App01_Cell.Pagina
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaTextCell : ContentPage
    {
        List<Funcionario> funcionarios;
        public PaginaTextCell()
        {
            InitializeComponent();

            PopularListaFuncionarios();
        }

        private void PopularListaFuncionarios() 
        {
            funcionarios = new List<Funcionario>();

            funcionarios.Add(new Funcionario() { Nome = "José", Cargo = "Presidente da Empresa"});
            funcionarios.Add(new Funcionario() { Nome = "Maria", Cargo = "Gerente de Vendas"});
            funcionarios.Add(new Funcionario() { Nome = "Elaine", Cargo = "Gerente de Marketing"});
            funcionarios.Add(new Funcionario() { Nome = "Felipe", Cargo = "Entregador"});
            funcionarios.Add(new Funcionario() { Nome = "João", Cargo = "Vendedor"});

            listaFuncionario.ItemsSource = funcionarios;
        }
    }
}