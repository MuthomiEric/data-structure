using System.Collections;

namespace DataStructures
{
    internal class CustomQueue<T> : IEnumerable<T>
    {

        private Node? _front;
        private Node? _rear;

        public void Enqueue(T data)
        {
            var newNode = new Node(data);
            if (IsEmpty())
            {
                _front = _rear = newNode;
            }
            else
            {
                _rear!.Next = newNode;
                _rear = newNode;
            }
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty.");

            var data = _front!.Data;
            _front = _front.Next;
            if (_front == null)
            {
                _rear = null;
            }
            return data;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue is empty.");
            return _front!.Data;
        }

        public bool IsEmpty()
        {
            return _front == null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node? current = _front;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class Node
        {
            public T Data { get; set; }
            public Node? Next { get; set; }

            public Node(T data)
            {
                Data = data;
                Next = null;
            }
        }
    }
}
