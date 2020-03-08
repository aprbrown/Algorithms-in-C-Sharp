using System;

namespace SortingAlgorithms
{
    /// <summary>
    /// An implementation of the Bubble Sort algorithm. Given an unsorted array, iterate over
    /// the array and compare two values, if the value on the left is greater than the value
    /// on the right, swap the values. Repeat from the beginning until a full pass over the
    /// array is made without any swaps.
    /// </summary>
    public class Bubble
    {
        public static int[] Sort(int[] unsortedArray)
        {
            // Make a copy of the incoming array, preserving its initial order.
            int[] sortedArray = new int[unsortedArray.Length];
            Array.Copy(unsortedArray, sortedArray, unsortedArray.Length);

            // iterations and swapped are to help with optimising such an inefficient
            // algorithm.
            int iterations = sortedArray.Length;
            bool swapped = false;

            // Outer loop stepping over the entirety of the array.
            for (int i = 0; i < sortedArray.Length; i++)
            {
                // Reset swapped to false at the start of the loop.
                swapped = false;

                // Inner loop to swap items in the array if the element on the left is
                // greater than the element on the right. After each loop, the depth of
                // the loop is reduced as the final item in the previous loop will be the
                // largest and in the correct position.
                for (int j = 1; j < iterations; j++)
                {
                    // Check if the item on the left is greater than the item on the right
                    // if so, store one value in temp, allocate the other in its position
                    // then allocate temp in its place. Flag swapped as true as another pass
                    // will definitely be required.
                    int temp;
                    if (sortedArray[j - 1] > sortedArray[j])
                    {
                        temp = sortedArray[j - 1];
                        sortedArray[j - 1] = sortedArray[j];
                        sortedArray[j] = temp;
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

            // Return the sorted array to the caller.
            return sortedArray;
        }
    }
}
