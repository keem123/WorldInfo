using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WorldInfoViewModel.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Action<object> execute { get; set; }
        Func<object,bool> canExecute { get; set; }
        public RelayCommand(Action<object> execute)
        {
            canExecute = (obj) => true;
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
