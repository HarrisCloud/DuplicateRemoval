namespace DuplicateRemoval.Core.Service
{
    public class PurgeAlgorithm1 : DuplicateRemovalStrategy
    {
        public override IList<string> Purge(IList<string> list)
        {
            return list.Distinct().ToList();
        }

    }
}
