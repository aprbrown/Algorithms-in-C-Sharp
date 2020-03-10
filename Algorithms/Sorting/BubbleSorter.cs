using System;
using Algorithms.Helpers;

namespace Algorithms.Sorting
{
    /// <summary>
    /// An implementation of the Bubble Sort algorithm. Given an unsorted array, iterate over
    /// the array and compare two values, if the value on the left is greater than the value
    /// on the right, swap the values. Repeat from the beginning until a full pass over the
    /// array is made without any swaps.
    /// </summary>
    public static class BubbleSorter
    {
        public static int[] BubbleSort(this int[] unsortedArray)
        {
            // Make a copy of the incoming array, preserving its initial order.
            int[] sortedArray = new int[unsortedArray.Length];
            Array.Copy(unsortedArray, sortedArray, unsortedArray.Length);

            // iterations and swapped are to help with optimisation.
            int iterations = sortedArray.Length;
            bool swapped = false;

            // Outer loop stepping over the entirety of the array.
            for (int i = 0; i < sortedArray.Length; i++)
            {
                // Reset swapped to false at the start of the loop.
                swapped = false;

                // Inner loop to swap items in the array so the element on the left is
                // lower than the element on the right. The number of iterations for the 
                // loop is reduced each time since the final value will be in the correct
                // position.
                for (int j = 1; j < iterations; j++)
                {
                    // Check if the item on the left is greater than the item on the right
                    // if so, swap values and flag swapped as true for another pass.
                    if (sortedArray[j - 1] > sortedArray[j])
                    {
                        sortedArray.Swap(j - 1, j);
                        swapped = true;
                    }
                }
                // Reduce the number of iterations as final item in last run will now be in the
                // correct place.
                iterations--;

                // If there were no swaps made in the loop then the array is in order, break out
                // of the outer loop.
                if (!swapped) break;
            }

            // Return the sorted array.
            return sortedArray;
        }
    }
}
