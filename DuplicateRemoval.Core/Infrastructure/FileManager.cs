namespace DuplicateRemoval.Core.Infrastructure
{
    public class FileManager : IFileManager
    {
        public bool FileExists(string fileName)
        {
            var path = GetFullPath(fileName);
            return File.Exists(Path.Combine(Directory.GetCurrentDirectory(), path));
        }

        public IList<string> GetFileData(string fileName)
        {
            var path = GetFullPath(fileName);
            return File.ReadAllLines(path);
        }

        public void SaveFileData(string fileName, IList<string> data)
        {
            throw new NotImplementedException();
        }

        private string GetFullPath(string fileName)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), @$"Files/{fileName}");
        }
    }
}
