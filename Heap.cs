using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityApp
{
    public class MinHeap<T> where T : IComparable<T>
    {
        private List<T> heap = new List<T>();

        // Insert element into the heap
        public void Insert(T item)
        {
            heap.Add(item);
            SiftUp(heap.Count - 1);
        }

        // Remove and return the minimum (root) element
        public T ExtractMin()
        {
            if (heap.Count == 0) throw new InvalidOperationException("Heap is empty.");

            T min = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            SiftDown(0);
            return min;
        }

        // Helper function to sift up an element
        private void SiftUp(int index)
        {
            while (index > 0 && heap[(index - 1) / 2].CompareTo(heap[index]) > 0)
            {
                T temp = heap[index];
                heap[index] = heap[(index - 1) / 2];
                heap[(index - 1) / 2] = temp;
                index = (index - 1) / 2;
            }
        }

        // Helper function to sift down an element
        private void SiftDown(int index)
        {
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;
            int smallest = index;

            if (leftChild < heap.Count && heap[leftChild].CompareTo(heap[smallest]) < 0)
            {
                smallest = leftChild;
            }

            if (rightChild < heap.Count && heap[rightChild].CompareTo(heap[smallest]) < 0)
            {
                smallest = rightChild;
            }

            if (smallest != index)
            {
                T temp = heap[index];
                heap[index] = heap[smallest];
                heap[smallest] = temp;
                SiftDown(smallest);
            }
        }

        // Get all elements in the heap without removing them (for display purposes)
        public List<T> GetAllElements()
        {
            List<T> elements = new List<T>(heap);
            return elements;
        }

        // Peek at the minimum element without removing it
        public T PeekMin()
        {
            if (heap.Count == 0) throw new InvalidOperationException("Heap is empty.");
            return heap[0];
        }
    }
}
