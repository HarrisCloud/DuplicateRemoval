namespace DuplicateRemoval.Core.Service
{
    public class DuplicateRemover
    {
        public DuplicateRemover(DuplicateRemovalStrategy duplicateRemovalStrategy)
        {
            strategy = duplicateRemovalStrategy;
        }

        private List<string> dataList = new();
        private DuplicateRemovalStrategy strategy;

        public void AddFileData(IList<string> data)
        {
            dataList.AddRange(data);
        }
        public IList<string> Purge()
        {
            if (strategy is null)
            {
                throw new Exception("Strategy was not set");
            }

            return dataList.Count == 0 ? dataList : strategy.Purge(dataList);
        }
    }
}

