using App1_Vagas.Banco;
using App1_Vagas.Modelo;
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
    public partial class CadastroVaga : ContentPage
    {
        ConsultaVagas _paginaConsulta = null;
        MinhaVagasCadastradas _paginaVagasCadastradas = null;
        private bool _ehEdicao;
        private Vaga _VagaEdicao { get; set; }

        public CadastroVaga(ConsultaVagas pagConsulta)
        {
            InitializeComponent();
            _paginaConsulta = pagConsulta;

            _ehEdicao = false;
        }
        public CadastroVaga(MinhaVagasCadastradas pag, Vaga vaga)
        {
            InitializeComponent();
            _paginaVagasCadastradas = pag;

            _ehEdicao = true;

            _VagaEdicao = vaga;

            PreencherDadosEdicao();
        }


        private void PreencherDadosEdicao() 
        {
            try
            {
                NomeVaga.Text = _VagaEdicao.NomeVaga;
                Quantidade.Text  = _VagaEdicao.Quantidade.ToString();
                Salario.Text = _VagaEdicao.Salario.ToString();
                Empresa.Text = _VagaEdicao.Empresa;
                Cidade.Text = _VagaEdicao.Cidade;
                Descricao.Text = _VagaEdicao.Descricao;
                TipoContratacao.IsToggled = _VagaEdicao.TipoContratacao.Equals("CLT") ? false : true; 
                Telefone.Text = _VagaEdicao.Telefone;
                Email.Text = _VagaEdicao.Email;
            }
            catch (Exception ex) 
            {
                DisplayAlert("Erro", "Não foi possível preencher os dados da edição", "OK");
            }
        }

        private bool DadosEstaoValidos() 
        {
            bool valido = true;


             if (string.IsNullOrWhiteSpace(NomeVaga.Text) ||
                 string.IsNullOrWhiteSpace(Quantidade.Text) ||
                 string.IsNullOrWhiteSpace(Salario.Text) ||
                 string.IsNullOrWhiteSpace(Empresa.Text) ||
                 string.IsNullOrWhiteSpace(Cidade.Text) ||
                 string.IsNullOrWhiteSpace(Descricao.Text) ||
                 string.IsNullOrWhiteSpace(Telefone.Text) ||
                 string.IsNullOrWhiteSpace(Email.Text)) 
            {
                return false;
            }


            return valido;
        }

        private void Salvar_Clicado(object sender, EventArgs e)
        {
            try
            {
                //TODO - Validar Dados
                bool dadosSaoValidos = DadosEstaoValidos();

                if (!dadosSaoValidos)
                {
                    _ = DisplayAlert("Aviso", "Preencha todos os campos para poder prosseguir", "OK");
                    return;
                }

                if (!_ehEdicao)
                {
                    Vaga novaVaga = new Vaga();

                    novaVaga.NomeVaga = NomeVaga.Text;
                    novaVaga.Quantidade = short.Parse(Quantidade.Text);
                    novaVaga.Salario = double.Parse(Salario.Text);
                    novaVaga.Empresa = Empresa.Text;
                    novaVaga.Cidade = Cidade.Text;
                    novaVaga.Descricao = Descricao.Text;
                    novaVaga.TipoContratacao = TipoContratacao.IsToggled ? "PJ" : "CLT";
                    novaVaga.Telefone = Telefone.Text;
                    novaVaga.Email = Email.Text;

                    //TODO - Salvar Informações no Banco

                    BancoDeDados banco = new BancoDeDados();
                    banco.Cadastro(novaVaga);

                    //TODO - Obter dados da tela
                    _paginaConsulta.AtualizarDados();
                }
                else 
                {
                    _VagaEdicao.NomeVaga = NomeVaga.Text;
                    _VagaEdicao.Quantidade = short.Parse(Quantidade.Text);
                    _VagaEdicao.Salario = double.Parse(Salario.Text);
                    _VagaEdicao.Empresa = Empresa.Text;
                    _VagaEdicao.Cidade = Cidade.Text;
                    _VagaEdicao.Descricao = Descricao.Text;
                    _VagaEdicao.TipoContratacao = TipoContratacao.IsToggled ? "PJ" : "CLT";
                    _VagaEdicao.Telefone = Telefone.Text;
                    _VagaEdicao.Email = Email.Text;

                    BancoDeDados banco = new BancoDeDados();
                    banco.Atualizacao(_VagaEdicao);

                    _paginaVagasCadastradas.AtualizarDados();
                }

                

                //TODO - Voltar para tela de pesquisa
                _ = Navigation.PopAsync();
            }
            catch (Exception ex)
            {

            }
            
        }
    }
}