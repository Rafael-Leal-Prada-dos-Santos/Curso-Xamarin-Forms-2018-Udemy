using App1_NossoChat.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1_NossoChat.Util
{
    public class UsuarioUtil
    {
        public static Usuario ObterUsuarioLogado()
        {
            if (App.Current.Properties.ContainsKey("LOGIN")) 
            {
                return JsonConvert.DeserializeObject<Usuario>((string)App.Current.Properties["LOGIN"]);

            }
            else 
            {
                return null;
            }
           
        }

        public static void DefinirUsuarioLogado(Usuario usuario)
        {
            App.Current.Properties["LOGIN"] = JsonConvert.SerializeObject(usuario);
        }
    }
}
