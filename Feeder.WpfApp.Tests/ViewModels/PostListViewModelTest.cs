using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using Feeder.Common.Exceptions;
using Feeder.Core.Models;
using Feeder.ServiceClient;
using Feeder.WpfApp.ProgressBar;
using Feeder.WpfApp.ViewModels;
using Moq;
using NUnit.Framework;

namespace Feeder.WpfApp.Tests.ViewModels
{
    [TestFixture]
    public class PostListViewModelTest
    {
        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
            postSummaries = new List<PostSummary>()
            {
                new PostSummary() { Id = 1, Title = "A" },
                new PostSummary() { Id = 2, Title = "B" },
                new PostSummary() { Id = 3, Title = "C" },
                new PostSummary() { Id = 1, Title = "  D " },
                new PostSummary() { Id = 1, Title = "77   " }
            };

            postSummaryServiceClientMock = new Mock<IPostSummaryServiceClient>();
            progressBarMock = new Mock<IProgressBar>();
            windowManagerMock = new Mock<IWindowManager>();
        }

        [TearDown]
        public void TearDown()
        {
            postSummaries = null;
            postSummaryServiceClientMock = null;
            progressBarMock = null;
            windowManagerMock = null;
        }

        #endregion

        private List<PostSummary> postSummaries;
        private Mock<IPostSummaryServiceClient> postSummaryServiceClientMock;
        private Mock<IProgressBar> progressBarMock;
        private Mock<IWindowManager> windowManagerMock;

        [Test]
        public void FilterTextCaseInsensetiveSuccessTest()
        {
            var viewModel = new PostListViewModel(null,
                postSummaryServiceClientMock.Object,
                windowManagerMock.Object,
                progressBarMock.Object,
                null);

            viewModel.PostSummaries = new ObservableCollection<PostSummary>(postSummaries);
            viewModel.FilterText = "a";

            Assert.AreEqual(1, viewModel.FilteredPostSummaries.Count);
            Assert.AreEqual("A", viewModel.FilteredPostSummaries.First().Title);
        }

        [Test]
        public void FilterTextCommonConditionSuccessTest()
        {
            var viewModel = new PostListViewModel(null,
                postSummaryServiceClientMock.Object,
                windowManagerMock.Object,
                progressBarMock.Object,
                null);

            viewModel.PostSummaries = new ObservableCollection<PostSummary>(postSummaries);
            viewModel.FilterText = "A";

            Assert.AreEqual(1, viewModel.FilteredPostSummaries.Count);
            Assert.AreEqual("A", viewModel.FilteredPostSummaries.First().Title);
        }

        [Test]
        public void FilterTextTrimSuccessTest()
        {
            var viewModel = new PostListViewModel(null,
                postSummaryServiceClientMock.Object,
                windowManagerMock.Object,
                progressBarMock.Object,
                null);

            viewModel.PostSummaries = new ObservableCollection<PostSummary>(postSummaries);
            viewModel.FilterText = " a ";

            Assert.AreEqual(0, viewModel.FilteredPostSummaries.Count);
        }

        [Test]
        public void LoadDataProgressBarCallsSuccessTest()
        {
            var viewModel = new PostListViewModel(null,
                postSummaryServiceClientMock.Object,
                windowManagerMock.Object,
                progressBarMock.Object,
                null);

            viewModel.LoadData(null);

            progressBarMock.Verify(x => x.Show(), Times.Exactly(1));
        }

        [Test]
        public void LoadDataSuccessTest()
        {
            postSummaryServiceClientMock.Setup(summariesService => summariesService.Get(It.IsAny<string>())).Returns(() =>
            {
                var task = new Task<List<PostSummary>>(() => postSummaries);

                task.Start();
                task.Wait();
                return task;
            });

            var viewModel = new PostListViewModel(null,
                postSummaryServiceClientMock.Object,
                windowManagerMock.Object,
                progressBarMock.Object,
                null);

            viewModel.LoadData(null);

            Assert.AreNotEqual(null, viewModel.PostSummaries);
            Assert.AreEqual(postSummaries.Count, viewModel.PostSummaries.Count);
        }

        [Test]
        public void LoadDataThrowExceptionSuccessTest()
        {
            var viewModel = new PostListViewModel(null,
                postSummaryServiceClientMock.Object,
                windowManagerMock.Object,
                progressBarMock.Object,
                null);
            postSummaryServiceClientMock.Setup(x => x.Get(It.IsAny<string>())).Throws(new ConnectionTimeoutException());

            viewModel.LoadData(null);

            windowManagerMock.Verify(x => x.ShowDialog(It.IsAny<object>(), null, null), Times.Exactly(1));
        }
    }
}
