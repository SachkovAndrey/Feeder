using Feeder.Core.Models;

namespace Feeder.DAL
{
    public interface IPostRepository
    {
        #region Methods

        Post GetPost(int postId);

        #endregion
    }
}
