using System;
using Caliburn.Micro;

namespace Pacman
{
    internal class Logging
    {
        public static void Configure()
        {
            ILog logger = new ConsoleLogger();
            ILog errorLogger = new ErrorLogger();

            LogManager.GetLog = type => type == typeof(ViewModelBinder) ? logger : errorLogger;
        }

        private class ConsoleLogger : ILog
        {
            public virtual void Info(string format, params object[] args)
            {
                Console.WriteLine("Info: " + format, args);
            }

            public virtual void Warn(string format, params object[] args)
            {
                Console.WriteLine("Warning: " + format, args);
            }

            public virtual void Error(Exception exception)
            {
                Console.WriteLine("Error: {0}", exception);
            }
        }

        private class ErrorLogger : ConsoleLogger
        {
            public override void Info(string format, params object[] args)
            {
            }
        }

        private class NullLogger : ILog
        {
            public void Info(string format, params object[] args)
            {
            }

            public void Warn(string format, params object[] args)
            {
            }

            public void Error(Exception exception)
            {
            }
        }
    }
}
