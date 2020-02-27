using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryDat03
{
    public interface IBuffer<T>: IDataStruckt<T>
    {
        bool IsFull { get; }
        bool IsEmpty { get; }
        int MaxSize { get; }
        void Add(T elem);
        T Remove();
    }
}
