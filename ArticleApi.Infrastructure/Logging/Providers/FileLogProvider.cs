using ArticleApi.Infrastructure.Logging.Loggers;
using Microsoft.Extensions.Logging;

namespace ArticleApi.Infrastructure.Logging.Providers
{
    public class FileLogProvider : ILoggerProvider
    {
        public void Dispose()
        {

        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger();
        }
    }
}
