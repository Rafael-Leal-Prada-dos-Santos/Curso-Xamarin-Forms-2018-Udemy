using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_Estilo.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : FlyoutPage
    {
        public Master()
        {
            InitializeComponent();
        }

        private void IrPaginaImplicitStyle(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Pagina.PaginaImplicitStyle());
            IsPresented = false;
        }

        private void IrPaginaExplicitStyle(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Pagina.PaginaExplicitStyle());
            IsPresented = false;
        }

        private void IrPaginaGlobalStyle(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Pagina.PaginaGlobalStyle());
            IsPresented = false;
        }

        private void IrPaginaInerhitStyle(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Pagina.PaginaInerhitStyle());
            IsPresented = false;
        }

        private void IrPaginaDynamicStyle(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Pagina.PaginaDynamicStyle());
            IsPresented = false;
        }
    }
}