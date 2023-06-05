using App01_Cell.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.WebRequestMethods;

namespace App01_Cell.Pagina
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaImageCell : ContentPage
    {
        List<Funcionario> funcionarios;
        public PaginaImageCell()
        {
            InitializeComponent();

            PopularListaFuncionarios();
        }

        private void PopularListaFuncionarios()
        {
            funcionarios = new List<Funcionario>();

            funcionarios.Add(new Funcionario() { Nome = "José", Cargo = "Presidente da Empresa" , Foto= "http://www.transparencia.luisdomingues.ma.gov.br/fornecedor/fotos/padrao.jpg" });
            funcionarios.Add(new Funcionario() { Nome = "Maria", Cargo = "Gerente de Vendas", Foto = "http://www.transparencia.luisdomingues.ma.gov.br/fornecedor/fotos/padrao.jpg" });
            funcionarios.Add(new Funcionario() { Nome = "Elaine", Cargo = "Gerente de Marketing", Foto = "http://www.transparencia.luisdomingues.ma.gov.br/fornecedor/fotos/padrao.jpg" });
            funcionarios.Add(new Funcionario() { Nome = "Felipe", Cargo = "Entregador", Foto = "http://www.transparencia.luisdomingues.ma.gov.br/fornecedor/fotos/padrao.jpg" });
            funcionarios.Add(new Funcionario() { Nome = "João", Cargo = "Vendedor" , Foto = "http://www.transparencia.luisdomingues.ma.gov.br/fornecedor/fotos/padrao.jpg" });

            listaFuncionario.ItemsSource = funcionarios;
        }
    }
}