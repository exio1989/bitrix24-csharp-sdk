using Microsoft.Extensions.Logging;
using System;

namespace Bitrix24RestApiTools
{
    public class ConsoleLogger<TClass> : ILogger<TClass>
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            Console.WriteLine($"{logLevel}: {formatter(state, exception)}");
        }
    }
}
