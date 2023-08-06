using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace App1_NossoChat.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private bool _carregando;
        private bool _exibeMensagemErro;

        public bool Carregando 
        {
            get => _carregando;
            set => DefiniorValorPropriedade(ref _carregando, value);
        }

        public bool ExibeMensagemErro
        {
            get => _exibeMensagemErro;
            set => DefiniorValorPropriedade(ref _exibeMensagemErro, value);
        }

        public ViewModelBase()
        {
            _carregando = false;
            _exibeMensagemErro = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void AtualizarPropriedade(string propriedade) 
        {
            if (PropertyChanged != null) 
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propriedade));
            }
        }

        public bool DefiniorValorPropriedade<T>(ref T valorVariavelReferencia, T novoValor, [CallerMemberName] string nomePropriedade = null)
        {
            if (Equals(valorVariavelReferencia, novoValor))
                return false;

            valorVariavelReferencia = novoValor;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomePropriedade));

            return true;
        }
    }
}
