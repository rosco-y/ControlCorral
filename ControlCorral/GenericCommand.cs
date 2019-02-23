using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ControlCorral
{
    class GenericCommand : ICommand
    {
        //public event EventHandler CanExecuteChanged;
        public event Action<string> DoSomething;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var command = parameter as string;
            DoSomething?.Invoke(command);
        }

    }
}
