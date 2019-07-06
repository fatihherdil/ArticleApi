using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace ArticleApi.Infrastructure.Logging.Loggers
{
    public class FileLogger : ILogger
    {
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (logLevel.GetHashCode() <= 2) return;

            const string filePath = "log.txt";

            using (var writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{logLevel.ToString()}: {eventId.Id}/{eventId.Name} - {formatter(state, exception)}");
                writer.Flush();

                if (exception == null) { writer.Close(); return; }

                if (!string.IsNullOrEmpty(exception.GetType().Name))
                    writer.WriteLine($"Exception: {exception.GetType().Name}");
                if (!string.IsNullOrEmpty(exception.Message))
                    writer.WriteLine($"Ex Message: {exception.Message}");
                if (!string.IsNullOrEmpty(exception.StackTrace))
                    writer.WriteLine($"StackTrace: {exception.StackTrace}");

                writer.Flush();
                writer.Close();
            }
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel.GetHashCode() > 2;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}
