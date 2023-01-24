namespace DuplicateRemoval.Core.Service
{
    public class PurgeAlgorithm2 : DuplicateRemovalStrategy
    {
        public override IList<string> Purge(IList<string> list)
        {
            var subset = list.Where(data => !data.Contains("John")).ToList();
            subset.AddRange(list.Where(data => data.Contains("John")).Distinct());
            return subset;
        }

    }
}
