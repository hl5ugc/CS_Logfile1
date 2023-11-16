using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hl5ugc.Tools
{
    public enum LogType  {None, Daily, Monthly }

    public class LogManager
    {
        // LogPath\2023\12\20231207.txt
        // LogPath\2023\202312.txt
        // LogPath\2023\12\Hnt_202312.txt
        private string _path;

        #region Constructors
        
        public LogManager(string path,LogType logType, string prefix, string posfix)
        {
            _path = path;
            _SetLogFile(logType, prefix, posfix);

        }
        public LogManager(string prefix, string posfix)
            : this(Path.Combine(Application.Root, "Log"), LogType.Daily, prefix, posfix)
        {

        }
        public LogManager()
            : this(Path.Combine(Application.Root, "Log"), LogType.Daily,null,null) // root + log directory
        {
        }

        #endregion

        #region Methods
        private void _SetLogFile(LogType logType, string prefix, string posfix)
        {   // 
            string path = String.Empty;
            string name = String.Empty;
             
            switch(logType)
            {
                case LogType.None:  // LogPath\2023\12\20231207.txt
                    name = DateTime.Now.ToString("yyMMdd") + ".txt";
                    break;
                case LogType.Daily:  // LogPath\2023\12\20231207.txt
                    path = String.Format(@"{0}\{1}\", DateTime.Now.Year, DateTime.Now.ToString("MM"));
                    name = DateTime.Now.ToString("yyMMdd");
                    break;
                case LogType.Monthly:
                    path = String.Format(@"{0}\", DateTime.Now.Year);
                    name = DateTime.Now.ToString("yyMM");
                    break;
            }

            // Make Directory
            _path = Path.Combine(_path, path);

            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
            // Set Full FIlename
            // prefix & posfix
            if(!String.IsNullOrEmpty(prefix))
            {
                name = prefix + name;
            }
            if (!String.IsNullOrEmpty(posfix))
            {
                name = name + posfix;
            }
            name += ".txt";
            _path = Path.Combine(_path, name);
        }

        public void Write(string data)
        {
            try
            {
                // using 은 using 스콥 안에서만 
                using (StreamWriter writer = new StreamWriter(_path, true))
                {
                    writer.Write(data);
                }
            }
            catch (Exception ex) { }
        }

        public void WriteLine(string data) 
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_path, true))
                {
                    writer.WriteLine(DateTime.Now.ToString("yyyyMMdd HH:mm:ss\t") + data);
                }
            }
            catch (Exception ex) { }
        }
        #endregion
    }
}
