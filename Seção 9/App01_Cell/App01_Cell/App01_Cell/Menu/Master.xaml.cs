using App01_Cell.Pagina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_Cell.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : FlyoutPage
    {
        public Master()
        {
            InitializeComponent();
        }

        private void IrPaginaTextCell(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Pagina.PaginaTextCell());
            IsPresented = false;
        }

        private void IrPaginaImageCell(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Pagina.PaginaImageCell());
            IsPresented = false;
        }

        private void IrPaginaEntryCell(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Pagina.PaginaEntryCell());
            IsPresented = false;
        }

        private void IrPaginaSwitchCell(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PaginaSwitchCell());
            IsPresented = false;
        }

        private void IrPaginaViewCell(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PaginaViewCell());
            IsPresented = false;
        }

        private void IrPaginaListView(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PaginaListView());
            IsPresented = false;
        }

        private void IrPaginaListViewButton(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PaginaListViewButton());
            IsPresented = false;
        }
    }
}