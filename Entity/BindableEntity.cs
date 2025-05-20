using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class BindableEntity : INotifyPropertyChanged
    {
        //i controlli della UI si sottoscrivo in automatico a questo event
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaiseNotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
