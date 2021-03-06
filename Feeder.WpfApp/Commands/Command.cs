﻿using System;
using System.Windows.Input;

namespace Feeder.WpfApp.Commands
{
    public class Command : ICommand
    {
        #region Static and Readonly Fields

        private readonly Func<object, bool> canExecute;
        private readonly Action<object> execute;

        #endregion

        #region Constructors

        public Command(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        #endregion

        #region ICommand Members

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        #endregion
    }
}
