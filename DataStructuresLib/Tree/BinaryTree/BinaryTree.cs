using DataStructuresLib.Stack;

namespace DataStructuresLib.Tree.BinaryTree
{
    public class BinaryTree<T> where T : IComparable
    {
        private readonly List<Node<T>> list;
        public BinaryTree()
        {
            list = [];
        }
        public List<Node<T>> InOrder(Node<T> root)
        {
            if (root != null)
            {
                InOrder(root.Left);
                list.Add(root);
                InOrder(root.Right);
            }
            return list;
        }

        public List<Node<T>> PreOrder(Node<T> root)
        {
            if (root != null)
            {
                list.Add(root);
                PreOrder(root.Left);
                PreOrder(root.Right);
            }
            return list;
        }

        public List<Node<T>> PostOrder(Node<T> root)
        {
            if (root != null)
            {
                PostOrder(root.Left);
                PostOrder(root.Right);
                list.Add(root);
            }
            return list;
        }

        public List<T> NonRecursivePreOrder(Node<T> root)
        {
            List<T> result = [];
            Stack.Stack<Node<T>> stack = new();
            var currentNode = root;
            bool done = false;

            while (!done)
            {
                if (currentNode != null)
                {
                    stack.Push(currentNode);
                    result.Add(currentNode.Value);
                    currentNode = currentNode.Left;
                }
                else
                {
                    if (stack.Count == 0)
                        done = true;
                    else
                        currentNode = stack.Pop().Right;
                }
            }

            return result;
        }

        public List<T> NonRecursiveInOrder(Node<T> root)
        {
            List<T> result = [];
            Stack.Stack<Node<T>> stack = new();
            var currentNode = root;
            bool done = false;

            while (!done)
            {
                if (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else
                {
                    if (stack.Count == 0)
                        done = true;
                    else
                    {
                        currentNode = stack.Pop();
                        result.Add(currentNode.Value);
                        currentNode = currentNode.Right;
                    }
                }
            }

            return result;
        }

        public List<Node<T>> LevelOrder(Node<T> root)
        {
            List<Node<T>> result = [];
            Queue<Node<T>> queue = new();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var temp = queue.Dequeue();
                result.Add(temp);
                if (temp.Left != null)
                    queue.Enqueue(temp.Left);
                if (temp.Right != null)
                    queue.Enqueue(temp.Right);
            }

            return result;
        }

        public static int MaxDepth(Node<T> root)
        {
            if (root == null)
                return 0;

            int leftDepth = MaxDepth(root.Left);
            int rightDepth = MaxDepth(root.Right);

            return rightDepth > leftDepth ? rightDepth + 1 : leftDepth + 1;
        }

        public Node<T> DeepestNode(Node<T> root)
        {
            Node<T> temp = null;
            ArgumentNullException.ThrowIfNull(root);

            var q = new Queue.Queue<Node<T>>();

            q.Enqueue(root);

            while (q.Count > 0)
            {
                temp = q.Dequeue();
                if (temp.Left != null)
                    q.Enqueue(temp.Left);
                if (temp.Right != null)
                    q.Enqueue(temp.Right);
            }

            return temp;
        }

        public static int NumberOfLeafs(Node<T> root)
        {
            int count = 0;
            var q = new Queue.Queue<Node<T>>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var temp = q.Dequeue();
                if (temp.Left == null && temp.Right == null)
                    count++;

                if (temp.Left != null)
                    q.Enqueue(temp.Left);
                if (temp.Right != null)
                    q.Enqueue(temp.Right);
            }

            return count;
        }

        public static int NumberOfFullNodes(Node<T> root) =>
            new BinaryTree<T>()
            .LevelOrder(root)
            .Count(node => node.Left != null && node.Right != null);

        public static int NumberOfHalfNodes(Node<T> root) =>
            new BinaryTree<T>()
            .LevelOrder(root)
            .Count(node => (node.Left == null && node.Right != null) || (node.Left != null && node.Right == null));

        public void PrintPaths(Node<T> root)
        {
            var path = new T[256];
            BinaryTree<T>.PrintPaths(root, path, 0);
        }

        private static void PrintPaths(Node<T> root, T[] path, int pathLen)
        {
            if (root == null) return;
            path[pathLen] = root.Value;
            pathLen++;

            if (root.Left == null && root.Right == null)
                BinaryTree<T>.PrintArray(path, pathLen);
            else
            {
                BinaryTree<T>.PrintPaths(root.Left, path, pathLen);
                BinaryTree<T>.PrintPaths(root.Right, path, pathLen);
            }
        }

        private static void PrintArray(T[] path, int pathLen)
        {
            for (int i = 0; i < pathLen; i++)
                Console.Write($"{path[i]} ");
            Console.WriteLine();
        }
    }
}
