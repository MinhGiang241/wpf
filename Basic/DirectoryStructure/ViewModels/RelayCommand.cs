using System;
using System.Windows.Input;

namespace WpfBasic
{
    public class RelayCommand : ICommand
    {
        public RelayCommand(Action action)
        {
        }

        private Action mAction;

        public event EventHandler? CanExecuteChanged;

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
