using System.Configuration;

namespace Feeder.WpfApp
{
    internal static class AppSettingsProvider
    {
        #region Static and Readonly Fields

        private static string baseAdress;
        private static string commentsEndPoint;
        private static string observableScheduleInterval;
        private static string postEndPoint;
        private static string postSummariesEndPoint;

        #endregion

        #region Static Methods

        public static string GetBaseAdress()
        {
            baseAdress = baseAdress ?? ConfigurationManager.AppSettings["BaseAddress"];

            return baseAdress;
        }

        public static string GetCommentsEndPoint()
        {
            commentsEndPoint = commentsEndPoint ?? ConfigurationManager.AppSettings["CommentsEndPoint"];

            return commentsEndPoint;
        }

        public static string GetObservableScheduleInterval()
        {
            observableScheduleInterval = observableScheduleInterval ?? ConfigurationManager.AppSettings["ObservableScheduleInterval"];

            return observableScheduleInterval;
        }

        public static string GetPostEndPoint()
        {
            postEndPoint = postEndPoint ?? ConfigurationManager.AppSettings["PostEndPoint"];

            return postEndPoint;
        }

        public static string GetPostSummariesEndPoint()
        {
            postSummariesEndPoint = postSummariesEndPoint ?? ConfigurationManager.AppSettings["PostSummariesEndPoint"];

            return postSummariesEndPoint;
        }

        #endregion
    }
}
