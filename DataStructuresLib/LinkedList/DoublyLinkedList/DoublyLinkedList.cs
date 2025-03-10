using System.Collections;
using System.Runtime.Versioning;
using System.Security;
using DataStructuresLib.Contracts;

namespace DataStructuresLib.LinkedList.DoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable, IPrintable
    {
        public DoublyLinkedList()
        {

        }
        public DoublyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                AddLast(item);
        }

        public DoublyLinkedListNode<T> Head;
        public DoublyLinkedListNode<T> Tail;

        public void AddFirst(T value)
        {
            var newHead = new DoublyLinkedListNode<T>(value);

            if (Head != null)
            {
                Head.Prev = newHead;
                newHead.Next = Head;
            }

            Head = newHead;

            Tail ??= Head;
        }

        public void AddBefore(T value, DoublyLinkedListNode<T> refNode)
        {
            var newNode = new DoublyLinkedListNode<T>(value);

            if (refNode == Head || refNode == Head && refNode == Tail)
            {
                AddFirst(value);
                return;
            }

            refNode.Prev.Next = newNode;
            newNode.Prev = refNode.Prev.Next;
            refNode.Prev = newNode;
            newNode.Next = refNode;
        }

        public void AddAfter(T value, DoublyLinkedListNode<T> refNode)
        {
            var newNode = new DoublyLinkedListNode<T>(value);

            if (refNode == Tail || refNode == Head && refNode == Tail)
            {
                AddLast(value);
                return;
            }

            newNode.Next = refNode.Next;
            refNode.Next.Prev = newNode;

            refNode.Next = newNode;
            newNode.Prev = refNode;
        }

        public void AddLast(T value)
        {
            var newTail = new DoublyLinkedListNode<T>(value);

            if (Tail != null)
            {
                newTail.Prev = Tail;
                Tail.Next = newTail;
            }

            Tail = newTail;

            Head ??= newTail;
        }

        public List<DoublyLinkedListNode<T>> GetAllNodes()
        {
            List<DoublyLinkedListNode<T>> nodes = [];
            var current = Head;

            while (current != null)
            {
                nodes.Add(current);
                current = current.Next;
            }

            return nodes;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetAllNodes().GetEnumerator();

        public T RemoveFirst()
        {
            if (Head == null)
                throw new NullReferenceException("Listede eleman yok.");

            var temp = Head.Value;

            if (Head == Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Head = Head.Next;
                Head.Prev = null;
            }

            return temp;
        }

        public void Delete(T value)
        {
            if (Head == null)
                throw new NullReferenceException("liste boþ!");

            if (Head == Tail && Head.Value.Equals(value))
            {
                RemoveFirst();
                return;
            }

            var current = Head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (current.Prev == null)
                    {
                        current.Next.Prev = null;
                        Head = current.Next;
                    }
                    else if (current.Next == null)
                    {
                        current.Prev.Next = null;
                        Tail = current.Prev;
                    }
                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }
                    break;
                }
                current = current.Next;
            }
        }

        public T RemoveLast()
        {
            if (Tail == null)
                throw new NullReferenceException("Listede eleman yok.");

            var temp = Tail.Value;

            if (Head == Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail = Tail.Prev;
                Tail.Next = null;
            }

            return temp;
        }

        public void Print()
        {
            Console.WriteLine("------");
            foreach (var node in GetAllNodes())
            {
                Console.WriteLine(node.Value);
            }
            Console.WriteLine("------");
        }
    }
}