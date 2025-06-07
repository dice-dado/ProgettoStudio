using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
     Anche se Riferimenti è una List<T>, la BindingList<T> costruita wrappa la lista esistente.
     I cambiamenti fatti nella DataGridView (righe editate o aggiunte) sono riversati nella BindingList, 
     che a sua volta modifica la List sottostante (perché il BindingList usa la stessa istanza).
 
     In WPF, non c'è propagazione delle modifiche tra le due liste, e la DataGrid lavora solo sulla nuova ObservableCollection. (Crea una nuova istanza)
 */


/*
    Non Serve gestire la modifica solo add/ remove non passa da CollectionChanged, gestita dal binding
 */

namespace UI_WpfApp.Helpers
{
    internal class ObservableListWrapper<T> : ObservableCollection<T>
    {
        private readonly IList<T> _backingList;

        public ObservableListWrapper(IList<T> list) : base(list)
        {
            _backingList = list ?? throw new ArgumentNullException(nameof(list));
            CollectionChanged += SyncToList;
        }

        private void SyncToList(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (_backingList == null)
                return;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (T item in e.NewItems)
                        _backingList.Add(item);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (T item in e.OldItems)
                        _backingList.Remove(item);
                    break;

                case NotifyCollectionChangedAction.Reset:
                    _backingList.Clear();
                    foreach (var item in this)
                        _backingList.Add(item);
                    break;

                case NotifyCollectionChangedAction.Replace:                    
                    break;

                case NotifyCollectionChangedAction.Move:   
                    break;
            }
        }
    }
}
