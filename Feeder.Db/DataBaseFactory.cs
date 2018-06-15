using System;
using Feeder.Common;
using Org.Feeder.FeederDb;

namespace Feeder.Db
{
    internal class DataBaseFactory : IDataBaseFactory
    {
        #region Static and Readonly Fields

        private static readonly object obj = new Object();

        private readonly IConfiguration configuration;

        #endregion

        #region Fields

        private Database db;

        #endregion

        #region Constructors

        public DataBaseFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        #endregion

        #region IDataBaseFactory Members

        public Database Create()
        {
            lock (obj)
            {
                db = db ?? new Database(configuration.ConnectionString);
                return db;
            }
        }

        #endregion
    }
}
