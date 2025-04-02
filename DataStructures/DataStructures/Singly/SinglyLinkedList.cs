namespace DataStructures.Singly
{
    internal class SinglyLinkedList<T>
    {
        private int _size;
        private Node? _head = default;
        private Node? _tail = default;

        public void InsertAtEnd(T data)
        {
            var newNode = new Node(data);
            _size++;
            if (IsEmpty())
            {
                _head = _tail = newNode;
                return;
            }
            _tail!.Next = newNode;
        }

        public void InsertAtBeginning(T data)
        {
            var newNode = new Node(data) { Next = _head };

            // Move the head to the new node
            _head = newNode;
            // Check whether the this was the first insert
            if (_tail == null)
                _tail = _head;
            _size++;
        }

        // Assumes there is no duplicate
        public bool Delete(T data)
        {
            if (IsEmpty()) return false;
            if (_head!.Data!.Equals(data))
            {
                _head = _head.Next;
                if (_head == null) _tail = null;
                _size--;
                return true;
            }
            var temp = _head;
            while (temp.Next != null && !temp.Next.Data!.Equals(data))
            {
                temp = temp.Next;
            }
            if (temp.Next == null) return false;
            if (temp.Next == _tail)
            {
                _tail = temp;
            }
            temp.Next = temp.Next.Next;
            _size--;
            return true;
        }

        public bool Search(T data)
        {
            var temp = _head;
            while (temp != null)
            {
                if (temp.Data!.Equals(data)) return true;
                temp = temp.Next;
            }
            return false;
        }

        public void PrintList()
        {
            var temp = _head;
            while (temp != null)
            {
                Console.Write(temp.Data + " -> ");
                temp = temp.Next;
            }
            Console.WriteLine("null");
        }
        private int size()
        {
            return _size;
        }

        public bool IsEmpty()
        {
            return size() == 0;
        }
        private class Node
        {
            public Node(T data)
            {
                Data = data;
                Next = null;
            }
            public T Data { get; set; }
            public Node? Next { get; set; }
        }
    }
}
