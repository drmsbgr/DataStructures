using DataStructuresLib.LinkedList.DoublyLinkedList;

namespace DataStructuresLib.Queue
{
    public class LinkedListQueue<T> : IQueue<T>
    {
        private readonly DoublyLinkedList<T> list = [];
        public int Count { get; private set; }

        public T Dequeue()
        {
            if (Count == 0) throw new Exception("empty queue");

            var temp = list.Head.Value;
            list.RemoveFirst();
            Count--;
            return temp;
        }

        public void Enqueue(T value)
        {
            if (value == null) throw new ArgumentNullException();
            list.AddLast(value);
            Count++;
        }

        public T Peek()
        {
            if (Count == 0) throw new Exception("empty queue");
            return list.Head.Value;
        }
    }
}