using App1_NossoChat.Model;
using App1_NossoChat.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1_NossoChat.ViewModel
{
    public class CadastrarChatViewModel: ViewModelBase
    {
        private string _nome;
        private string _mensagem;

        public Command Comando_Cadastrar { get; }
        public Command Comando_Voltar { get; set; }
        public string Nome 
        { 
            get => _nome; 
            set => DefiniorValorPropriedade(ref _nome, value); 
        }

        public string Mensagem
        {
            get => _mensagem;
            set => DefiniorValorPropriedade(ref _mensagem, value);
        }

        public CadastrarChatViewModel() 
        {
            Comando_Cadastrar = new Command(async() => await Cadastrar());
        }

        private async Task Cadastrar() 
        {
            Carregando = true;

            try
            {
                Chat novoChat = new Chat() { nome = _nome };

                bool resultado = await ServicoWS.CriarChat(novoChat);

                if (resultado)
                {
                    Carregando = false;
                    Comando_Voltar.Execute(null);
                }
                else
                {
                    Carregando = false;
                    _mensagem = "Ocorreu um erro no cadastro!";
                }

            }
            catch (Exception ex) 
            {
                Carregando = false;
            }
        }
    }
}
