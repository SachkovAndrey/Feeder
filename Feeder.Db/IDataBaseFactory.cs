using Org.Feeder.FeederDb;

namespace Feeder.Db
{
    public interface IDataBaseFactory
    {
        #region Methods

        Database Create();

        #endregion
    }
}
