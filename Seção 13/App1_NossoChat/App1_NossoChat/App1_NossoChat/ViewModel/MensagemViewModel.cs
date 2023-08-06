using App1_NossoChat.Model;
using App1_NossoChat.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1_NossoChat.ViewModel
{
    public class MensagemViewModel: ViewModelBase
    {
        public List<Mensagem> _mensagens;
        public string _textoMensagem;

        public List<Mensagem> Mensagens
        {
            get => _mensagens;
            set 
            {
                DefiniorValorPropriedade(ref _mensagens, value);
                if (_mensagens != null) 
                {
                    Comando_ExibirMensagensCarregadasNaConversa.Execute(null);
                }
            } 
        }

        public string TextoMensagem
        {
            get => _textoMensagem;
            set
            {
                DefiniorValorPropriedade(ref _textoMensagem, value);
            }
        }

        public Command Comando_ExibirMensagensCarregadasNaConversa { get; set; }
        public Command Comando_EnviarMensagem { get; set; }

        public MensagemViewModel(Chat chat)
        {
            Mensagens = ServicoWS.ObterMensagensChat(chat);

            Device.StartTimer(TimeSpan.FromSeconds(1) ,() => { Mensagens = ServicoWS.ObterMensagensChat(chat); return true; } );
        }

    }
}
