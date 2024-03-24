using Microsoft.AspNetCore.Mvc.Filters;

namespace FirstApi.Filters {
    public class ApiLoggingFilter : IActionFilter {

        private readonly ILogger<ApiLoggingFilter> _logger;

        public ApiLoggingFilter(ILogger<ApiLoggingFilter> logger) {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context) {
            _logger.LogInformation("---------------------------------------");
            _logger.LogInformation("------------Action Executada-----------");

        }

        public void OnActionExecuting(ActionExecutingContext context) {
            _logger.LogInformation("---------------------------------------");
            _logger.LogInformation("----------Preparando Execução----------");

        }
    }
}
