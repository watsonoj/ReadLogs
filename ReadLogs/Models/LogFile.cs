using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadLogs.Models
{
    public class LogFile : INotifyPropertyChanged
    {

        #region Fields
        private string _FileName;

        #endregion

        #region Constructor
        ///<summary>
        /// Initialize new instance of the LogFile class
        /// <summary>
        public LogFile(string logfileName)
        {
            FileName = logfileName;
        }

        #endregion

        #region Methods
        #endregion

        #region Properties

        public string FileName{
            get
            {
                return _FileName;
            }
            set
            {
                _FileName = value;
                NotifyPropertyChanged("FileName");
                
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyname = "FileName")
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        #endregion

    }
}
