using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryDat03
{
    public class Buffer<T> : IBuffer<T>
    {
        public T[] theBuffer;


        public Buffer(uint MaxSize)
        {
            this.MaxSize = (int)MaxSize;
            theBuffer = new T[MaxSize];
            head = 0;
            tail = -1;
        }

        public bool IsFull
        {
            get
            {
                //return (Count >= MaxSize) ? true : false;

                //return head == (tail + 1) % MaxSize;
                if (Count >= MaxSize)
                {
                    return true;
                }
                return false;
            }
        }


        public bool IsEmpty
        {
            get
            {
                if (Count == 0)
                {
                    return true;
                }
                return false;
            }
        }

        private int maxSize;
        public int MaxSize
        {
            get
            {
                return maxSize;
            }
            set
            {
                maxSize = value;
            }
        }

        public int Count
        {
            get
            {
                if (tail == -1)
                {
                    return 0;
                }
                if (head > tail)
                {
                    return MaxSize - (head - tail) + 1;
                }
                else
                {
                    return tail - head + 1;
                }

            }
        }

        private int head;
        public int Head
        {
            get
            {
                return head;
            }
        }
        private int tail;
        public int Tail
        {
            get
            {
                return tail;
            }
        }
        public void Add(T elem)
        {
            if (IsFull)
            {
                throw new Exception("The Buffer is full");
            }

            tail = (tail + 1) % MaxSize;
            theBuffer[tail] = elem;

        }

        public void Clear()
        {
            tail = -1;
            head = 0;
        }

        public bool Contains(T elem)
        {
            foreach (T item in this.ToArray())
            {
                Console.WriteLine(item);
                if (item == null)
                {
                    Console.WriteLine("We have null");
                }
                if (EqualityComparer<T>.Default.Equals(elem, item)) return true;
                //if (item.Equals(elem)) return true;

            }
            return false;
        }


        public T Remove()
        {
            if (IsEmpty)
            {
                throw new Exception("The buffer is empty");
            }
            T temp = theBuffer[head];
            if (Count == 1)
            {
                tail = -1;
                head = 0;
                //head = (head) % MaxSize;
                return temp;
            }
            head = (head + 1) % MaxSize;

            return temp;
        }

        public T[] ToArray()
        {

            T[] results = new T[Count];
            if (tail == -1)
            {
                return new T[0];
            }
            if (tail == head)
            {
                results[0] = theBuffer[tail];
                return results;
            }
            if (tail > head)
            {
                int j = 0;
                for (int i = head; i <= tail; i++)
                {
                    results[j] = theBuffer[i];
                    j++;
                }
                return results;
            }
            if (tail < head)
            {
                int j = 0;
                for (int i = head; i != tail; i++)
                {
                    results[j] = theBuffer[i % MaxSize];
                    i = i % MaxSize;
                    j++;
                }
                if (IsFull)
                {
                    results[Count - 1] = theBuffer[tail];
                }
                return results;
            }

            return null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in this.ToArray())
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (object item in this.ToArray())
            {
                yield return item;
            }
        }

        public T this[int index]
        {
            get
            {
                return this.ToArray()[index];
            }
            set
            {
                this.ToArray()[index] = value;
            }
        }
    }
}
