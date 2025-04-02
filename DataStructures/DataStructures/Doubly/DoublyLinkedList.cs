namespace DataStructures.Doubly
{
    public class DoublyLinkedList<T>
    {
        private int _size;
        private Node<T>? _head;
        private Node<T>? _tail;

        public void InsertAtEnd(T data)
        {
            var newNode = new Node<T>(data);
            _size++;
            if (IsEmpty())
            {
                _head = _tail = newNode;
                return;
            }
            _tail!.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }

        public void InsertAtBeginning(T data)
        {
            var newNode = new Node<T>(data) { Next = _head };
            _size++;
            if (IsEmpty())
            {
                _head = _tail = newNode;
                return;
            }
            _head!.Prev = newNode;
            _head = newNode;
        }

        public bool Delete(T data)
        {
            if (IsEmpty()) return false;
            if (_head!.Data!.Equals(data))
            {
                _head = _head.Next;
                if (_head != null)
                    _head.Prev = null;

                else _tail = null;
                _size--;
                return true;
            }
            var temp = _head;
            while (temp != null && !temp.Data!.Equals(data))
            {
                temp = temp.Next;
            }
            if (temp == null) return false;// Means no record was found
            if (temp == _tail)
            {
                _tail = temp.Prev;
                _tail!.Next = null;
            }
            else
            {
                temp.Prev!.Next = temp.Next;
                if (temp.Next != null)
                    temp.Next.Prev = temp.Prev;
            }
            _size--;
            return true;
        }

        public bool Search(T data)
        {
            var temp = _head;
            while (!IsEmpty())
            {
                if (temp!.Data!.Equals(data)) return true;
                temp = temp.Next;
            }
            return false;
        }
        private int size()
        {
            return _size;
        }

        public bool IsEmpty()
        {
            return size() == 0;
        }

        public void PrintList()
        {
            var temp = _head;
            while (temp != null)
            {
                Console.Write(temp.Data + " <-> ");
                temp = temp.Next;
            }
            Console.WriteLine("null");
        }

        private class Node<Type>
        {
            public Type Data { get; set; }
            public Node<Type>? Next { get; set; }
            public Node<Type>? Prev { get; set; }

            public Node(Type data)
            {
                Data = data;
                Next = null;
                Prev = null;
            }
        }
    }

}