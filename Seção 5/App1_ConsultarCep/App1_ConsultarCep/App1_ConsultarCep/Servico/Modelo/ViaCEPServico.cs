using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App1_ConsultarCep.Servico.Modelo;
using Newtonsoft.Json;

namespace App1_ConsultarCep.Servico.Modelo
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep) 
        {
            string novoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(novoEnderecoURL);

            Endereco endereco = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if (endereco.cep == null) return null;

            return endereco;
        }
    }
}
