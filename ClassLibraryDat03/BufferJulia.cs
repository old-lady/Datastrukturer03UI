using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryDat03
{
    public class BufferJulia<T> : IBuffer<T>
    {
        // the one and only buffer
        public T[] theBuffer = new T[0];

        // checks if the current count of objects in buffer is equal to its maxsize
        public bool IsFull
        {
            get
            {
                
                if (Count == MaxSize) return true;
                return false;
            }
        }

        // checks if there is anything in the buffer
        public bool IsEmpty
        {
            get
            {
                if (Count == 0) return true;
                return false;
            }
        }

        // the max items that can fit into this buffer
        public int MaxSize { get; }

        public int Count => HowManySpotsAreFilled();


        private int HowManySpotsAreFilled()
        {
            // check if it is empty
            if (tail == -1) return 0;
            // if tail if bigger then head
            if(tail - head > 0)
            {
                return (tail - head) + 1;
            }
            // if tail is smaller then head (we have passed zero an uneven times)
            if (tail - head < 0) return (tail - head) - 1;
            //if (tail - head == 0) return 1;
            // last posibility is that head and tail have same index, so there is only one element in the buffer
            return 1;


            // only works for ref types (nullable types)
            //int count = 0;
            //foreach (T item in theBuffer)
            //{
            //    if (item != null) count++;
            //}
            //return count;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size"></param>
        public BufferJulia(uint size)
        {
            // nothing in the buffer, so tail is not on the array
            tail = -1;
            // head is at index zero, ready to be filled
            head = 0;

            //if (size <= 0) size = 1;
            theBuffer = new T[size];
            MaxSize = theBuffer.Length;
        }


        // TODO: what if it increments by more then 1? :/
        // where do I find the first element
        private int head;
        private int Head
        {
            get
            {
                return head;
            }
            set
            {
                if (value > MaxSize - 1) head = 0;
                else head = value;
            }
        }
        // where do I find the last element
        private int tail;
        private int Tail
        {
            get
            {
                return tail;
            }
            set
            {
                if (value > MaxSize - 1) tail = 0;
                else tail = value;
            }
        }

        // we add a single element
        public void Add(T elem)
        {
            // we check if array has a length bigger then zero
            if (MaxSize <= 0) throw new Exception("This array cannot hold elements. Its size is zero.");

            // we check if there is space:
            if (IsFull) throw new Exception("The array is full. Clear or remove elements to add new ones");

            // first we check if we are empty
            // if we are we set head to zero, tail to zero and add the element at 0 index
            if (IsEmpty)
            {
                head = 0;
                tail = 0;
                theBuffer[tail] = elem;
            }
            else
            {
                // we move the tail
                Tail++;
                // add the element there
                theBuffer[tail] = elem;
            }




            //if (this.IsFull) throw new Exception("The buffer is full");
            //if(tail == head && )
            //theBuffer[Tail + 1] = elem;
            //Console.WriteLine($"Added element {elem} at position {tail}");
            //Tail++;
            //Console.WriteLine($"Tail is now {tail}");
        }

        public void Clear()
        {
            int temp = MaxSize;
            theBuffer = new T[temp];
        }

        public bool Contains(T elem)
        {
            foreach (T item in this)
            {
                // why cant == be aplied between types of T?
                if (EqualityComparer<T>.Default.Equals(elem, item)) return true;
                //if (BufferJulia<T>.Equals(elem, item)) return true;
            }
            return false;
        }

        //removes first element
        public T Remove()
        {
            if (Count == 0) throw new ArgumentOutOfRangeException("No elements to remove");
            T result = theBuffer[Head];

            // this fucks with the size...
            //theBuffer[Head] = null;
            if(this.Count != 0) Head++;
            return result;
            

        }

        // TODO: fix this!
        public T[] ToArray()
        {
            T[] resultArray = new T[MaxSize];
            // checks needed for negative numbers!
            for (int i = head; i < tail; i++)
            {
                

            }
            return null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in theBuffer)
            {
                //if (item == null) break;
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (object item in theBuffer)
            {
                //if (item == null) break;
                yield return item;
            }
        }
    }
}
