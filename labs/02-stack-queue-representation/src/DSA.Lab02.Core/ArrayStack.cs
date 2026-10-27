using System;

namespace DSA.Lab02
{
    public sealed class ArrayStack<T>
    {
        private readonly T[] _items;
        private int _count;

        public ArrayStack(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _items = new T[capacity];
        }
        
        public int Count => _count;
        public int Capacity => _items.Length;

        public void Push(T item)
        {
            if (item == null) { throw new InvalidOperationException(); }
            
            if (_count == Capacity)
            {
                throw new InvalidOperationException("Stack is full");
            }

            _items[_count] = item;
            _count++;
        }

        public T Peek()
        {
            return _items[_count - 1];
        }

        public T Pop()
        {
            
            if (_count == 0){ throw new InvalidOperationException(); }
            
            T poppedItem = _items[_count - 1];
            _items[_count - 1] = default;
            
            _count--;
            
            return poppedItem;

        }
    }
}
