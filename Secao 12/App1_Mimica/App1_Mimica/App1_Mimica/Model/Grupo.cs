using App1_Mimica.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1_Mimica.Model
{
    public class Grupo : ViewModelBase
    {
        public string Nome { get; set; }

        public short Pontuacao { get; set; }
    }
}
