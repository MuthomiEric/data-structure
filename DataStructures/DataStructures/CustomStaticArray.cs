using System.Collections;

namespace DataStructures
{
    internal class CustomStaticArray<T> : IEnumerable<T>
    {
        private static T[] _array;
        private static int _count; // Tracks the number of elements

        // initializes the array with default size
        static CustomStaticArray()
        {
            _array = new T[2];
            _count = 0;
        }

        public void Add(T value)
        {           
            // Resize if array is full
            if (_count == _array.Length)
            {
                ResizeArray();
            }
            _array[_count] = value;
            _count++;
        }

        // Resize method (doubles the size when full)
        private static void ResizeArray()
        {
            int newSize = _array.Length * 2;
            T[] newArray = new T[newSize];
            Array.Copy(_array, newArray, _array.Length);
            _array = newArray;
        }

        // Get element at index
        public T Get(int index)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException("Index out of bounds");
            return _array[index];
        }

        // Foreach loop support
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
