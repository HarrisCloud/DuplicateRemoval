namespace DuplicateRemoval.Core.Service
{
    public class DuplicateRemover
    {
        private List<string> dataList = new();
        private DuplicateRemovalStrategy strategy;

        public void SetStrategy(DuplicateRemovalStrategy duplicateRemovalStrategy)
        {
            strategy = duplicateRemovalStrategy;
        }
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

