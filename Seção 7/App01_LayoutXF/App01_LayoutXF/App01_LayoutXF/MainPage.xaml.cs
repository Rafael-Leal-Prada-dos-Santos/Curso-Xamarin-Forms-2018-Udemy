using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App01_LayoutXF
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void IrPaginaStack_Clicado(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Layouts.Stack.PaginaStack());
        }

        private void IrPaginaGrid_Clicado(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Layouts.Grid.PaginaGrid());
        }

        private void IrPaginaAbsolute_Clicado(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Layouts.Absolute.PaginaAbsolute());
        }

        private void IrPaginaRelative_Clicado(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Layouts.Relative.PaginaRelative());
        }

        private void IrPaginaScroll_Clicado(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Layouts.Scroll.PaginaScroll());
        }
    }
}
