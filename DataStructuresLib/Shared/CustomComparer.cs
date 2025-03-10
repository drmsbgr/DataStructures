namespace DataStructuresLib.Shared
{
    public class CustomComparer<T> : IComparer<T> where T : IComparable
    {
        private readonly bool isMax;
        private readonly IComparer<T> comparer;

        public CustomComparer(SortDirections dir, IComparer<T> comparer)
        {
            this.isMax = dir == SortDirections.Descending;
            this.comparer = comparer;
        }

        public int Compare(T? x, T? y)
        {
            return !isMax ? comparer.Compare(x, y) : comparer.Compare(y, x);
        }
    }
}
