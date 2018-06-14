using Feeder.Common;
using Feeder.DAL.Mappers;
using Feeder.Db.Entities;
using SimpleInjector;

namespace Feeder.DAL
{
    public static class RepositoryComponentRegistration
    {
        #region Static Methods

        public static void RegisterRepositories(Container container)
        {
            container.Register<IMapToNew<User, Core.Models.User>, UserMapper>();
            container.Register<IMapToNewWithChild<Post, User, Core.Models.Post>, PostMapper>();
            container.Register<IMapToNew<PostSummary, Core.Models.PostSummary>, PostSummaryMapper>();
            container.Register<IMapToNewWithChild<Comment, User, Core.Models.Comment>, CommentMapper>();

            container.Register<IPostRepository, PostRepository>();
            container.Register<IPostSummaryRepository, PostSummaryRepository>();
            container.Register<ICommentRepository, CommentRepository>();
        }

        #endregion
    }
}
