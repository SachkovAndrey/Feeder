using System.Web.Http;
using Feeder.Common.Exceptions;
using Feeder.Core.Models;
using Feeder.Services;

namespace Feeder.WebService.Controllers
{
    public class PostController : ApiController
    {
        #region Static and Readonly Fields

        private readonly IPostService postService;

        #endregion

        #region Constructors

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        #endregion

        #region Methods

        [HttpGet]
        public Post Get(int id)
        {
            try
            {
                return postService.Get(id);
            }
            catch (ConnectionTimeoutException e)
            {
                throw new ConnectionTimeoutException(e.Message);
            }
        }

        #endregion
    }
}
