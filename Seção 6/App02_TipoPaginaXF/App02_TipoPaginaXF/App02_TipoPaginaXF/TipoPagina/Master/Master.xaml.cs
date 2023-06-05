using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_TipoPaginaXF.TipoPagina.Master
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [Obsolete]
    public partial class Master : MasterDetailPage
    {
        public Master()
        {
            InitializeComponent();
        }

        private void MudarPagina1(object sender, EventArgs e)
        {
            Detail = new Navigation.Navigation1();
        }

        private void MudarPagina2(object sender, EventArgs e)
        {
            Detail = new Navigation.Navigation2();
        }

        private void MudarPagina3(object sender, EventArgs e)
        {
            Detail = new Conteudo();
        }
    }
}