using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryDat03
{
    public interface ISetDat03<T> : IEnumerable<T> 
    {
        int Count { get; }
        void Add(T elem);
        void Remove(T elem);
        bool Contains(T elem);


        // Returnerer foreningsmængden af denne mængde og mængden S. 
        ISetDat03<T> Union(ISetDat03<T> S);

        // Returnerer fællesmængden af denne mængde og mængden S. 
        ISetDat03<T> Intersect(ISetDat03<T> S);

        // Returnerer mængdedifferencen af denne mængde og mængden S. 
        ISetDat03<T> Difference(ISetDat03<T> S);
    }
}
