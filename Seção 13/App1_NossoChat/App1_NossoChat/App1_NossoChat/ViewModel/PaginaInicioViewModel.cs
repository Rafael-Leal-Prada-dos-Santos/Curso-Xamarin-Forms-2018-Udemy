﻿using App1_NossoChat.Model;
using App1_NossoChat.Service;
using App1_NossoChat.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1_NossoChat.ViewModel
{
    public class PaginaInicioViewModel : ViewModelBase
    {
        private string _nome;
        private string _senha;
        private string _mensagem;
        

        public string Nome 
        { 
            get => _nome;
            set => DefiniorValorPropriedade(ref _nome, value);
        }

        public string Senha
        {
            get => _senha;
            set => DefiniorValorPropriedade(ref _senha, value);
        }

        public string MsgErro
        {
            get => _senha;
            set => DefiniorValorPropriedade(ref _senha, value);
        }

        public Command Comando_EfetuarLogin { get; set; }

        public Command Comando_NavegarParaPaginaChats { get; set; }

        public PaginaInicioViewModel() 
        {
            Comando_EfetuarLogin = new Command(Acessar);
        }

        private async void Acessar() 
        {
            Carregando = true;

            try
            {
                ExibeMensagemErro = false;

                Usuario usuario = new Usuario()
                {
                    nome = Nome,
                    password = Senha
                };

                Usuario usuarioLogado = await ServicoWS.ObterUsuario(usuario);

                if (usuarioLogado == null)
                {
                    MsgErro = "Senha incorreta";
                    Carregando = false;
                }
                else
                {
                    UsuarioUtil.DefinirUsuarioLogado(usuarioLogado);
                    Comando_NavegarParaPaginaChats.Execute(null);
                }

            }
            catch (Exception e)
            {
                ExibeMensagemErro = true;
            }
            finally 
            {
                Carregando = false;
            }
            
        }
    }
}
