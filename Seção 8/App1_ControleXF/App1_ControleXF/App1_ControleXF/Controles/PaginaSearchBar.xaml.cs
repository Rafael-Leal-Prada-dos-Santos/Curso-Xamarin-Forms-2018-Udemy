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
    public partial class PaginaSearchBar : ContentPage
    {
        private List<string> empresasTI;

        public PaginaSearchBar()
        {
            InitializeComponent();

            empresasTI = new List<string>();

            empresasTI.Add("Microsoft");
            empresasTI.Add("Apple");
            empresasTI.Add("Oracle");
            empresasTI.Add("IBM");
            empresasTI.Add("SAP");
            empresasTI.Add("Uber");
            empresasTI.Add("99Taxi");

            Preencher(empresasTI);

        }

        private void Pesquisar_Selecionado(object sender, EventArgs args)
        {
            SearchBar sb = (SearchBar)sender;
            var resultado = empresasTI.Where(e => e.ToUpper().Contains(sb.Text.ToUpper())).ToList<string>();
            Preencher(resultado);
        }

        private void Pesquisar(object sender, TextChangedEventArgs args) 
        {
            var resultado = empresasTI.Where(e => e.ToUpper().Contains(args.NewTextValue.ToUpper())).ToList<string>();
            Preencher(resultado);
        }

        private void Preencher(List<string> empresas) 
        {
            listaResultado.Children.Clear();
            foreach (var emp in empresas)
            {
                listaResultado.Children.Add(new Label { Text = emp });
            }
        }
    }
}