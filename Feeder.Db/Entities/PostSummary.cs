namespace Feeder.Db.Entities
{
    public class PostSummary
    {
        #region Constructors

        public PostSummary(int id, string title)
        {
            Id = id;
            Title = title;
        }

        #endregion

        #region Properties

        public int Id { get; private set; }
        public string Title { get; private set; }

        #endregion
    }
}
