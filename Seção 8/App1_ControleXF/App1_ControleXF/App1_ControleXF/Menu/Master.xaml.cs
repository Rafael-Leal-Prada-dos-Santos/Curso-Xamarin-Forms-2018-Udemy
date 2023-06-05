using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_ControleXF.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : FlyoutPage
    {
        public Master()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void IrPaginaActivityIndicator(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Controles.PaginaActivityIndicator());
            IsPresented = false;
        }

        private void IrPaginaProgressBar(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Controles.PaginaProgressBar());
            IsPresented = false;
        }

        private void IrPaginaBoxView(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Controles.PaginaBoxView());
            IsPresented = false;
        }

        private void IrPaginaLabel(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Controles.PaginaLabel());
            IsPresented = false;
        }

        private void IrPaginaButton(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Controles.PaginaButton());
            IsPresented = false;
        }

        private void IrPaginaEntryEditor(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Controles.PaginaEntryEditor());
            IsPresented = false;
        }
        private void IrPaginaDatePicker(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Controles.PaginaDatePicker());
            IsPresented = false;
        }
        private void IrPaginaTimePicker(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Controles.PaginaTimePicker());
            IsPresented = false;
        }
        private void IrPaginaPicker(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Controles.PaginaPicker());
            IsPresented = false;
        }
        private void IrPaginaSearchBar(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Controles.PaginaSearchBar());
            IsPresented = false;
        }

        private void IrPaginaSliderStepper(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Controles.PaginaSliderStepper());
            IsPresented = false;
        }
        private void IrPaginaSwitch(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Controles.PaginaSwitch());
            IsPresented = false;
        }
        private void IrPaginaImage(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Controles.PaginaImage());
            IsPresented = false;
        }
        private void IrPaginaListView(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Controles.PaginaListView());
            IsPresented = false;
        }
        private void IrPaginaTableView(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Controles.PaginaTableView());
            IsPresented = false;
        }
        private void IrPaginaWebView(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Controles.PaginaWebView());
            IsPresented = false;
        }
    }
}