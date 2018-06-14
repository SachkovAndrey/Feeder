using SimpleInjector;

namespace Feeder.Services
{
    public static class ServicesComponentRegistrations
    {
        #region Static Methods

        public static void RegisterServices(Container container)
        {
            container.Register<IPostService, PostService>();
            container.Register<IPostSummaryService, PostSummaryService>();
            container.Register<ICommentService, CommentService>();
        }

        #endregion
    }
}
