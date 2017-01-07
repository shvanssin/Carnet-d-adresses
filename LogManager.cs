using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SingletonPattern
{
    public class LogManager
    {
        private static LogManager _instance;

        public static LogManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LogManager();

                return _instance;
            }
        }
        public LogManager() 
        {
            _fileStream = File.OpenWrite(GetExecutionFolder() + "\\Application.log");
            _streamWriter = new StreamWriter(_fileStream);
        }

        private FileStream _fileStream;
        private StreamWriter _streamWriter;

        public void WriteLog(string message)
        {
            StringBuilder formattedMessage = new StringBuilder();
            formattedMessage.AppendLine("Date: " + DateTime.Now.ToString());
            formattedMessage.AppendLine("Message: " + message);
            _streamWriter.WriteLine(formattedMessage.ToString());
            _streamWriter.Flush();
        }

        public string GetExecutionFolder()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
    }
}
