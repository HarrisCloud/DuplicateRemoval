namespace DuplicateRemoval.Core.Service
{
    public abstract class DuplicateRemovalStrategy
    {
        public abstract IList<string> Purge(IList<string> list);
    }
}
