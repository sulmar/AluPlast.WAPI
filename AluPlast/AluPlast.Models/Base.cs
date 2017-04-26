using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AluPlast.Models
{

    public abstract class GenericBase<TKey>
    {
        public virtual TKey Id { get; set; }
    }

    public abstract class Base : GenericBase<int>, INotifyPropertyChanged, INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }

        public void OnCollectionChanged(object item)
        {
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
        }

       


    }
}
