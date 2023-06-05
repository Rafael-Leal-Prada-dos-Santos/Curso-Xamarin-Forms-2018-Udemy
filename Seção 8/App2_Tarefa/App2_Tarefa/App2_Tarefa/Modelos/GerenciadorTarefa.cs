using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace App2_Tarefa.Modelos
{
    public class GerenciadorTarefa
    {
        private List<Tarefa> Lista { get; set; }

        public GerenciadorTarefa() 
        {
            Lista = ListarTodas();
        }

        public void Salvar(Tarefa tarefa) 
        {
            Lista.Add(tarefa);

            SalvarNoProperties(Lista);
        }

        public void Deletar(int indice)
        {
            Lista.RemoveAt(indice);

            SalvarNoProperties(Lista);
        }
        public void Finalizar(int index, Tarefa tarefa) 
        {
            Lista.RemoveAt(index);

            tarefa.DataFinalizacao = DateTime.Now;
            Lista.Add(tarefa);

            SalvarNoProperties(Lista);
        }

        public List<Tarefa> ListarTodas() 
        {
            return ListagemNoProperties();
        }

        private void SalvarNoProperties(List<Tarefa> lista) 
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                App.Current.Properties.Remove("Tarefas");
            }

            string listaJSON = JsonConvert.SerializeObject(lista);

            App.Current.Properties.Add("Tarefas", listaJSON);
        }

        private List<Tarefa> ListagemNoProperties() 
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                string json = (string)App.Current.Properties["Tarefas"];

                List<Tarefa> lista = JsonConvert.DeserializeObject<List<Tarefa>>(json);

                //return App.Current.Properties["Tarefas"] as List<Tarefa>;
                return lista;
            }

            return new List<Tarefa>();
        }
    }
}
