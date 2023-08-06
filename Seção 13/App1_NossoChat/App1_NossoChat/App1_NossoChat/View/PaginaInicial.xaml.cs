using App1_NossoChat.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_NossoChat.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaInicial : ContentPage
    {
        private PaginaInicioViewModel _viewModel;

        public PaginaInicial()
        {
            InitializeComponent();

            _viewModel = new PaginaInicioViewModel();

            _viewModel.Comando_NavegarParaPaginaChats = new Command(NavegarPaginaChats);

            BindingContext = new PaginaInicioViewModel();
        }

        private void NavegarPaginaChats() 
        {
            App.Current.MainPage = new NavigationPage(new Chats());
        }

    }
}