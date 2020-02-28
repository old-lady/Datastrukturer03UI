using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace ClassLibraryDat03
{
    public class BufferObservable<T> : Buffer<T>, INotifyCollectionChanged
    {
        public BufferObservable(uint MaxSize) : base(MaxSize)
        {
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        private NotifyCollectionChangedEventArgs e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);

        public new void Add(T item)
        {
            base.Add(item);
            CollectionChanged?.Invoke(this, e); 
        }

        public new T Remove()
        {
            T temp = base.Remove();
            CollectionChanged?.Invoke(this, e);
            return temp;
        }

        public new void Clear()
        {
            base.Clear();
            CollectionChanged?.Invoke(this, e);

        }

    }
}
