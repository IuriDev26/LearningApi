using System.Collections.Concurrent;

namespace FirstApi.Logging {
    public class CustomLoggerProvider : ILoggerProvider {

        private readonly CustomLoggerProviderConfiguration _config;

        private readonly ConcurrentDictionary<string, CustommerLogger> _loggers = new ConcurrentDictionary<string, CustommerLogger> ();

        public CustomLoggerProvider(CustomLoggerProviderConfiguration config)
        {
            _config = config;   
        }



        public ILogger CreateLogger(string categoryName) {
            return _loggers.GetOrAdd(categoryName, name => new CustommerLogger(name, _config));
        }

        public void Dispose() {
            _loggers.Clear();
        }
    }
}
