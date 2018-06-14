using Feeder.Common;
using Org.Feeder.FeederDb;

namespace Feeder.Db.Mappers
{
    internal class UserMapper : IMapToNew<User, Entities.User>
    {
        #region IMapToNew<User,User> Members

        public Entities.User Map(User source)
        {
            return new Entities.User(source.UserId, source.Name, source.Email, source.ImageUrl);
        }

        #endregion
    }
}
