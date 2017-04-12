using System; 
using NLog;

namespace SmartLeopard.Api.Framework
{
    public class NLogger : ILog
    {

        private readonly ILogger _logger;

        public NLogger(string currentClassName)
        {
            _logger = LogManager.GetLogger(currentClassName); 
        }                                   

        public void Debug(object value)
        {
            _logger.Info(value);
        }

        public void Error(Exception exception)
        {
            _logger.Error(exception);
        }
    }
}