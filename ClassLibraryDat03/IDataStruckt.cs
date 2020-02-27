using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryDat03
{
    public interface IDataStruckt<T> : IEnumerable<T>
    {
        int Count { get; }
        bool Contains(T elem); void Clear();
        T[] ToArray();
    }
}
