using Feeder.Db.Mappers;
using NUnit.Framework;
using Org.Feeder.FeederDb;

namespace Feeder.Db.Tests
{
    [TestFixture]
    public class PostMapperTest
    {
        [Test]
        public void MapCommonConditionSuccessTest()
        {
            var post = new Post(2, 1, "My test post", "My test Body");
            var postMapper = new PostMapper();

            Entities.Post result = postMapper.Map(post);

            Assert.AreEqual(2, result.Id);
            Assert.AreEqual("My test post", result.Title);
            Assert.AreEqual("My test Body", result.Body);
            Assert.AreEqual(1, result.UserId);
        }
    }
}
