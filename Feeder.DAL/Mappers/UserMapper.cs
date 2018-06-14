using Feeder.Common;
using Feeder.Db.Entities;

namespace Feeder.DAL.Mappers
{
    internal class UserMapper : IMapToNew<User, Core.Models.User>
    {
        #region IMapToNew<User,User> Members

        public Core.Models.User Map(User source)
        {
            return new Core.Models.User() { Name = source.Name, ImageUrl = source.ImageUrl, Email = source.Email, UserId = source.UserId };
        }

        #endregion
    }
}
