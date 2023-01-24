using DuplicateRemoval.Core.Infrastructure;
using DuplicateRemoval.Core.Service;

namespace DuplicateRemoval.Test.Service
{
    public class DuplicateRemoverTests
    {
        [Fact]
        public void PurgeAlgorithm1_Success()
        {
            var data = new List<string>()
            {
                "1,John",
                "2,Fred",
                "1,John"
            };
            var sut = new DuplicateRemover();
            sut.SetStrategy(new PurgeAlgorithm1());
            sut.AddFileData(data);
            var result = sut.Purge();
            Assert.Equal(2, result.Count);
            Assert.Contains(result, x => x == "1,John");
            Assert.Contains(result, x => x == "2,Fred");
        }

        [Fact]
        public void PurgeAlgorithm2_Success()
        {
            var data = new List<string>()
            {
                "1,John",
                "2,Fred",
                "1,John",
                "2,Fred",
            };
            var sut = new DuplicateRemover();
            sut.SetStrategy(new PurgeAlgorithm2());
            sut.AddFileData(data);
            var result = sut.Purge();
            Assert.Equal(1, result.Count(x => x == "1,John"));
            Assert.Equal(2, result.Count(x => x == "2,Fred"));
        }
    }
}
