using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using App1_Vagas.Modelo;
using Xamarin.Forms;

namespace App1_Vagas.Banco
{
    public class BancoDeDados
    {
        private SQLiteConnection _conexao;

        public BancoDeDados() 
        {
            ICaminho dependencia = DependencyService.Get<ICaminho>();
            string caminho = dependencia.ObterCaminho("banco.sqlite");

            _conexao = new SQLiteConnection(caminho);
            _conexao.CreateTable<Vaga>();
        }

        public List<Vaga> Consultar()
        {
            return _conexao.Table<Vaga>().ToList();
        }

        public List<Vaga> Pesquisar(string palavra)
        {
            return _conexao.Table<Vaga>().Where(a => a.NomeVaga.ToUpper().Contains(palavra.ToUpper())).ToList();
        }

        public Vaga ObterVagaPorID(int id)
        {
            return _conexao.Table<Vaga>().FirstOrDefault(v => v.Id == id);
        }


        public void Cadastro(Vaga vaga) 
        {
            _conexao.Insert(vaga);
        }

        public void Atualizacao(Vaga vaga)
        {
            _conexao.Update(vaga);
        }

        public void Exclusao(Vaga vaga)
        {
            _conexao.Delete(vaga);
        }
    }
}
