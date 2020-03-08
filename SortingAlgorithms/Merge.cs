﻿using System;

namespace SortingAlgorithms
{
    /// <summary>
    /// An implementation of the Merge Sort algorithm. An array of unsorted items is split in half.
    /// The split halves continue be split recursively until a single item array remains. The resulting 
    /// smallest arrays are then compared to one another and sorted into a separate array the length of 
    /// the combined smaller arrays. These smaller sorted arrays are then compared with each other and 
    /// sorted in the same way and work back up the recursive chain until a fully sorted array remains.
    /// </summary>
    public class Merge
    {
        public static int[] Sort(int[] unsortedArray)
        {
            // Create arrays for the left and right split of the incoming array and a result array
            // the same length as the incoming array.
            int[] left;
            int[] right;
            int[] result = new int[unsortedArray.Length];

            // If the incoming array is less than or equal to 1, return the incoming array as no split
            // is required and it can be considered sorted. This also prevents an infinite loop due to 
            // the recursive nature of the algorithm.
            if(unsortedArray.Length <= 1) return unsortedArray;

            // Determing the mid-point of the incoming array.
            int midpoint = unsortedArray.Length / 2;

            // Initialise the length of the left array to be that of the incoming array's midpoint.
            left = new int[midpoint];

            // Verify if the incoming array has an even or odd number of values. If it is even then
            // initialise in the same way as the left side, if it is odd, add one extra value.
            if (unsortedArray.Length % 2 == 0) right = new int[midpoint];
            else right = new int[midpoint + 1];

            // Copy the left and right sides of the incoming array into the left and right arrays.
            Array.Copy(unsortedArray, 0, left, 0, midpoint);
            Array.Copy(unsortedArray, midpoint, right, 0, unsortedArray.Length - midpoint);

            // Recursively sort both of the new arrays
            left = Sort(left);
            right = Sort(right);

            // Merge the sorted lists.
            result = MergeSort(left, right);

            // Return the final sorted result.
            return result;
        }

        private static int[] MergeSort(int[] left, int[] right)
        {
            // Create a new array the size of the two incoming lists combined.
            int combinedSize = left.Length + right.Length;
            int[] result = new int[combinedSize];

            // Initialise index values to track progress through the arrays.
            int leftIndex = 0, rightIndex = 0, resultIndex = 0;

            // Check if there are items remaining in both of the incoming arrays.
            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                // Compare the next value in the left array with the next value in
                // the right array. If left side is lower, add it to the next empty
                // space in the result array and increment left index an result index.
                if (left[leftIndex] <= right[rightIndex])
                {
                    result[resultIndex] = left[leftIndex];
                    resultIndex++;
                    leftIndex++;
                }
                // Alternatively if the right side is lower than the left, add the right
                // array value to the result, increment right index and result index.
                else
                {
                    result[resultIndex] = right[rightIndex];
                    resultIndex++;
                    rightIndex++;
                }
            }

            // If one side no longer has any remaining values, fill the remainder of the
            // result index with the left over items from the non-empty side.
            while (leftIndex < left.Length)
            {
                result[resultIndex] = left[leftIndex];
                resultIndex++;
                leftIndex++;
            }

            while (rightIndex < right.Length)
            {
                result[resultIndex] = right[rightIndex];
                resultIndex++;
                rightIndex++;
            }

            // Return the sorted array.
            return result;
        }
    }
}
