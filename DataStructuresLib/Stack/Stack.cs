namespace DataStructuresLib.Stack
{
    public class Stack<T>
    {
        private readonly IStack<T> stack;
        public int Count => stack.Count;
        public Stack(StackTypes type = StackTypes.Array)
        {
            switch (type)
            {
                case StackTypes.Array:
                    stack = new ArrayStack<T>();
                    break;
                case StackTypes.LinkedList:
                    stack = new LinkedListStack<T>();
                    break;
            }
        }

        public T Pop() => stack.Pop();

        public T Peek() => stack.Peek();
        public void Push(T value) => stack.Push(value);
    }

    public interface IStack<T>
    {
        int Count { get; }
        void Push(T value);
        T Pop();
        T Peek();
    }

    public enum StackTypes
    {
        Array,
        LinkedList
    }
}
