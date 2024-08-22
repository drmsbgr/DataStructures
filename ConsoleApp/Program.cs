using DataStructuresLib.LinkedList.SinglyLinkedList;

namespace ConsoleApp;

public class Program
{
    public static void Main(string[] args)
    {
        var list = new SinglyLinkedList<int>();
        list.AddFirst(1);
        list.AddFirst(3);
        list.AddFirst(5);
        list.AddFirst(7);
        list.AddLast(-1);
        list.AddLast(-3);

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        Console.ReadKey();
    }
}