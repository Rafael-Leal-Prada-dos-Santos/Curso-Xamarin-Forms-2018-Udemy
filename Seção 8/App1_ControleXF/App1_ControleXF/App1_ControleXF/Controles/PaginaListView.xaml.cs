using App1_ControleXF.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_ControleXF.Controles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaListView : ContentPage
    {
        private List<Pessoa> _listaPessoas;
        public PaginaListView()
        {
            InitializeComponent();

            _listaPessoas = new List<Pessoa>();

            _listaPessoas.Add(new Pessoa() { Nome = "Rafael", Idade = "27" });
            _listaPessoas.Add(new Pessoa() { Nome = "Richard", Idade = "22" });
            _listaPessoas.Add(new Pessoa() { Nome = "Brenno", Idade = "22" });
            _listaPessoas.Add(new Pessoa() { Nome = "Renato", Idade = "21" });
            _listaPessoas.Add(new Pessoa() { Nome = "Newton", Idade = "70" });
            _listaPessoas.Add(new Pessoa() { Nome = "Lizandra", Idade = "27" });

            listaPessoas.ItemsSource = _listaPessoas;

        }
    }
}