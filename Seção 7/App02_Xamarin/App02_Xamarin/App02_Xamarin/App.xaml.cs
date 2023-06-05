using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02_Xamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            NavigationPage navigation = new NavigationPage(new Master.MenuPrincipal());
            //NavigationPage.SetHasNavigationBar(navigation, false);
            App.Current.MainPage = navigation;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
