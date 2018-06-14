using Feeder.Common;
using Feeder.Db.Mappers;
using Org.Feeder.FeederDb;
using SimpleInjector;

namespace Feeder.Db
{
    public static class DbComponentRegistration
    {
        #region Static Methods

        public static void RegisterDb(Container container)
        {
            container.Register<IMapToNew<Post, Entities.Post>, PostMapper>();
            container.Register<IMapToNew<PostSummary, Entities.PostSummary>, PostSummaryMapper>();
            container.Register<IMapToNew<Comment, Entities.Comment>, CommentMapper>();
            container.Register<IMapToNew<User, Entities.User>, UserMapper>();

            container.RegisterSingleton<IDataBaseFactory, DataBaseFactory>();
            container.Register<IDbContext, DbContext>();
        }

        #endregion
    }
}
