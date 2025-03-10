namespace DataStructuresLib.Queue
{
    public class Queue<T>
    {
        private readonly IQueue<T> queue;
        public int Count => queue.Count;

        public Queue(QueueType type = QueueType.Array)
        {
            switch (type)
            {
                case QueueType.Array:
                    queue = new ArrayQueue<T>();
                    break;
                case QueueType.LinkedList:
                    queue = new LinkedListQueue<T>();
                    break;
            }
        }

        public void Enqueue(T value) => queue.Enqueue(value);
        public T Dequeue() => queue.Dequeue();
        public T Peek() => queue.Peek();
    }

    public interface IQueue<T>
    {
        int Count { get; }
        void Enqueue(T item);
        T Dequeue();
        T Peek();
    }

    public enum QueueType
    {
        Array,
        LinkedList
    }
}
