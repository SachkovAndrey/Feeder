using Feeder.Core.Models;

namespace Feeder.Services
{
    public interface IPostService
    {
        #region Methods

        Post Get(int postId);

        #endregion
    }
}
