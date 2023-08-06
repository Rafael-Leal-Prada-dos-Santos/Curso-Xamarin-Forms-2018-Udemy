using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using App1_NossoChat.Model;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace App1_NossoChat.Service
{
    public class ServicoWS
    {
        private static string EnderecoBase = $"http://ws.spacedu.com.br/xf2018/rest/api";

        public static async Task<Usuario> ObterUsuario(Usuario usuario) 
        {
            var endereco = $"{EnderecoBase}/usuario";

            HttpClient clienteHttp = new HttpClient();

            //FormUrlEncodedContent param = new FormUrlEncodedContent(new[] {
            //     new KeyValuePair<string,string>("nome",usuario.nome),
            //     new KeyValuePair<string,string>("password", usuario.password),
            //});

            StringContent parametros = new StringContent($"?nome={usuario.nome}&password={usuario.password}");

            // PostAsync(url, parametros);

            //HttpResponseMessage respostaHttp =  clienteHttp.PostAsync(endereco , parametros).GetAwaiter().GetResult();

            HttpResponseMessage respostaHttp = await clienteHttp.PostAsync(endereco, parametros);

            if (respostaHttp.IsSuccessStatusCode) 
            {
                string json = respostaHttp.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return JsonConvert.DeserializeObject<Usuario>(json);
            }

            return null;
        }

        public static async Task<List<Chat>> ObterListaDeConversas()
        {
            var endereco = $"{EnderecoBase}/chats";

            HttpClient clienteHttp = new HttpClient();

            // PostAsync(url, parametros);

            HttpResponseMessage respostaHttp = 
                await clienteHttp.GetAsync(endereco);

            if (respostaHttp.IsSuccessStatusCode)
            {
                string conteudo = respostaHttp.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                if (conteudo.Length > 2)
                {
                    return JsonConvert.DeserializeObject<List<Chat>>(conteudo);
                }
                else
                {
                    return null;
                }
            }
            else 
            {
                throw new Exception("Código de erro HTTP" + respostaHttp.StatusCode)
            }
            return null;
        }

        public static async Task<bool> CriarChat(Chat chat)
        {
            var endereco = $"{EnderecoBase}/chat";

            HttpClient clienteHttp = new HttpClient();

            FormUrlEncodedContent conteudoDoCorpo = new FormUrlEncodedContent(new[] {
                 new KeyValuePair<string,string>("nome",chat.nome),
            });

            HttpResponseMessage respostaHttp = await clienteHttp.PostAsync(endereco, conteudoDoCorpo);

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

        public static async Task<List<Mensagem>> ObterMensagensChat(Chat chat)
        {
            var endereco = $"{EnderecoBase}/chat/{chat.id}/msg";

            HttpClient clienteHttp = new HttpClient();

            HttpResponseMessage respostaHttp = clienteHttp.GetAsync(endereco).GetAwaiter().GetResult();

            if (respostaHttp.IsSuccessStatusCode)
            {
                string conteudo = await respostaHttp.Content.ReadAsStringAsync();

                if (conteudo != null) 
                {
                    if (conteudo.Length > 2)
                    {
                        return JsonConvert.DeserializeObject<List<Mensagem>>(conteudo);
                    }
                    else 
                    {
                        return null;
                    }
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

                if (conteudo != null)
                {
                    if (conteudo.Length > 2)
                    {
                        return JsonConvert.DeserializeObject<List<Mensagem>>(conteudo);
                    }
                    else 
                    {
                        return null;
                    }
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
