using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryDat03
{
    public class Set<T> : ISetDat03<T>
    {
        public List<T> TheList { get; private set; } = new List<T>();

        public int Count => TheList.Count;

        public void Add(T elem)
        {
            if (TheList.Contains(elem)) return;
            TheList.Add(elem);
        }

        public bool Contains(T elem)
        {
            return TheList.Contains(elem);
        }

        public void Remove(T elem)
        {
            if (!TheList.Contains(elem)) return;
            TheList.Remove(elem);
        }

        public ISetDat03<T> Difference(ISetDat03<T> S)
        {
            Set<T> result = new Set<T>();
            foreach(T item in S)
            {
                if (!TheList.Contains(item))
                {
                    result.Add(item);
                }
            }
            foreach (T item in this)
            {
                if (!S.Contains(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }


        public ISetDat03<T> Intersect(ISetDat03<T> S)
        {
            Set<T> result = new Set<T>();

            foreach (T item in S)
            {
                if (TheList.Contains(item))
                {
                    result.Add(item);
                }
            }

            return result;

        }

        public ISetDat03<T> Union(ISetDat03<T> S)
        {

            Set<T> result = new Set<T>();
            foreach (T item in S)
            {
                result.Add(item);
            }
            foreach (T item in TheList)
            {
                result.Add(item);
            }

            return result;

        }


        
        #region IEnumerator

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in TheList)
            {
                if (item == null) break;
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (object item in TheList)
            {
                if (item == null) break;
                yield return item;
            }
        }

        public T this[int index]
        {
            get
            {
                return TheList[index];
            }
            set
            {
                TheList[index] = value;
            }
        }
        #endregion
    }
}
