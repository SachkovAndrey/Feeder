using System.Windows.Input;
using Caliburn.Micro;
using Feeder.WpfApp.Commands;

namespace Feeder.WpfApp.ViewModels
{
    public class ErrorViewModel : Screen
    {
        #region Static and Readonly Fields

        private readonly ICommand dismissCommand;

        #endregion

        #region Constructors

        public ErrorViewModel(ICommand dismissCommand, string error)
        {
            this.dismissCommand = dismissCommand;
            Error = error;
        }

        #endregion

        #region Properties

        public ICommand DismissCommand => new Command(Dismiss);

        public string Error { get; private set; }

        #endregion

        #region Methods

        private void Dismiss(object parameter)
        {
            TryClose();
            dismissCommand.Execute(null);
        }

        #endregion
    }
}
