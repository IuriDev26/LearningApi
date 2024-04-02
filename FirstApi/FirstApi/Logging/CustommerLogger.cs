
using System;

namespace FirstApi.Logging {
    public class CustommerLogger : ILogger {
        private string _loggerName;
        private CustomLoggerProviderConfiguration _loggerConfig;

        public CustommerLogger(string loggerName, CustomLoggerProviderConfiguration loggerConfig) {
            _loggerName = loggerName;
            _loggerConfig = loggerConfig;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel) {
            return logLevel == _loggerConfig.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter) {
            string message = $"{logLevel.ToString()}: {eventId.Id} - {formatter(state, exception)}";

            WriteLog(message);
        }

        public void WriteLog(string message) {
            //string caminhoLog = @"C:\Users\ESTAGIARIOTI\Documents\LearningApi\FirstApi\FirstApi\Logging\consoles\console.txt";
            string caminhoLog = @"C:\Users\Iuri\Desktop\WebAPI\LearningApi\FirstApi\FirstApi\Logging\consoles\console.txt";


            using (StreamWriter streamWriter = new StreamWriter(caminhoLog, true)) {
                try {

                    streamWriter.Write(message);
                    streamWriter.Close();

                } catch (Exception){
                    throw;
                }
            }


        }
    }
}
