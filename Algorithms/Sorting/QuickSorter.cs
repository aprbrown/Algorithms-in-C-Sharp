using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    /// <summary>
    /// An implementation of the quicksort algorithm. A 'pivot' element is chosen from the unsorted
    /// array and the remaining values are sorted into two sub-arrays, one containing items lower
    /// than the pivot and another containing items higher than the pivot. The sub-arrays are then
    /// sorted recursively. The algorithm occurs 'in-place' meaning the sub-arrays are not newly
    /// created arrays, instead they are sections of the existing array. This results in much reduced
    /// memory requirements compared to a solution such as merge-sort reducing the space-complexity
    /// of the algorithm.
    /// </summary>
    public static class QuickSorter
    {
        /// <summary>
        /// Calling Quick.Sort and passing an unsorted integer array will return a new integer array
        /// sorted in order from lowest to highest.
        /// </summary>
        /// <param name="unsortedArray">An integer Array of unsorted elements to be sorted.</param>
        /// <returns>A new integer array containing the elements of the unsorted array in order.</returns>
        public static int[] QuickSort(this int[] unsortedArray)
        {
            // Make a copy of the incoming array, preserving its initial order.
            int[] sortedArray = new int[unsortedArray.Length];
            Array.Copy(unsortedArray, sortedArray, unsortedArray.Length);

            // So the caller of the sort doesn't need to specify indexes for the
            // array, a separate sorting method is used leaving implementation detail
            // obfuscated.
            Sort(sortedArray, 0, sortedArray.Length - 1);

            return sortedArray;
        }

        private static void Sort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(array, left, right);
                Sort(array, left, pivot);
                Sort(array, pivot + 1, right);
            }
        }

        private static int Partition(int[] array, int left, int right)
        {
            int mid = (left + right) / 2;
            if (array[mid] < array[left])
            {
                int temp = array[left];
                array[left] = array[mid];
                array[mid] = temp;
            }
            if (array[right] < array[left])
            {
                int temp = array[left];
                array[left] = array[right];
                array[right] = temp;
            }
            if (array[mid] < array[right])
            {
                int temp = array[mid];
                array[mid] = array[right];
                array[right] = temp;
            }
            int pivot = array[right];

            while (true)
            {
                while (array[left] < pivot) 
                { 
                    left++;
                }
                while (array[right] > pivot) 
                { 
                    right--;
                }
                if (left >= right) return right;
                
                int temp = array[left];
                array[left] = array[right];
                array[right] = temp;

                // To prevent the algorithm getting stuck when encountering duplicates
                // a check is made to increment the indexes outside of the while loops.
                if(array[left] == array[right])
                {
                    left++;
                    right--;
                }
            }
        }
    }
}
