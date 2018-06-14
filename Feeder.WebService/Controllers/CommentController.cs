using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Feeder.Common.Exceptions;
using Feeder.Core.Models;
using Feeder.Services;

namespace Feeder.WebService.Controllers
{
    public class CommentController : ApiController
    {
        #region Static and Readonly Fields

        private readonly ICommentService service;

        #endregion

        #region Constructors

        public CommentController(ICommentService service)
        {
            this.service = service;
        }

        #endregion

        #region Methods

        [HttpGet]
        public List<Comment> Get(int id)
        {
            try
            {
                return service.Get(id).ToList();
            }
            catch (ConnectionTimeoutException e)
            {
                throw new ConnectionTimeoutException(e.Message);
            }
        }

        #endregion
    }
}
