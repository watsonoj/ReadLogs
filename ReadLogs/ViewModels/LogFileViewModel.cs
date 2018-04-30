using System;
using System.IO;

using System.Windows.Forms;
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
        public string line;
        public LogFile _UnitNum;
        private string _FileName_s;
        private char[] _Line_s = new char[166];
        private LogFile _LogFile;

        #endregion

        #region Constructor

        public LogFileViewModel()
        {
            _LogFile = new LogFile("logfile.txt");
            UpdateCommand = new LogFileUpdateCommand(this);
        }        

        #endregion

        #region Methods


        public void NewFile()
        {
            Stream myStream = null;

            VerifyUnitNumber();

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            _FileName_s = openFileDialog1.FileName;
            LogFile.FileName = _FileName_s;
            ReadThisFile();
        }

        /// <summary>
        /// read text file method
        /// </summary>
        public void ReadThisFile()
        {
            //String line;

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(_FileName_s);

                //Read the first line of text
                line = sr.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    _Line_s = line.ToCharArray();
                }

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the lie to console window
                    //Console.WriteLine(line);
                    /*Write to text fiel ReadLogs.txt*/
                    WriteToThisFile();
                    //Read the next line
                    line = sr.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        _Line_s = line.ToCharArray();
                    }
                }

                //close the file
                sr.Close();
                //Console.ReadLine();
            }
            catch (Exception ex)
            {
                MessageBox.Show("StreamReader Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// Write to output file
        /// </summary>
        public void WriteToThisFile()
        {
            try
            {

                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("ReadLogs" + UnitNum + ".txt", true);

                //Write a line of text
                sw.WriteLine(line);

                //Write a second line of text
                //sw.WriteLine("From the StreamWriter class");

                //Close the file
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("StreamWriter Exception: " + ex.Message);
            }
        }

        /// <summary>
        /// verify unit number was entered
        /// </summary>
        public void VerifyUnitNumber()
        {
            try
            {
                _UnitNum = LogFile.UnitNumber;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unit Number Exception: " + ex.Message);
            }
        }

        #endregion

        #region Properties

        public LogFile Unitnum
        {
            get { return _UnitNum; }
            set { _UnitNum = value; }
        }

        public LogFile LogFile{
            get{
                return _LogFile;
            }

        }

        public ICommand UpdateCommand
        {
            get;
            private set;
        }

        public bool CanUpdate
        {
            get { return true; }
            //set;
        }

        public string FileName_s
        {
            get { return _FileName_s; }
            set { _FileName_s = value; }
        }

        public char[] Line_s
        {
            get { return _Line_s; }
            set { _Line_s = value; }
        }

        #endregion


    }
}
