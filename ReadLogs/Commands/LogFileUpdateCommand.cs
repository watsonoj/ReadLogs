using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReadLogs.ViewModels;

namespace ReadLogs.Commands
{
    internal class LogFileUpdateCommand : ICommand
    {
        public LogFileUpdateCommand(LogFileViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        private LogFileViewModel _viewModel;

        #region ICommand Members
        public bool CanExecute(object parameter)
        {
            //throw new NotImplementedException();
            return _viewModel.CanUpdate;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            //throw new NotImplementedException();
            _viewModel.NewFile();
        }

        #endregion
    }
}
