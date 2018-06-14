using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Feeder.Common.Exceptions;
using Feeder.Core.Models;
using Feeder.Services;

namespace Feeder.WebService.Controllers
{
    public class PostSummaryController : ApiController
    {
        #region Static and Readonly Fields

        private readonly IPostSummaryService service;

        #endregion

        #region Constructors

        public PostSummaryController(IPostSummaryService service)
        {
            this.service = service;
        }

        #endregion

        #region Methods

        [HttpGet]
        public List<PostSummary> Get()
        {
            try
            {
                return service.GetPostSummaries().ToList();
            }
            catch (ConnectionTimeoutException e)
            {
                throw new ConnectionTimeoutException(e.Message);
            }
        }

        #endregion
    }
}
