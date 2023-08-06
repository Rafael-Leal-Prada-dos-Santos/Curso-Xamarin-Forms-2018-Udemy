using App1_NossoChat.Model;
using App1_NossoChat.Service;
using App1_NossoChat.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1_NossoChat.ViewModel
{
    public class ChatsViewModel : ViewModelBase
    {
        public List<Chat> _chats;

        public Chat _chatSelecionado;

        public List<Chat> Chats 
        { 
            get => _chats; 
            set => DefiniorValorPropriedade(ref _chats, value);
        }

        public Chat ChatSelecionado
        {
            get => _chatSelecionado;
            set 
            {
                DefiniorValorPropriedade(ref _chatSelecionado, value);
                Comando_IrParaPaginaMensagem.Execute(null);
            } 
        }

        public Command Comando_IrParaPaginaMensagem { get; set; }

        public ChatsViewModel()
        {
            Chats = ServicoWS.ObterListaDeConversas();
        }
    }
}
