using App01_Cell.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_Cell.Pagina.Detalhe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalhesFuncionario : ContentPage
    {
        public DetalhesFuncionario(Funcionario funcionario)
        {
            InitializeComponent();

            lblNome.Text = funcionario.Nome;
        }
    }
}