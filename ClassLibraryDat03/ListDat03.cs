using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryDat03
{
    public class ListDat03<T> : IEnumerable<T>
    {
        private T[] TheList { get; set; } = new T[0];


        #region Unique to this
        public int Count
        {
            get
            {
                return TheList.Length;
            }
        }


        public void Add(T onj)
        {
            T[] newList = new T[Count + 1];
            TransferTs(newList);
            newList[newList.Length - 1] = onj;
            TheList = newList;
        }
        public void Add(params T[] items)
        {
            foreach (T item in items)
            {
                Add(item);
            }
        }
        //public IEnumerator Test()
        //{
        //    for (int i = 0; i < TheList.Length; i++)
        //    {
        //        yield return i;
        //    }
        //}
        //public int[] Test2()
        //{
        //    int[] temp = new int[TheList.Length];
        //    for (int i = 0; i < temp.Length; i++)
        //    {
        //        temp[i] = i;
        //    }
        //    return temp;
        //}



        public void Clear()
        {
            TheList = new T[0];
        }


        public void RemoveAt(int index)
        {

            if (index <= 0 || index > Count - 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            RemoveFromList(index);


        }
        private void RemoveFromList(int index)
        {
            T[] temp = new T[this.Count - 1];

            for (int i = 0; i < temp.Length; i++)
            {
                if (i == index) continue;
                if (i > index)
                {
                    temp[i - 1] = this.TheList[i];
                    continue;
                }
                temp[i] = this.TheList[i];
            }
            this.TheList = temp;

        }

        private void TransferTs(T[] newList)
        {
            for (int i = 0; i < TheList.Length; i++)
            {
                newList[i] = TheList[i];
            }
        } 
        #endregion
        #region Ienumerator

        public IEnumerator GetEnumerator()
        {
            foreach (object item in TheList)
            {
                if (item == null) break;
                yield return item;
            }
        }

        //magic
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {

            foreach (T item in TheList)
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
