using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Logging
{
    /// <summary>
    /// Author: Nam-Truong
    /// Email: ptnknamhcm@gmail.com
    /// Note: Have fun with coding! :)
    /// </summary>
    public static class Logging
    {
        public const string INFOR = "INFOR";
        public const string ERROR = "ERROR";
        public const string WebServiceLogDirectory = "C:\\PACE_WS\\";

        private static void CreateLogFolder(string FolderLocation)
        {
            string loglocation = FolderLocation;
            if (!Directory.Exists(loglocation))
            {
                Directory.CreateDirectory(loglocation);
            }
        }

        private static string GenerateDailyLogFileName(string FolderLocation, string FileName)
        {
            string LogLocation = FolderLocation;

            CreateLogFolder(FolderLocation);

            if (LogLocation[LogLocation.Length - 1] != '\\')
            {
                LogLocation += "\\";
            }

            LogLocation += DateTime.Now.Year.ToString("D4") + DateTime.Now.Month.ToString("D2") + DateTime.Now.Day.ToString("D2") + "\\";//

            if (!Directory.Exists(LogLocation))
            {
                Directory.CreateDirectory(LogLocation);
            }


            LogLocation += FileName + ".txt";

            return LogLocation;
        }


        private static string AddHeaderToLogMessage(string LogMessage, string LogType)
        {
            return string.Format("{0}{1}{2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff").PadRight(27, ' '), LogType.PadRight(10, ' '), LogMessage);
            //return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff").PadRight(30, ' ') + Indicator.PadRight(10, ' ') + LogMessage;
        }


        /// <summary>
        /// 
        /// <para>Last Modified: 01 October 2014 </para>
        /// <para>Author: Truong Hoang Nam </para>
        /// <para>Description: To write log message into specific log file
        /// </para>
        /// </summary>
        /// <param name="FolderLocation"></param>
        /// <param name="FileName"></param>
        /// <param name="Indicator"></param>
        /// <param name="LogMessage"></param>
        public static void Log(string FolderLocation, string FileName, string LogType, string LogMessage)
        {
            WriteToFile(GenerateDailyLogFileName(FolderLocation, FileName), AddHeaderToLogMessage(LogMessage, LogType));
        }

        private static void WriteToFile(string Dateiverzeichnis, string Nachricht)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(Dateiverzeichnis)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(Dateiverzeichnis));
                }

                StreamWriter writerObj = new StreamWriter(Dateiverzeichnis, true);

                writerObj.WriteLine(Nachricht);
                writerObj.Close();
            }
            catch (Exception ERROR)
            {
                throw ERROR;
            }
        }


    }
}
