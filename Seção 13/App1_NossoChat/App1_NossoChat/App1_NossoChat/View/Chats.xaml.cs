using App1_NossoChat.Service;
using App1_NossoChat.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace App1_NossoChat.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Chats : ContentPage
    {
        private ChatsViewModel _viewModel = new ChatsViewModel(); 
        public Chats()
        {
            InitializeComponent();

            _viewModel = new ChatsViewModel();

            _viewModel.Comando_IrParaPaginaMensagem = new Command(IrPaginaMensagens);

            BindingContext = _viewModel;

            IncluirToolbarItemAdicionar();
            IncluirToolbarItemOrdenar();
            IncluirToolbarItemRecarregar();
        }

        private void IrPaginaMensagens() 
        {
            if (_viewModel.ChatSelecionado != null) 
            {
                Navigation.PushAsync(new Mensagem(_viewModel.ChatSelecionado));
                _viewModel.ChatSelecionado = null;
            }
        }


        private void IncluirToolbarItemAdicionar() 
        {

            var fontAwesomeFontFamily = (OnPlatform<string>)Application.Current.Resources["FontAwesomeSolid"];

            var fontAwesomeLabel = new Label
            {
                Text = "\uf067",
                FontFamily = fontAwesomeFontFamily,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Color.White
            };


            var toolbarItem = new ToolbarItem
            {
                IconImageSource = new FontImageSource
                {
                    Glyph = fontAwesomeLabel.Text,
                    FontFamily = fontAwesomeLabel.FontFamily,
                    Size = fontAwesomeLabel.FontSize,
                    Color = fontAwesomeLabel.TextColor
                },
                Text = "Adicionar", // Texto de acessibilidade para o item (opcional)
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new CadastrarChat());
                })
            };


            ToolbarItems.Add(toolbarItem);
        }

        private void IncluirToolbarItemOrdenar()
        {

            ToolbarItem toolbarItem;
            if (Device.RuntimePlatform == Device.iOS)
            {
                // Ícone do Font Awesome para iOS
                toolbarItem = new ToolbarItem("", "\uf160", () => { _viewModel.Chats = _viewModel.Chats.OrderBy(c => c.nome).ToList(); });
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                // Ícone do Font Awesome para Android
                toolbarItem = new ToolbarItem("", "\uf160", () => { _viewModel.Chats = _viewModel.Chats.OrderBy(c => c.nome).ToList(); });
            }
            else if (Device.RuntimePlatform == Device.UWP)
            {
                // Ícone do Font Awesome para UWP
                toolbarItem = new ToolbarItem("", "\uf160", () => { _viewModel.Chats = _viewModel.Chats.OrderBy(c => c.nome).ToList(); });
            }
            else
            {
                // Fallback, caso a plataforma não seja reconhecida
                toolbarItem = new ToolbarItem("", "icone_padrao.png", () => { /* Código a ser executado */ });
            }

            ToolbarItems.Add(toolbarItem);
        }

        private void IncluirToolbarItemRecarregar()
        {

            ToolbarItem toolbarItem;
            if (Device.RuntimePlatform == Device.iOS)
            {
                // Ícone do Font Awesome para iOS
                toolbarItem = new ToolbarItem("", "\uf021", () => { AtualizarChats(); });
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                // Ícone do Font Awesome para Android
                toolbarItem = new ToolbarItem("", "\uf021", () => { AtualizarChats(); });
            }
            else if (Device.RuntimePlatform == Device.UWP)
            {
                // Ícone do Font Awesome para UWP
                toolbarItem = new ToolbarItem("", "\uf021", () => { AtualizarChats(); });
            }
            else
            {
                // Fallback, caso a plataforma não seja reconhecida
                toolbarItem = new ToolbarItem("", "icone_padrao.png", () => { AtualizarChats(); });
            }

            ToolbarItems.Add(toolbarItem);
        }

        public void AtualizarChats() 
        {
            Task.Run(() => _viewModel.CarregarChats()); 
        }
    }

    
}