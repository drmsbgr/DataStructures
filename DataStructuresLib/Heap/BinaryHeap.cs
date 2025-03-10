using DataStructuresLib.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresLib.Heap
{
    public class BinaryHeap<T> : IEnumerable<T> where T : IComparable
    {
        public T[] Array { get; private set; }
        private int position;
        public int Count { get; private set; }

        private readonly IComparer<T> comparer;
        private readonly bool isMax;

        public BinaryHeap(SortDirections dir = SortDirections.Ascending) : this(dir, null, null)
        {
        }

        public BinaryHeap(SortDirections dir, IEnumerable<T> initial) : this(dir, initial, null)
        {
        }

        public BinaryHeap(SortDirections dir, IEnumerable<T> initial, IComparer<T> comparer)
        {
            position = 0;
            Count = 0;

            this.isMax = dir == SortDirections.Descending;
            if (comparer != null)
                this.comparer = new CustomComparer<T>(dir, comparer);
            else
                this.comparer = new CustomComparer<T>(dir, Comparer<T>.Default);

            if (initial != null)
            {
                var items = initial as T[] ?? initial.ToArray();
                Array = new T[items.Length];
                foreach (var item in items)
                    Add(item);
            }
            else
                Array = new T[128];
        }

        public BinaryHeap()
        {
            Count = 0;
            Array = new T[128];
            position = 0;
        }

        public BinaryHeap(int _size)
        {
            Count = 0;
            Array = new T[_size];
            position = 0;
        }

        public BinaryHeap(IEnumerable<T> collection)
        {
            Count = 0;
            Array = new T[collection.ToArray().Length];
            position = 0;

            foreach (var item in collection)
                Add(item);
        }

        private int GetLeftChildIndex(int index) => 2 * index + 1;
        private int GetRightChildIndex(int index) => 2 * index + 2;
        private int GetParentIndex(int index) => (index - 1) / 2;
        private bool HasLeftChild(int index) => GetLeftChildIndex(index) < position;
        private bool HasRightChild(int index) => GetRightChildIndex(index) < position;
        private bool IsRoot(int index) => index == 0;
        private T GetLeftChild(int index) => Array[GetLeftChildIndex(index)];
        private T GetRightChild(int index) => Array[GetRightChildIndex(index)];
        private T GetParent(int index) => Array[GetParentIndex(index)];
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

        private void HeapifyDown()
        {
            var index = 0;

            while (HasLeftChild(index))
            {
                var largestIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && comparer.Compare(GetRightChild(index), GetLeftChild(index)) < 0)
                {
                    largestIndex = GetRightChildIndex(index);
                }

                if (comparer.Compare(Array[largestIndex], Array[index]) >= 0)
                    break;

                Swap(largestIndex, index);
                index = largestIndex;
            }
        }

        private void HeapifyUp()
        {
            var index = position - 1;
            while (!IsRoot(index) && comparer.Compare(Array[index], GetParent(index)) < 0)
            {
                var parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Array.Take(position).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
