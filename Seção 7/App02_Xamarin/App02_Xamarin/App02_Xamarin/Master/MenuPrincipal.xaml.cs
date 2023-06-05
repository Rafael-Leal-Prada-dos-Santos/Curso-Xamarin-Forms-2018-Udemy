using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_Xamarin.Master
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPrincipal : FlyoutPage
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void IrPaginaPerfil(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new Pages.Perfil()));
        }

        private void IrPaginaXamarin(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new Pages.Xamarin()));
        }
    }
}