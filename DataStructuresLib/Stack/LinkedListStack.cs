using DataStructuresLib.LinkedList.SinglyLinkedList;

namespace DataStructuresLib.Stack
{
    public class LinkedListStack<T> : IStack<T>
    {
        private readonly SinglyLinkedList<T> list = new();
        public int Count { get; private set; }

        public T Peek()
        {
            if (Count == 0)
                throw new Exception("stack boş");

            return list.Head.Value;
        }

        public T Pop()
        {
            if (Count == 0)
                throw new Exception("stack boş");

            Count--;

            return list.RemoveFirst();
        }

        public void Push(T value)
        {
            if (value == null)
                throw new ArgumentNullException();
            list.AddFirst(value);
            Count++;
        }
    }
}