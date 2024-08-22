using System.Collections;

namespace DataStructuresLib.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public SinglyLinkedListNode<T> Head { get; private set; }
        private bool hasHead => Head != null;

        public void AddFirst(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value)
            {
                Next = Head
            };

            Head = newNode;
        }

        public void AddLast(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);

            var current = Head;

            while (current.Next != null)
                current = current.Next;

            current.Next = newNode;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}