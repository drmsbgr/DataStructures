using System.Collections;
using DataStructuresLib.Contracts;

namespace DataStructuresLib.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T> : IEnumerable<T>, IPrintable
    {
        public SinglyLinkedListNode<T> Head { get; private set; }
        private bool hasHead => Head != null;

        public SinglyLinkedList()
        {

        }

        public SinglyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                this.AddLast(item);
        }

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
            if (!hasHead)
            {
                AddFirst(value);
                return;
            }

            var newNode = new SinglyLinkedListNode<T>(value);

            var current = Head;

            while (current.Next != null)
                current = current.Next;

            current.Next = newNode;
        }

        public T RemoveFirst()
        {
            if (!hasHead)
                throw new Exception("Silinecek bir düğüm yok.");

            var temp = Head;
            Head = Head.Next;
            return temp.Value;
        }

        public void Remove(T value)
        {
            if (!hasHead)
                throw new Exception("Silinecek bir düğüm yok.");

            if (value == null)
                throw new ArgumentNullException();

            SinglyLinkedListNode<T> prev = null;
            var current = Head;
            do
            {
                if (current.Value.Equals(value))
                {
                    if (current.Next == null)
                    {
                        if (prev == null)
                            Head = null;
                        else
                            prev.Next = null;
                        return;
                    }
                    else
                    {
                        if (prev == null)
                            Head = Head.Next;
                        else
                            prev.Next = current.Next;
                        return;
                    }
                }

                prev = current;
                current = current.Next;
            } while (current.Next != null);

            throw new Exception();
        }

        public T RemoveLast()
        {
            SinglyLinkedListNode<T> prev = null;
            var current = Head;
            while (current.Next != null)
            {
                prev = current;
                current = current.Next;
            }

            prev.Next = null;
            return current.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Print()
        {
            Console.WriteLine("------");
            foreach (var item in this)
                Console.WriteLine(item);
            Console.WriteLine("------");
        }
    }
}