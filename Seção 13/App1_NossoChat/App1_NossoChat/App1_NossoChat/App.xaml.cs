using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_NossoChat
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new View.Mensagem(new Model.Chat())) { BarBackgroundColor = Color.FromHex("5ED055"), BarTextColor = Color.White};
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
