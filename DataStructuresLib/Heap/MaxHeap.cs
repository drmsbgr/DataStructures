namespace DataStructuresLib.Heap
{
    public class MaxHeap<T> : BHeap<T>, IEnumerable<T> where T : IComparable
    {
        public MaxHeap() : base()
        {
        }

        public MaxHeap(int _size) : base(_size)
        {
        }

        public MaxHeap(IEnumerable<T> collection) : base(collection)
        {

        }

        protected override void HeapifyDown()
        {
            var index = 0;

            while (HasLeftChild(index))
            {
                var largestIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index).CompareTo(GetLeftChild(index)) > 0)
                {
                    largestIndex = GetRightChildIndex(index);
                }

                if (Array[largestIndex].CompareTo(Array[index]) >= 0)
                    break;

                Swap(largestIndex, index);
                index = largestIndex;
            }
        }

        protected override void HeapifyUp()
        {
            var index = position - 1;
            while (!IsRoot(index) && Array[index].CompareTo(GetParent(index)) > 0)
            {
                var parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }
    }
}
