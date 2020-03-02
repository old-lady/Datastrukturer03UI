using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace ClassLibraryDat03
{
    public class ViewModel : BaseViewModel
    {

        private int count;
        public int Count 
        {
            get { return count; }
            private set
            {
                count = value;
                OnPropertyChanged();
            } 
        }

        public BufferObservable<BufferItem> buffer { get; set; }
        public ObservableCollection<BufferItem> Buffer { get; set; }

        public string TextToBeAdded { get; set; }
        public ICommand Add { get; set; }
        public ICommand Remove { get; set; }

        // hjælpe ting
        private RandomGenerator RandomGenerator = new RandomGenerator();

        /// <summary>
        /// Constuctor
        /// </summary>
        public ViewModel()
        {
            buffer = new BufferObservable<BufferItem>(5);
            Buffer = new ObservableCollection<BufferItem>();
            Add = new Command(AlwaysTrue, Add_Command_ExecuteMethod);
            Remove = new Command(AlwaysTrue, Remove_Command_ExecuteMethod);
        }

        private void ShadowPlay()
        {
            Buffer.Clear();
            foreach (BufferItem item in buffer.theBuffer)
            {
                Buffer.Add(item);
            }
            ShadowPlay_UpdateIndex();
            ShadowPlay_UpdateIfInBuffer();
            Count = buffer.Count;

        }

        private void ShadowPlay_UpdateIfInBuffer()
        {
            foreach (var item in buffer.theBuffer)
            {
                if (item == null) continue;
                if (item.Head == true || item.Tail == true) continue;
                if (buffer.Contains(item))
                {
                    item.MyColor = item.InBuffer;
                }
                else
                {
                    item.MyColor = item.NotInBuffer;
                }

            }
        }

        private void ShadowPlay_UpdateIndex()
        {

            // unødvendigt?
            if (buffer.Tail == -1)
            {
                foreach (var item in buffer.theBuffer)
                {
                    if (item == null) continue;
                    item.Tail = false;
                }
            }
            for (int i = 0; i < buffer.theBuffer.Length; i++)
            {
                if (buffer.theBuffer[i] == null) continue;
                if(buffer.Head == i)
                {
                    buffer.theBuffer[i].Head = true;
                }
                else
                {
                    buffer.theBuffer[i].Head = false;

                }

                if (buffer.Tail == i)
                {
                    buffer.theBuffer[i].Tail = true;
                }
                else
                {
                    buffer.theBuffer[i].Tail = false;

                }


            }

        }

        private bool AlwaysTrue(object obj)
        {
            return true;
            //if (Buffer.IsEmpty) return true;
            //else return false;
        }

        private void Add_Command_ExecuteMethod(object obj)
        {

            if (buffer.IsFull == true)
            {
                return;
            }

            string fruit = RandomGenerator.GenerateFruit();

            var newItem = new BufferItem(fruit);
            //var newItem = new BufferItem(TextToBeAdded);

            buffer.Add(newItem);
            ShadowPlay();
        }
        private void Remove_Command_ExecuteMethod(object obj)
        {
            if (buffer.IsEmpty)
            {
                return;
            }

            buffer.Remove();
            ShadowPlay();

        }
    }
}
