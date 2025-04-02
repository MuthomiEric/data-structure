using System.Collections;

namespace DataStructures
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private Node? _top;

        public void Push(T data)
        {
            var newNode = new Node(data) { Next = _top };
            _top = newNode;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");

            var data = _top!.Data;
            _top = _top.Next;
            return data;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");
            return _top!.Data;
        }

        public bool IsEmpty()
        {
            return _top == null;
        }
        public IEnumerator<T> GetEnumerator()
        {
            var current = _top;
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
