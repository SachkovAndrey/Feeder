using Feeder.DAL.Mappers;
using Feeder.Db.Entities;
using NUnit.Framework;

namespace Feeder.DAL.Tests.Mappers
{
    [TestFixture]
    public class PostSummaryMapperMapperTest
    {
        [Test]
        public void MapCommonConditionSuccessTest()
        {
            var postSummary = new PostSummary(2, "My test title");

            var postSummaryMapper = new PostSummaryMapper();

            Core.Models.PostSummary result = postSummaryMapper.Map(postSummary);

            Assert.AreEqual(2, result.Id);
            Assert.AreEqual("My test title", result.Title);
        }
    }
}
