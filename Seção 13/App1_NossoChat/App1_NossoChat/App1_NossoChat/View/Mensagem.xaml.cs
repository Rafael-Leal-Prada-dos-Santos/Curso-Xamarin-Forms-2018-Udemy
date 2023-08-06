using App1_NossoChat.Model;
using App1_NossoChat.Service;
using App1_NossoChat.Util;
using App1_NossoChat.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MensagemModel = App1_NossoChat.Model.Mensagem;

namespace App1_NossoChat.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mensagem : ContentPage
    {
        private MensagemViewModel _viewModel;
        private Chat _chatAtual;

        public Mensagem(Chat chat)
        {
            InitializeComponent();

            _chatAtual = chat;

            _viewModel = new MensagemViewModel(chat);

            //_viewModel.Comando_ExibirMensagensCarregadasNaConversa =
            //    new Command(ExibirMensagensCarregadas);

            BindingContext = _viewModel;

            IncluirToolbarItemOrdenar();
            IncluirToolbarItemRecarregar();
        }

        //private void ExibirMensagensCarregadas()
        //{
        //    Usuario usuario = UsuarioUtil.ObterUsuarioLogado();

        //    slConteinerMensagem.Children.Clear();

        //    foreach (MensagemModel msg in _viewModel.Mensagens)
        //    {
        //        if (msg.usuario.id == usuario.id)
        //        {
        //            slConteinerMensagem.Children.Add(CriarLayoutMensagemUsuario(msg));
        //        }
        //        else
        //        {
        //            slConteinerMensagem.Children.Add(CriarLayoutMensagemOutrosUsuarios(msg));
        //        }
        //    }
        //}


        //private void ExibirMensagensCarregadas() 
        //{
        //    Usuario usuario = UsuarioUtil.ObterUsuarioLogado();

        //    slConteinerMensagem.Children.Clear();

        //    foreach (MensagemModel msg in _viewModel.Mensagens) 
        //    {
        //        if (msg.usuario.id == usuario.id)
        //        {
        //            slConteinerMensagem.Children.Add(CriarLayoutMensagemUsuario(msg));
        //        }
        //        else
        //        {
        //            slConteinerMensagem.Children.Add(CriarLayoutMensagemOutrosUsuarios(msg));
        //        }
        //    }
        //}

        //private Xamarin.Forms.View CriarLayoutMensagemUsuario(MensagemModel mensagem)
        //{
        //    StackLayout sl = new StackLayout() { Padding = 5, BackgroundColor = Color.FromHex("#5ED055"), HorizontalOptions = LayoutOptions.End };
        //    var label = new Label() { TextColor = Color.White, Text = mensagem.mensagem };

        //    sl.Children.Add(label);
        //    return sl;

        //}
        //private Xamarin.Forms.View CriarLayoutMensagemOutrosUsuarios(MensagemModel mensagem)
        //{
        //    Label labelNome = new Label() { Text = mensagem.usuario.nome, FontSize = 10, TextColor = Color.FromHex("#5ED055") };
        //    Label labelMensagem = new Label() { Text = mensagem.mensagem, TextColor = Color.FromHex("#5ED055") };

        //    StackLayout SL = new StackLayout();
        //    SL.Children.Add(labelNome);
        //    SL.Children.Add(labelMensagem);
        //    Frame frame = new Frame() { BorderColor = Color.FromHex("#5ED055"), CornerRadius = 0, HorizontalOptions = LayoutOptions.Start };
        //    frame.Content = SL;

        //    return frame;
        //}

        private void EnviarMensagem() 
        {
            MensagemModel msg = new MensagemModel()
            {
                id_usuario = UsuarioUtil.ObterUsuarioLogado().id,
                mensagem = _viewModel.TextoMensagem,
                id_chat = _chatAtual.id
            };

            ServicoWS.EnviarMensagem(msg);
            Atualizar();
            _viewModel.TextoMensagem = string.Empty;
        }

        private void IncluirToolbarItemOrdenar()
        {

            ToolbarItem toolbarItem;
            if (Device.RuntimePlatform == Device.iOS)
            {
                // Ícone do Font Awesome para iOS
                toolbarItem = new ToolbarItem("", "\uf160", () => { _viewModel.Mensagens = _viewModel.Mensagens.OrderBy(c => c.id).ToList(); });
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                // Ícone do Font Awesome para Android
                toolbarItem = new ToolbarItem("", "\uf160", () => { _viewModel.Mensagens = _viewModel.Mensagens.OrderBy(c => c.id).ToList(); });
            }
            else if (Device.RuntimePlatform == Device.UWP)
            {
                // Ícone do Font Awesome para UWP
                toolbarItem = new ToolbarItem("", "\uf160", () => { _viewModel.Mensagens = _viewModel.Mensagens.OrderBy(c => c.id).ToList(); });
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
                toolbarItem = new ToolbarItem("", "\uf021", () => { AtualizarMensagens(); });
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                // Ícone do Font Awesome para Android
                toolbarItem = new ToolbarItem("", "\uf021", () => { AtualizarMensagens(); });
            }
            else if (Device.RuntimePlatform == Device.UWP)
            {
                // Ícone do Font Awesome para UWP
                toolbarItem = new ToolbarItem("", "\uf021", () => { AtualizarMensagens(); });
            }
            else
            {
                // Fallback, caso a plataforma não seja reconhecida
                toolbarItem = new ToolbarItem("", "icone_padrao.png", () => { AtualizarMensagens(); });
            }

            ToolbarItems.Add(toolbarItem);
        }

        public void AtualizarMensagens()
        {
            Task.Run(() => _viewModel.CarregarMensagens());
        }

    }
}