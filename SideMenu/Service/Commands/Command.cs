using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SideMenu.Service
{
    public class Command : ICommand
    {
        protected Action<object> _action;
        
        protected object _parameter;

        public Command()
        {

        }

        public Command(object parameter)
        {
            _parameter = parameter;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action.Invoke(_parameter);
        }
    }
}
