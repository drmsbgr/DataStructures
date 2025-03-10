using System.Collections;

namespace DataStructuresLib.Heap
{
    public abstract class BHeap<T> : IEnumerable<T> where T : IComparable
    {
        public T[] Array { get; private set; }
        protected int position;
        public int Count { get; private set; }

        public BHeap()
        {
            Count = 0;
            Array = new T[128];
            position = 0;
        }

        public BHeap(int _size)
        {
            Count = 0;
            Array = new T[_size];
            position = 0;
        }

        public BHeap(IEnumerable<T> collection)
        {
            Count = 0;
            Array = new T[collection.ToArray().Length];
            position = 0;

            foreach (var item in collection)
                Add(item);
        }

        protected int GetLeftChildIndex(int index) => 2 * index + 1;
        protected int GetRightChildIndex(int index) => 2 * index + 2;
        protected int GetParentIndex(int index) => (index - 1) / 2;
        protected bool HasLeftChild(int index) => GetLeftChildIndex(index) < position;
        protected bool HasRightChild(int index) => GetRightChildIndex(index) < position;
        protected bool IsRoot(int index) => index == 0;
        protected T GetLeftChild(int index) => Array[GetLeftChildIndex(index)];
        protected T GetRightChild(int index) => Array[GetRightChildIndex(index)];
        protected T GetParent(int index) => Array[GetParentIndex(index)];
        public bool IsEmpty => position == 0;

        public T Peek()
        {
            if (IsEmpty)
                throw new Exception("heap is empty");
            return Array[0];
        }

        public void Swap(int i1, int i2)
        {
            (Array[i2], Array[i1]) = (Array[i1], Array[i2]);
        }

        public void Add(T value)
        {
            if (position == Array.Length)
                throw new OverflowException("Overflow");

            Array[position] = value;
            position++;
            Count++;
            HeapifyUp();
        }

        public T DeleteMinMax()
        {
            if (position == 0)
                throw new Exception("Underflow");

            var temp = Array[0];

            Array[0] = Array[position];
            Count--;
            position--;
            HeapifyDown();

            return temp;
        }

        protected abstract void HeapifyDown();
        protected abstract void HeapifyUp();

        public IEnumerator<T> GetEnumerator()
        {
            return Array.Take(position).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
