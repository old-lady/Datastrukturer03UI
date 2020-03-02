using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClassLibraryDat03
{
    /// <summary>
    /// A base class that implements INotifyPropertyChanged interface
    /// It has a method to trigger the event, by feeding it a property name(eventargs!)
    /// and object that is triggering it (sender!)
    /// </summary>

    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        /* This is a build in event. 
         * An event is a special delegate, that encapsulate the use of it for events
         * Think of delegates as fields and events like properties
         * 
         * delegate signature for this event:
         * void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e);
         * sender = the object where the property that has changed is, so we can use 'this' in most cases
         * PropertyChangedEventArgs = class that has the information about the property that has changed (only name actually, that is littery all this class does. Keeps track of one string...)
         */

        //public int dfgdf { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        

        /* This is just a method, nothing more
         * It does one thing only
         * it triggers the event
         * yup, is all it does
         * really
         * 
         * Now it has one funny thing, it has a parameter decleration of the CallerMemberNameAttribute type
         * this basicaly asks the compiler at run time, what the name of the method that called this is.
         * You give it a default value, so that in case the compiler fails, it knows what to fall back on (and no, it is not a choice, you have to)
         * no hardcoding of names of methods as string for us anymore, hurray!
         */
        public void OnPropertyChanged([CallerMemberName]string caller = null)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));


            //----------- deconstruction for better understanding (Uncomment the next few lines) ----------

            //// it first makes a null check - sees if any methods are subscribed to the event
            //// if there are subscribers, it fires the event and all methods subscribed to it get a move on
            //PropertyChangedEventHandler handler = PropertyChanged;
            //if (handler != null)
            //{
            //    handler(this, new PropertyChangedEventArgs(caller));
            //}
        }

        //************************COMANDS*********************************//


    }
}
