using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryDat03
{
    interface ISetDat03<T> : IEnumerable<T>
    {
        int Cout { get; }
        void Add(T element);
        void Remove(T elem);
        bool Contains(T elem);


        // Returnerer foreningsmængden af denne mængde og mængden S. 
        ISet<T> Union(ISet<T> S);

        // Returnerer fællesmængden af denne mængde og mængden S. 
        ISet<T> Intersect(ISet<T> S);

        // Returnerer mængdedifferencen af denne mængde og mængden S. 
        ISet<T> Difference(ISet<T> S);
    }
}
