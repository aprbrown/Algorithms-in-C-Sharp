using System;
using Algorithms.Helpers;

namespace Algorithms.Sorting
{
    /// <summary>
    /// An implementation of the HeapSort algorithm. The incoming array is first ordered
    /// into a max heap, such that the max value is located at index 0 and when visualised
    /// in a binary tree, no child element should be larger than a parent element. The first
    /// element is then switched with the last and 'removed' from the heap. The remaining 
    /// values are then sorted into a max heap again and the process repeats with the first
    /// element being replaced with the last in the heap.
    /// </summary>
    public static class HeapSorter
    {
        public static void HeapSort(this int[] array)
        {
            // Build the heap in the array so that the largest value is at the root
            BuildMaxHeap(array);

            // Loop so that values in array[0:end] is a heap and elements after are
            // greater than those before.
            int end = array.Length - 1;
            while (end > 0)
            {
                array.Swap(0, end);
                end--;
                SiftDown(array, 0, end);
            }
        }

        // Build the heap so that the maximum value is placed at index 0;
        private static void BuildMaxHeap(int[] array)
        {
            for (int i = (array.Length / 2); i >= 0; i--) MaxHeapify(array, i);
        }

        private static void MaxHeapify(int[] array, int i)
        {
            int left = 2 * i;
            int right = (2 * i) + 1;
            int largest = i;

            if (left < array.Length && array[left] > array[largest]) largest = left;
            if (right < array.Length && array[right] > array[largest]) largest = right;
            if (largest != i)
            {
                array.Swap(i, largest);
                MaxHeapify(array, largest);
            }
        }

        // Rebuild the heap for a subsection of the array.
        private static void SiftDown(int[] array, int start, int end)
        {
            int root = start;
            while (2 * root + 1 <= end)
            {
                int child = 2 * root + 1;
                int swap = root;

                if (array[swap] < array[child]) swap = child;
                if (child + 1 <= end && array[swap] < array[child + 1]) swap = child + 1;
                if (swap == root) return;
                else
                {
                    array.Swap(root, swap);
                    root = swap;
                }
            }
        }
    }
}
