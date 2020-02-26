using System;
using System.Text;

namespace ClassLibraryDat03
{
    public class ListDat03<T>
    {
        public T[] TheList { get; set; } = new T[0];


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
            //T itemToIgnore = this.TheList[index];

            //foreach (T item in this.TheList)
            //{
            //    if(item )
            //}
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

    }
}
