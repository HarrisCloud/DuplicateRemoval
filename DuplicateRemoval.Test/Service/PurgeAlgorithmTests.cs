using DuplicateRemoval.Core.Service;

namespace DuplicateRemoval.Test.Service
{
    public class PurgeAlgorithmTests
    {
        [Fact]
        public void PurgeAlgorithm1_Purge_Success()
        {
            var data = new List<string>()
            {
                "1,John",
                "2,Fred",
                "1,John"
            };
            var sut = new PurgeAlgorithm1();
            var result = sut.Purge(data);
            Assert.Equal(2, result.Count);
            Assert.Contains(result, x => x == "1,John");
            Assert.Contains(result, x => x == "2,Fred");
        }

    }
}
