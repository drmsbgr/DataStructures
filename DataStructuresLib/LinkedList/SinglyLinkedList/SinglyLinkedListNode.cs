namespace DataStructuresLib.LinkedList.SinglyLinkedList;

public class SinglyLinkedListNode<T>(T value)
{
    public T Value { get; set; } = value;
    public SinglyLinkedListNode<T>? Next { get; set; }
}
