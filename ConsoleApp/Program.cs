using DataStructuresLib.LinkedList.SinglyLinkedList;

namespace ConsoleApp;

public class Program
{
    public static void Main(string[] args)
    {
        SinglyLinkedListExample02();
        Console.ReadKey();
    }

    private static void SinglyLinkedListExample02()
    {
        Console.WriteLine(nameof(SinglyLinkedListExample02));
        var list = new SinglyLinkedList<int>();
        list.AddLast(5);
        list.AddLast(2);
        list.AddLast(1);
        list.Print();
        Console.WriteLine($"{list.RemoveFirst()} listeden kaldırıldı");
        list.Print();
        list.RemoveLast();
        list.Print();
    }
    private static void SinglyLinkedListExample01()
    {
        Console.WriteLine(nameof(SinglyLinkedListExample01));
        var list = new SinglyLinkedList<int>();
        list.AddFirst(7);
        list.AddFirst(5);
        list.AddFirst(3);
        list.AddFirst(1);
        list.Print();

        var list2 = new SinglyLinkedList<int>(list);
        list2.AddLast(9);
        list2.AddLast(11);
        list2.Print();
    }
}