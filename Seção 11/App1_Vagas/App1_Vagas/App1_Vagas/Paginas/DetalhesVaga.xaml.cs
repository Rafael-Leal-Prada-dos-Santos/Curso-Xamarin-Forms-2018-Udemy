﻿using App1_Vagas.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Vagas.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalhesVaga : ContentPage
    {
        public DetalhesVaga(Vaga vaga)
        {
            InitializeComponent();

            BindingContext = vaga;

            DisplayAlert("Mensagem", vaga.NomeVaga, "OK");
        }
    }
}