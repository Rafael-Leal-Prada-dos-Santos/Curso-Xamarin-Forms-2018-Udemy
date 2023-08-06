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
    public partial class CadastrarChat : ContentPage
    {
        private CadastrarChatViewModel _viewModel;
        public CadastrarChat()
        {
            InitializeComponent();

            _viewModel = new CadastrarChatViewModel();

            _viewModel.Comando_Voltar = new Command(SairDaPagina);

            BindingContext = _viewModel;
        }

        private void SairDaPagina() 
        {
            Navigation.PopAsync();

            ((Chats)((NavigationPage)App.Current.MainPage).RootPage).AtualizarPagina();
        }
    }
}