namespace DataStructuresLib.LinkedList.DoublyLinkedList
{
    public class DoublyLinkedListNode<T>(T value)
    {
        public T Value { get; set; } = value;
        public DoublyLinkedListNode<T>? Prev { get; set; } = null;
        public DoublyLinkedListNode<T>? Next { get; set; } = null;
    }
}