using App2_Tarefa.Modelos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2_Tarefa.Telas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicio : ContentPage
    {
        private enum NiveisPrioridade
        {
            normal = 1,
            importante = 2,
            critico = 3,
            urgente = 4
        }

        public Inicio()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            CultureInfo cultura = new CultureInfo("pt-BR");

            string data = DateTime.Now.ToString("dddd, dd {0} MMMM {0} yyyy", cultura);
            string dataHoje = string.Format(data, "de");
            lblDataAtual.Text = dataHoje;
            CarregarTarefas();
        }

        private void Adicionar_Clicado(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cadastro());
        }

        private void CarregarTarefas() 
        {
            slTarefas.Children.Clear();

            List<Tarefa> lista = new GerenciadorTarefa().ListarTodas();

            int i = 0;
            foreach (Tarefa tarefa in lista) {
                LinhasStackLayout(tarefa, i);
                i++;
            }
        }

        public void LinhasStackLayout(Tarefa tarefa, int indice) 
        {
            Image imgDelete = new Image()
            {
                VerticalOptions = LayoutOptions.Center,
                Source = ImageSource.FromFile("Delete.png")
            };

            TapGestureRecognizer tapDelete = new TapGestureRecognizer();
            tapDelete.Tapped += delegate
            {
                new GerenciadorTarefa().Deletar(indice);
                CarregarTarefas();
            };

            imgDelete.GestureRecognizers.Add(tapDelete);

            if (Device.RuntimePlatform == Device.UWP)
            {
                imgDelete.Source = ImageSource.FromFile("Resources/Delete.png");
            }

            Image imgPrioridade = new Image()
            {
                VerticalOptions = LayoutOptions.Center,
                Source = ImageSource.FromFile(Enum.GetName(typeof(NiveisPrioridade), tarefa.Prioridade) + ".png")
            };

            if (Device.RuntimePlatform == Device.UWP)
            {
                imgPrioridade.Source = ImageSource.FromFile("Resources/" + Enum.GetName(typeof(NiveisPrioridade), tarefa.Prioridade) + ".png");
            }

            View stackCentral = null;

            if (tarefa.DataFinalizacao == null)
            {
                stackCentral = new Label()
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Text = tarefa.Nome
                };
            }
            else 
            {
                stackCentral = new StackLayout()
                {
                    VerticalOptions= LayoutOptions.Center,
                    Spacing = 0,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };

                ((StackLayout)stackCentral).Children.Add(new Label()
                {
                    Text = tarefa.Nome,
                    TextColor = Color.Gray
                });

                ((StackLayout)stackCentral).Children.Add(new Label()
                {
                    Text = $"Finalizado em {tarefa.DataFinalizacao.Value.ToString("dd/MM/yyyy - hh:mm")}h",
                    TextColor = Color.Gray,
                    FontSize = 10
                });
            }

          

            Image imgCheck = new Image()
            {
                VerticalOptions = LayoutOptions.Center,
                Source = ImageSource.FromFile("CheckOff.png")
            };
            if (Device.RuntimePlatform == Device.UWP) 
            {
                imgCheck.Source = ImageSource.FromFile("Resources/CheckOff.png");
            }


            if (tarefa.DataFinalizacao != null) 
            {
                if (Device.RuntimePlatform == Device.UWP)
                {
                    imgCheck.Source = ImageSource.FromFile("Resources/CheckOn.png");
                }

                imgCheck.Source = ImageSource.FromFile("CheckOn.png");
            }
            

            TapGestureRecognizer tapCheck = new TapGestureRecognizer();
            tapCheck.Tapped += delegate
            {
                new GerenciadorTarefa().Finalizar(indice ,tarefa);
                CarregarTarefas();
            };

            imgCheck.GestureRecognizers.Add(tapCheck);



            StackLayout linha = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 15
            };

            linha.Children.Add(imgCheck);
            linha.Children.Add(stackCentral);
            linha.Children.Add(imgPrioridade);
            linha.Children.Add(imgDelete);

            slTarefas.Children.Add(linha);
        }
    }
}