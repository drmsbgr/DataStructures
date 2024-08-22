using System.Collections;

namespace DataStructuresLib.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedListEnumerator<T>(SinglyLinkedListNode<T> head) : IEnumerator<T>
    {
        private SinglyLinkedListNode<T> Head = head;
        private SinglyLinkedListNode<T> _current;

        public T Current => _current.Value;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            Head = null;
        }

        public bool MoveNext()
        {
            if (_current == null)
            {
                _current = Head;
                return true;
            }
            else
            {
                _current = _current.Next;

                return _current != null;
            }
        }

        public void Reset()
        {
            _current = null;
        }
    }
}