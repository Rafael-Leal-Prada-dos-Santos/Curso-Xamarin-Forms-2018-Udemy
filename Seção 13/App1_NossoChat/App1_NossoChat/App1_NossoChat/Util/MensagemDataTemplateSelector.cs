using App1_NossoChat.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1_NossoChat.Util
{
    public class MensagemDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MensagemUsuarioTemplate { get; set; }
        public DataTemplate MensagemOutroUsuarioTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            Usuario usuarioLogado = UsuarioUtil.ObterUsuarioLogado();

            Mensagem mensagemAColocarTemplate = item as Mensagem;

            if (item != null) 
            {
                if (mensagemAColocarTemplate.id_usuario == usuarioLogado.id)
                {
                    return MensagemUsuarioTemplate;
                }
                else 
                {
                    return MensagemOutroUsuarioTemplate;
                }
            }

            return null;
        }
    }
}
