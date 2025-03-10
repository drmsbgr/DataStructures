using DataStructuresLib.LinkedList.DoublyLinkedList;
using DataStructuresLib.LinkedList.SinglyLinkedList;
using DataStructuresLib.Tree.BST;
using DataStructuresLib.Tree.BinaryTree;
using DataStructuresLib.Heap;
using DataStructuresLib.Shared;
using DesignPatterns;

namespace ConsoleApp;

public class Program
{
    public static void Main(string[] args)
    {
        var heap = new MinHeap<int>([1, 4, 8, 7, 5, 10, 9, 11, 9, 6, 2]);
        var heap2 = new MaxHeap<int>([3, 4, 12, 43, 21, 8, 10, 5, 6, 7]);
        var heap3 = new BinaryHeap<int>(SortDirections.Descending, [33, 22, 11, 5, 4, 3, 2, 1]);

        foreach (var item in heap3)
            Console.Write(item + "  ");


        Console.ReadKey();
    }

    private static void BinaryTreeExamples()
    {
        Console.WriteLine(nameof(BinaryTreeExamples));
        BST<int> bst = [];
        bst.Add(5);
        bst.Add(3);
        bst.Add(10);
        bst.Add(2);
        bst.Add(4);
        bst.Add(9);
        bst.Add(11);
        bst.Add(32);

        Console.WriteLine("Recursive PreOrder");
        new BinaryTree<int>().PreOrder(bst.Root).ForEach(x => Console.Write(x + " "));

        Console.WriteLine("\n\nRecursive InOrder");
        new BinaryTree<int>().InOrder(bst.Root).ForEach(x => Console.Write(x + " "));

        Console.WriteLine("\n\nRecursive PostOrder");
        new BinaryTree<int>().PostOrder(bst.Root).ForEach(x => Console.Write(x + " "));

        Console.WriteLine("\n\nNonRecursive PreOrder");
        new BinaryTree<int>().NonRecursivePreOrder(bst.Root).ForEach(x => Console.Write(x + " "));

        Console.WriteLine("\n\nNonRecursive InOrder");
        new BinaryTree<int>().NonRecursiveInOrder(bst.Root).ForEach(x => Console.Write(x + " "));

        Console.WriteLine("\n\nNonRecursive LevelOrder");
        new BinaryTree<int>().LevelOrder(bst.Root).ForEach(x => Console.Write(x + " "));

        Console.WriteLine("\n\nMinimum");
        Console.Write(bst.GetMinimum(bst.Root));

        Console.WriteLine("\n\nMaximum");
        Console.Write(bst.GetMaximum(bst.Root));

        Console.WriteLine("\n\nMax Depth");
        Console.Write(BinaryTree<int>.MaxDepth(bst.Root));

        Console.WriteLine("\n\nDeepest Node");
        Console.Write(new BinaryTree<int>().DeepestNode(bst.Root));

        Console.WriteLine("\n\nLeaf Count");
        Console.Write(BinaryTree<int>.NumberOfLeafs(bst.Root));

        Console.WriteLine("\n\nFull Nodes Count");
        Console.Write(BinaryTree<int>.NumberOfFullNodes(bst.Root));

        Console.WriteLine("\n\nHalf Nodes Count");
        Console.Write(BinaryTree<int>.NumberOfHalfNodes(bst.Root));

        Console.WriteLine("\n\nPaths");
        new BinaryTree<int>().PrintPaths(bst.Root);

        Console.WriteLine("\n\nEnumeratorTest");
        foreach (var node in bst)
            Console.WriteLine(node);
    }

    private static void DoublyLinkedListExample02()
    {
        Console.WriteLine(nameof(DoublyLinkedListExample02));
        var list = new DoublyLinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);
        list.RemoveFirst();
    }
    private static void DoublyLinkedListExample01()
    {
        Console.WriteLine(nameof(DoublyLinkedListExample01));
        var list = new DoublyLinkedList<int>();
        list.AddFirst(2);
        list.AddFirst(1);
        list.AddLast(3);
        list.AddAfter(99, list.Tail);
        list.AddAfter(33, list.Head);
        list.AddBefore(5, list.Head);
        list.Print();
    }
    private static void DesignPatternExample01()
    {
        Console.WriteLine(nameof(DesignPatternExample01));
        int[] liste = { 12, 1432, 23, 12, 43, 45 };

        SampleIterator iterator = new(liste);
        for (iterator.First(); !iterator.IsDone(); iterator.Next())
        {
            Console.WriteLine(iterator.CurrentItem());
        }
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