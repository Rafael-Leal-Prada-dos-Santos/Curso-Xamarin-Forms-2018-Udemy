using App2_Tarefa.Modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2_Tarefa.Telas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage
    {
        private byte _prioridade { get; set; }
        public Cadastro()
        {
            InitializeComponent();
            entNome.Text = string.Empty;
        }

        private void Prioridade_Selecionado(object sender, EventArgs e)
        {
            TappedEventArgs args = e as TappedEventArgs;

            foreach (var item in slPrioridades.Children) 
            {
                if (item.GetType() == typeof(StackLayout)) 
                {
                    StackLayout stack = item as StackLayout;
                    Label lbl = stack.Children[1] as Label;
                    lbl.TextColor = Color.Gray;
                }
            } 
            
            StackLayout sl = sender as StackLayout;
            
            Label lblPrioridade = sl.Children[1] as Label;
            lblPrioridade.TextColor = Color.Black;

            _prioridade = byte.Parse(args.Parameter.ToString());
        }

        private async void Criar_Clicado(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(entNome.Text.Trim()))
            {
                await DisplayAlert("Erro", "Nome da tarefa não pode estar vazio. Insira o nome da tarefa", "OK");
                return;
            }

            if (!(_prioridade > 0))
            {
                await DisplayAlert("Erro", "Prioridade não foi selecionada. Selecione a prioridade", "OK");
                return;
            }

            Tarefa tarefa = new Tarefa()
            {
                Nome = entNome.Text.ToString(),
                Prioridade = _prioridade
            };

            new GerenciadorTarefa().Salvar(tarefa);

            lblMensagem.Text = new GerenciadorTarefa().ListarTodas().Count.ToString() + " tarefa(s) no total";

            App.Current.MainPage = new NavigationPage(new Inicio());

            //await Navigation.PopAsync();
        }
    }
}