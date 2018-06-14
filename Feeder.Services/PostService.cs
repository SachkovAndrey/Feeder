using Feeder.Core.Models;
using Feeder.DAL;

namespace Feeder.Services
{
    internal class PostService : IPostService
    {
        #region Static and Readonly Fields

        private readonly IPostRepository repository;

        #endregion

        #region Constructors

        public PostService(IPostRepository repository)
        {
            this.repository = repository;
        }

        #endregion

        #region IPostService Members

        public Post Get(int postId)
        {
            return repository.GetPost(postId);
        }

        #endregion
    }
}
