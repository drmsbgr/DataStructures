namespace DataStructuresLib.Stack
{
    public class ArrayStack<T> : IStack<T>
    {
        public int Count { get; private set; }
        private readonly List<T> list = new();

        public T Peek()
        {
            if (Count == 0)
                throw new Exception("Silinecek eleman yok.");

            return list[Count - 1];
        }

        public T Pop()
        {
            if (Count == 0)
                throw new Exception("Silinecek eleman yok.");

            var temp = list[^1];
            list.RemoveAt(Count - 1);
            Count--;
            return temp;
        }

        public void Push(T value)
        {
            if (value == null)
                return;
            list.Add(value);
            Count++;
        }
    }
}