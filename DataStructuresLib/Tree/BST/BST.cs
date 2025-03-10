using System.Collections;
using DataStructuresLib.Tree.BinaryTree;

namespace DataStructuresLib.Tree.BST
{
    public class BST<T> : IEnumerable<T> where T : IComparable
    {
        public Node<T>? Root { get; private set; }
        public BST()
        {

        }

        public BST(IEnumerable<T> collection)
        {
            foreach (var item in collection)
                Add(item);
        }

        public Node<T> GetMinimum(Node<T> root)
        {
            ArgumentNullException.ThrowIfNull(root);
            var currentNode = root;

            while (currentNode.Left != null)
                currentNode = currentNode.Left;

            return currentNode;
        }

        public Node<T> GetMaximum(Node<T> root)
        {
            ArgumentNullException.ThrowIfNull(root);
            var currentNode = root;

            while (currentNode.Right != null)
                currentNode = currentNode.Right;

            return currentNode;
        }

        public Node<T> Get(Node<T> root, T key)
        {
            var current = root;

            while (!current.Value.Equals(key))
            {
                if (key.CompareTo(current.Value) < 0)
                    current = current.Left;
                else
                    current = current.Right;

                if (current == null)
                    throw new Exception("Aranan değer bulunamadı.");
            }

            return current;
        }

        public Node<T> Remove(Node<T> root, T key)
        {
            if (root == null)
                return root;

            if (key.CompareTo(root.Value) < 0)
                root.Left = Remove(root.Left, key);
            else if (key.CompareTo(root.Value) > 0)
                root.Right = Remove(root.Right, key);
            else
            {
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;

                root.Value = GetMaximum(root.Right).Value;
                root.Right = Remove(root.Right, root.Value);
            }
            return root;
        }

        public void Add(T value)
        {

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var newNode = new Node<T>(value);

            if (Root == null)
                Root = newNode;
            else
            {
                var current = Root;
                Node<T> parent;
                while (true)
                {
                    parent = current;
                    if (value.CompareTo(current.Value) < 0)
                    {
                        current = current.Left;
                        if (current == null)
                        {
                            parent.Left = newNode;
                            break;
                        }
                    }
                    else
                    {
                        current = current.Right;
                        if (current == null)
                        {
                            parent.Right = newNode;
                            break;
                        }
                    }
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new BSTEnumerator<T>(Root);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
