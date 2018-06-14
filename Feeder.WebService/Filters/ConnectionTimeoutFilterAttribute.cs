using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using Feeder.Common.Exceptions;

namespace Feeder.WebService.Filters
{
    public class ConnectionTimeoutFilterAttribute : ExceptionFilterAttribute
    {
        #region Methods

        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is ConnectionTimeoutException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    ReasonPhrase = context.Exception.Message
                };
            }
        }

        #endregion
    }
}
