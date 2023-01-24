using DuplicateRemoval.Core.Infrastructure;

namespace DuplicateRemoval.Test.Infrastructure
{
    public class FileManagerTests
    {
        [Fact]
        public void FileExists_Success()
        {
            var sut = new FileManager();
            Assert.True(sut.FileExists("Sheet1.csv"));
        }

        [Fact]
        public void FileExists_NotFound()
        {
            var sut = new FileManager();
            Assert.False(sut.FileExists("Sheet99.csv"));
        }

        [Fact]
        public void GetFileData_Success()
        {
            var sut = new FileManager();
            Assert.NotEmpty(sut.GetFileData("Sheet1.csv"));
        }

        [Fact]
        public void GetFileData_Exception()
        {
            var sut = new FileManager();
            Assert.Throws<FileNotFoundException>(() => sut.GetFileData("Sheet99.csv"));
        }

    }
}
