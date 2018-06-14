using Feeder.Db.Mappers;
using NUnit.Framework;
using Org.Feeder.FeederDb;

namespace Feeder.Db.Tests
{
    [TestFixture]
    public class PostSummaryMapperTest
    {
        [Test]
        public void MapCommonConditionSuccessTest()
        {
            var postSummary = new PostSummary(2, "My test title");
            var postSummaryMapper = new PostSummaryMapper();
            Entities.PostSummary result = postSummaryMapper.Map(postSummary);

            Assert.AreEqual(2, result.Id);
            Assert.AreEqual("My test title", result.Title);
        }
    }
}
