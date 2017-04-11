using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace SmartLeopard.Api.Framework
{
    public class UnhandledExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILog _logger;

        public UnhandledExceptionFilterAttribute(ILog logger)
        {
            _logger = logger;
        }

        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            _logger.Error(actionExecutedContext.Exception);
             
            actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionExecutedContext.Exception);
            return base.OnExceptionAsync(actionExecutedContext, cancellationToken);
        }
    }
}