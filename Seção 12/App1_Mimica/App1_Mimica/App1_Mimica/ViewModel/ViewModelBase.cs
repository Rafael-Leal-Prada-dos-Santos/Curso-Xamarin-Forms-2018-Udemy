using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace App1_Mimica.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void PropriedadeMudada(string nomePropriedade) 
        {
            if (PropertyChanged != null) 
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nomePropriedade));
            }
        }
    }
}
