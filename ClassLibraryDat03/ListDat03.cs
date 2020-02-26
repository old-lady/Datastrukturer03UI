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
        private void MakeBigger()
        {

        }
        private void MakeSmall()
        {

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
