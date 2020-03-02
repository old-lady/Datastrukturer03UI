using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace ClassLibraryDat03
{
    public class BufferItem : ObservableObject
    {
        public string TheString { get; set; }
        private bool tail;
        public bool Tail
        {
            get
            {
                return tail;
            }
            set
            {
                tail = value;
                ChangeColor();

                OnPropertyChanged();
            }
        }

        private void ChangeColor()
        {
            if (Tail == true && Head == true)
            {
                // there is one element
                // no specific color yet
            }
            if (Head == true)
            {
                MyColor = new SolidColorBrush(Colors.Red);
                return;
            }

            if (Tail == true)
            {
                MyColor = new SolidColorBrush(Colors.ForestGreen);
                return;
            }
            MyColor = new SolidColorBrush(Colors.DarkGray);

        }

        private bool head;
        public bool Head
        {
            get
            {
                return head;
            }
            set
            {
                head = value;
                ChangeColor();
                OnPropertyChanged();
            }
        }
        public SolidColorBrush MyColor { get; set; } = new SolidColorBrush(Colors.DarkGray);

        // colors:

        public SolidColorBrush NotInBuffer { get; set; } = new SolidColorBrush(Colors.DarkGray);
        public SolidColorBrush InBuffer { get; set; } = new SolidColorBrush(Colors.DarkGoldenrod);
        public SolidColorBrush IsHead { get; set; } = new SolidColorBrush(Colors.Red);
        public SolidColorBrush IsTail { get; set; } = new SolidColorBrush(Colors.ForestGreen);
        

        public BufferItem(string theString)
        {
            TheString = theString;
        }

        public override string ToString()
        {
            return TheString;
        }
    }
}
