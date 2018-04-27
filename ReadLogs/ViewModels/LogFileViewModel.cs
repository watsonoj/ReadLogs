using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadLogs.Models;
using ReadLogs.Commands;

namespace ReadLogs.ViewModels
{

    internal class LogFileViewModel
    {
        #region Field
        private LogFile _LogFile;

        #endregion

        public LogFileViewModel(){
            _LogFile = new LogFile("logfile.txt");
            UpdateCommand = new LogFileUpdateCommand(this);
        }        

        public LogFile LogFile{
            get{
                return _LogFile;
            }

        }

        public bool CanUpdate
        {
            get { return true; }
            //set;
        }

        public ICommand UpdateCommand
        {
            get;
            private set;
        }

        public void NewFile()
        {
            LogFile.FileName = "NewFileName.txt";
        }
    }
}
