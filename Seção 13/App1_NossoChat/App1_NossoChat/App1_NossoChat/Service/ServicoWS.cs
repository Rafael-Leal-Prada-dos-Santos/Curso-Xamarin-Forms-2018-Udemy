using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using App1_NossoChat.Model;
using Newtonsoft.Json;

namespace App1_NossoChat.Service
{
    public class ServicoWS
    {
        private static string EnderecoBase = $"http://ws.spacedu.com.br/xf2018/rest/api";

        public static Usuario ObterUsuario(Usuario usuario) 
        {
            var endereco = $"{EnderecoBase}/usuario";

            HttpClient clienteHttp = new HttpClient();

            //FormUrlEncodedContent param = new FormUrlEncodedContent(new[] {
            //     new KeyValuePair<string,string>("nome",usuario.nome),
            //     new KeyValuePair<string,string>("password", usuario.password),
            //});

            StringContent parametros = new StringContent($"?nome={usuario.nome}&password={usuario.password}");

            // PostAsync(url, parametros);

            HttpResponseMessage respostaHttp =  clienteHttp.PostAsync(endereco , parametros).GetAwaiter().GetResult();

            if (respostaHttp.IsSuccessStatusCode) 
            {
                string json = respostaHttp.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return JsonConvert.DeserializeObject<Usuario>(json);
            }

            return null;
        }

        public static List<Chat> ObterListaDeConversas()
        {
            var endereco = $"{EnderecoBase}/chats";

            HttpClient clienteHttp = new HttpClient();

            // PostAsync(url, parametros);

            HttpResponseMessage respostaHttp = clienteHttp.GetAsync(endereco).GetAwaiter().GetResult();

            if (respostaHttp.IsSuccessStatusCode)
            {
                string conteudo = respostaHttp.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                if (conteudo.Length > 2) 
                {
                    return JsonConvert.DeserializeObject<List<Chat>>(conteudo);
                }
            }

            return null;
        }

        public static bool CriarChat(Chat chat)
        {
            var endereco = $"{EnderecoBase}/chat";

            HttpClient clienteHttp = new HttpClient();

            FormUrlEncodedContent conteudoDoCorpo = new FormUrlEncodedContent(new[] {
                 new KeyValuePair<string,string>("nome",chat.nome),
            });

            HttpResponseMessage respostaHttp = clienteHttp.PostAsync(endereco, conteudoDoCorpo).GetAwaiter().GetResult();

            if (respostaHttp.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public static bool RenomearChat(Chat chat)
        {
            var endereco = $"{EnderecoBase}/chat/{chat.id}";

            HttpClient clienteHttp = new HttpClient();

            FormUrlEncodedContent conteudoDoCorpo = new FormUrlEncodedContent(new[] {
                 new KeyValuePair<string,string>("nome",chat.nome),
            });

            HttpResponseMessage respostaHttp = clienteHttp.PutAsync(endereco, conteudoDoCorpo).GetAwaiter().GetResult();

            if (respostaHttp.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public static bool ExcluirChat(Chat chat)
        {
            var endereco = $"{EnderecoBase}/chat/delete/{chat.id}";

            HttpClient clienteHttp = new HttpClient();

            HttpResponseMessage respostaHttp = clienteHttp.DeleteAsync(endereco).GetAwaiter().GetResult();

            if (respostaHttp.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public static List<Mensagem> ObterMensagensChat(Chat chat)
        {
            var endereco = $"{EnderecoBase}/chat/{chat.id}/msg";

            HttpClient clienteHttp = new HttpClient();

            HttpResponseMessage respostaHttp = clienteHttp.GetAsync(endereco).GetAwaiter().GetResult();

            if (respostaHttp.IsSuccessStatusCode)
            {
                string conteudo = respostaHttp.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 2)
                {
                    return JsonConvert.DeserializeObject<List<Mensagem>>(conteudo);
                }
            }

            return null;
        }

        public static List<Mensagem> EnviarMensagem(Mensagem mensagem)
        {
            var endereco = $"{EnderecoBase}/chat/{mensagem.id_chat}/msg";

            HttpClient clienteHttp = new HttpClient();

            FormUrlEncodedContent conteudoDoCorpo = new FormUrlEncodedContent(new[] {
                 new KeyValuePair<string,string>("mensagem", mensagem.mensagem),
                 new KeyValuePair<string,string>("id_usuario", mensagem.id_usuario.ToString()),
            });

            HttpResponseMessage respostaHttp = clienteHttp.PostAsync(endereco, conteudoDoCorpo).GetAwaiter().GetResult();

            if (respostaHttp.IsSuccessStatusCode)
            {
                string conteudo = respostaHttp.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 2)
                {
                    return JsonConvert.DeserializeObject<List<Mensagem>>(conteudo);
                }
            }

            return null;
        }

        public static bool ExcluirMensagem(Mensagem mensagem)
        {
            var endereco = $"{EnderecoBase}/chat/{mensagem.id_chat}/delete/{mensagem.id}";

            HttpClient clienteHttp = new HttpClient();

            HttpResponseMessage respostaHttp = clienteHttp.DeleteAsync(endereco).GetAwaiter().GetResult();

            if (respostaHttp.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

    }
}
