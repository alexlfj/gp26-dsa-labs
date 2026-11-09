using System;
using System.Collections.Generic;

namespace DSA.Lab04B
{
    /// <summary>
    /// Priority queue implemented with a binary min-heap.
    ///
    /// Invariant:
    /// each parent's Priority is <= the Priority of each of its children.
    ///
    /// The heap is NOT fully sorted.
    /// </summary>
    public sealed class BinaryHeapDispatchQueue<T>
    {
        private readonly List<PriorityEntry<T>> _heap = new List<PriorityEntry<T>>();

        public int Count => _heap.Count;

        public void Enqueue(T item, int priority)
        {
            PriorityEntry<T> entry = new PriorityEntry<T>(item, priority);

            _heap.Add(entry);
            
            int entryIndex = _heap.Count - 1;
            
            SiftUp(entryIndex);
            
        }

        public PriorityEntry<T> PeekNext()
        {
            if (_heap.Count == 0)
            {
                throw new InvalidOperationException("The dispatch queue is empty.");
            }

            return _heap[0];
        }

        public PriorityEntry<T> DequeueNext()
        {
            if (_heap.Count == 0)
            {
                throw new InvalidOperationException("The dispatch queue is empty.");
            }

            if (_heap.Count == 1)
            {
                var entry = _heap[0];
                _heap.RemoveAt(0);
                return entry;
            }
            
            PriorityEntry<T> dequeuedEntry = _heap[0];
            
            PriorityEntry<T> lastEntry = _heap[^1];
            int lastEntryIndex = _heap.Count - 1;
            
            Swap(0, lastEntryIndex);
            
            _heap.RemoveAt(lastEntryIndex);
            
            SiftDown(0);
            
            return dequeuedEntry;

        }

        private void SiftUp(int index)
        {
            int parentIndex = ParentIndex(index);
            
            while (_heap[parentIndex].Priority > _heap[index].Priority)
            {
                Swap(parentIndex, index);
                
                index = parentIndex;
                parentIndex = ParentIndex(index);
            }
        }

        private void SiftDown(int index)
        {
            while (true)
            {
                int leftIndex = LeftChildIndex(index);
                int rightIndex = RightChildIndex(index);
                int lowestChildIndex = index;
                
                if (IsInHeap(rightIndex))
                {
                    lowestChildIndex = _heap[leftIndex].Priority < _heap[rightIndex].Priority ? leftIndex : rightIndex;
                }

                if (IsInHeap(leftIndex) && !IsInHeap(rightIndex))
                {
                    lowestChildIndex = leftIndex;
                }

                if (!IsInHeap(leftIndex))
                {
                    return;
                }
                
                if (_heap[lowestChildIndex].Priority >= _heap[index].Priority)
                {
                    return;
                }

                Swap(lowestChildIndex, index);
                index = lowestChildIndex;
            }
        }

        private static int ParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private static int LeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        private static int RightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        private void Swap(int a, int b)
        {
            PriorityEntry<T> temp = _heap[a];
            _heap[a] = _heap[b];
            _heap[b] = temp;
        }
        
        private bool IsInHeap(int index)
        {
            return index <= _heap.Count - 1;
        }
    }
}
