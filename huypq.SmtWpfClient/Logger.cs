﻿using System;
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
            public const string UI = "UI";
            public const string Data = "Data";
            public const string Unknow = "Unknow";
        }

        public bool LogToConsole = true;
        public bool LogToFile = true;
        public string LogFileName = "log.txt";
        public ObservableCollection<LogData> LogDatas = new ObservableCollection<LogData>();
        public LogLevelEnum LogLevel = Logger.LogLevelEnum.Info;

        DateTime _lastTime = DateTime.Now;

        const int KBSize = 1024;
        const int MBSize = 1024 * KBSize;
        const int GBSize = 1024 * MBSize;
        public string FormatByteCount(int count)
        {
            if (count < KBSize)
                return string.Format("{0} B", count);
            if (count < MBSize)
                return string.Format("{0} KB", count / KBSize);
            if (count < GBSize)
                return string.Format("{0} MB", count / MBSize);

            return string.Format("{0} GB", count / GBSize);
        }

        public string FormatByteCount(long count)
        {
            if (count < KBSize)
                return string.Format("{0} B", count);
            if (count < MBSize)
                return string.Format("{0} KB", count / KBSize);
            if (count < GBSize)
                return string.Format("{0} MB", count / MBSize);

            return string.Format("{0} GB", count / GBSize);
        }

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
