using System;
using System.Collections.ObjectModel;

namespace huypq.SmtWpfClient.Abstraction
{
    public sealed class Logger
    {
        private static readonly Logger _instance = new Logger();

        public static Logger Instance
        {
            get { return _instance; }
        }

        public class LogData
        {
            public DateTime LogTime { get; set; }
            public int ElapsedTimeFromPreviousLog { get; set; }
            public string Category { get; set; }
            public LogLevelEnum Level { get; set; }
            public string Message { get; set; }
        }

        public enum LogLevelEnum
        {
            Error,
            Warn,
            Info,
            Debug
        }

        public class Categories
        {
            public static readonly string UI = "UI";
            public static readonly string Data = "Data";
        }

        public bool LogToConsole = true;
        public bool LogToFile = true;
        public string LogFileName = "log.txt";
        public ObservableCollection<LogData> LogDatas = new ObservableCollection<LogData>();
        public LogLevelEnum LogLevel = Logger.LogLevelEnum.Info;

        DateTime _lastTime = DateTime.Now;

        public void Error(string msg, string category)
        {
            Log(LogLevelEnum.Error, msg, category);
        }

        public void Warn(string msg, string category)
        {
            Log(LogLevelEnum.Warn, msg, category);
        }

        public void Info(string msg, string category)
        {
            Log(LogLevelEnum.Info, msg, category);
        }

        public void Debug(string msg, string category)
        {
            Log(LogLevelEnum.Debug, msg, category);
        }

        private void Log(LogLevelEnum logLevel, string msg, string category)
        {
            if (logLevel > LogLevel)
            {
                return;
            }
            var logTime = DateTime.Now;
            var logData = new LogData()
            {
                LogTime = logTime,
                ElapsedTimeFromPreviousLog = (logTime - _lastTime).Milliseconds,
                Category = category,
                Level = logLevel,
                Message = msg
            };
            LogDatas.Add(logData);
            if (LogToConsole == true || LogToFile == true)
            {
                var logText = string.Format("{0} | {1,5} | {2,5:N0}ms | {3} | {4}",
                    logData.LogTime, logData.Level, logData.ElapsedTimeFromPreviousLog, logData.Category, logData.Message);

                if (LogToConsole == true)
                {
                    Console.WriteLine(logText);
                }
                if (LogToFile == true)
                {
                    using (var sw = System.IO.File.AppendText(LogFileName))
                    {
                        sw.WriteLine(logText);
                    }
                }
            }
            _lastTime = logTime;
        }
    }
}
