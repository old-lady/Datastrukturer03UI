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
            head = 0;
            tail = -1;
        }

        public bool IsFull => throw new NotImplementedException(); 


        public bool IsEmpty => throw new NotImplementedException();

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

        public int Count => throw new NotImplementedException();

        private int head;
        private int tail;
        public void Add(T elem)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T elem)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public T Remove()
        {
            throw new NotImplementedException();
        }

        public T[] ToArray()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
