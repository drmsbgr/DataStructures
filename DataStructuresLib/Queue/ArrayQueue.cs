namespace DataStructuresLib.Queue
{
    public class ArrayQueue<T> : IQueue<T>
    {
        private readonly List<T> list = [];
        public int Count { get; private set; }

        public T Dequeue()
        {
            if (Count == 0)
                throw new Exception();

            var temp = list[0];
            list.RemoveAt(0);
            Count--;
            return temp;
        }

        public void Enqueue(T value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value), "null");
            list.Add(value);
            Count++;
        }

        public T Peek()
        {
            if (Count == 0)
                throw new Exception();
            return list[0];
        }
    }
}