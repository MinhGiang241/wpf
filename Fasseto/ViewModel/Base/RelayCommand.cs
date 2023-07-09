using System;
using System.Windows.Input;

namespace Fasseto
{
    public class RelayCommand : ICommand
    {
        public RelayCommand(Action action)
        {
            mAction = action;
        }

        private Action mAction;

        public event EventHandler? CanExecuteChanged = (sender, e) => { };

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            mAction();
        }
    }
}
