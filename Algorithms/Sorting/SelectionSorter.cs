using System;

namespace Algorithms.Sorting
{
    /// <summary>
    /// An implementation of the Selection Sort algorithm. The algorithm uses two
    /// loops an outer and inner. The inner loop finds the smallest value in the
    /// remaining values of the outer loop. When the lowest number is found it is
    /// swapped with the position of the outer loop. Once the outer loop is complete
    /// the array will be in order.
    /// </summary>
    public static class SelectionSorter
    {
        public static int[] SelectionSort(this int[] unsortedArray)
        {
            // Make a copy of the incoming array, preserving its initial order.
            int[] sortedArray = new int[unsortedArray.Length];
            Array.Copy(unsortedArray, sortedArray, unsortedArray.Length);

            // Outer loop covering entire array
            for (int i = 0; i < sortedArray.Length; i++)
            {
                // Initialise min value to compare with the current location of
                // outer loop
                int min = sortedArray[i];
                // Not the index of the min value
                int minIndex = i;
                // Inner loop iterating over values above current position of 
                // outer loop
                for (int j = i + 1; j < sortedArray.Length; j++)
                {
                    // If the value in the inner loop is lower than current min
                    // value, replace min and minIndex with the current information.
                    if (sortedArray[j] < min) 
                    { 
                        min = sortedArray[j];
                        minIndex = j;
                    }
                }
                // Swap current outer value with that of the newly found lower value.
                if (minIndex != i)
                {
                    sortedArray[minIndex] = sortedArray[i];
                    sortedArray[i] = min;
                }
            }

            return sortedArray;
        }
    }
}
