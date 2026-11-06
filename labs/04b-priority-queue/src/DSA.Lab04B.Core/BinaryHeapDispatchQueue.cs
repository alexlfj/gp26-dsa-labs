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
            int parentIndex = ParentIndex(entryIndex);
            
            SiftUp(entryIndex);
            
        }

        public PriorityEntry<T> PeekNext()§
        {
            if (_heap.Count == 0)
            {
                throw new InvalidOperationException("The dispatch queue is empty.");
            }

            return _heap[0];
        }

        public PriorityEntry<T> DequeueNext()
        {
            
            // Store the original root
            PriorityEntry<T> dequeuedEntry = _heap[0];
            
            // Get the last entry and its index
            PriorityEntry<T> lastEntry = _heap[^1];
            int lastEntryIndex = _heap.Count - 1;
            
            // Move the final entry to the root position
            Swap(0, lastEntryIndex);
            
            // Remove the slot where that final entry was
            _heap.RemoveAt(lastEntryIndex);
            
            // Restore the invariant via Sift Down
            SiftDown(0);
            
            // Return the original root
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
                int LeftIndex = LeftChildIndex(index);
                int RightIndex = RightChildIndex(index);

                int lowestChildIndex = _heap[LeftIndex].Priority < _heap[RightIndex].Priority ? LeftIndex : RightIndex;

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
    }
}
