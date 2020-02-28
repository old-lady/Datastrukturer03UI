using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.ComponentModel;


namespace ClassLibraryDat03
{

    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;
        //        {
        //            add { CommandManager.RequerySuggested += value; }
        //remove { CommandManager.RequerySuggested -= value; }
        //        }

        private Func<object, bool> canExecute;
        private Action<object> execute;

        public Command(Func<object, bool> canExecute, Action<object> execute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }

}
