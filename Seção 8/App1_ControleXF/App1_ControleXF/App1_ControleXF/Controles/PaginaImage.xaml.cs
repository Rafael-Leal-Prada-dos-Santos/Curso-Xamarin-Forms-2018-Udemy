using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_ControleXF.Controles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaImage : ContentPage
    {
        public PaginaImage()
        {
            InitializeComponent();

            Image imagem = new Image();

            imagem.Source = ImageSource.FromFile("ValorantEmblem.png");

            if (Device.RuntimePlatform == Device.UWP) 
            {
                //imagem.Source = ImageSource.FromFile("Valorant-Emblem.png");
            }


            container.Children.Add(imagem);

        }
    }
}