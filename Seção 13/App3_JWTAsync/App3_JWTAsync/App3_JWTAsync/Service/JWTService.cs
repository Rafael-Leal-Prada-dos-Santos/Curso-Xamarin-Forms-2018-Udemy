using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using App3_JWTAsync.Model;

namespace App3_JWTAsync.Service
{
    public class JWTService
    {
        private static string enderecoBase = "http://ws.spacedu.com.br/xf2018/rest/apix";

        private static string Token;
        private static string TokenType;
        public static async Task<string> ObterToken(string nome, string senha) 
        {
            string url = enderecoBase + "/token";

            HttpClient clienteHttp = new HttpClient();

            FormUrlEncodedContent conteudoCodificado =
                new FormUrlEncodedContent(new[] {
                     new KeyValuePair<string, string>("nome", nome),
                     new KeyValuePair<string, string>("password", senha),
                });

            HttpResponseMessage respostaHTTP = 
                await clienteHttp.PostAsync(url, conteudoCodificado);

            if (respostaHTTP.IsSuccessStatusCode)
            {
                RespostaToken token = JsonConvert.DeserializeObject<RespostaToken>(respostaHTTP.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                Token = token.token_type + " " + token.access_token;
                TokenType = token.token_type;
                return Token;
            }
            else
            {
                return respostaHTTP.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
        }

        public static async Task<string> Verificar()
        {
            string url = enderecoBase + "/verify";

            HttpClient clienteHttp = new HttpClient();

            clienteHttp.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue(TokenType, Token);

            HttpResponseMessage respostaHTTP =
                await clienteHttp.GetAsync(url);

            if (respostaHTTP.IsSuccessStatusCode)
            {
                RespostaVerificar verificar = JsonConvert.DeserializeObject<RespostaVerificar>(respostaHTTP.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                return verificar.usuario.nome + " " + verificar.usuario.id;
            }
            else
            {
                return respostaHTTP.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
        }
    }
}
