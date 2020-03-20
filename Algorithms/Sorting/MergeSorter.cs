// -----------------------------------------------------------------------------
// <copyright file="MergeSorter.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full
// license information.
// </copyright>
// -----------------------------------------------------------------------------

namespace Algorithms.Sorting
{
	using System;

	/// <summary>
	/// Implementation of the Merge Sort Algorithm. The incoming array is
	/// divided into n sub-arrays where n equals the number of elements in the
	/// array. The sub-arrays are then merged into new ordered sub-arrays. This
	/// continues until a final sorted array containing all elements is created.
	/// </summary>
	public static class MergeSorter
	{
		/// <summary>
		/// Public method to be called on an array ordering it from lowest to
		/// highest using the Merge Sort algorithm.
		/// </summary>
		/// <param name="array">An integer array to be sorted.</param>
		/// <returns>A sorted integer array.</returns>
		public static int[] MergeSort(this int[] array)
		{
			if (array == null || array.Length < 2)
			{
				return array;
			}

			int[] left, right, sortedArray;
			int midpoint = array.Length / 2;
			left = new int[midpoint];
			if (array.Length % 2 == 0)
			{
				right = new int[midpoint];
			}
			else
			{
				right = new int[midpoint + 1];
			}

			Array.Copy(array, 0, left, 0, midpoint);
			Array.Copy(array, midpoint, right, 0, array.Length - midpoint);
			left = MergeSort(left);
			right = MergeSort(right);
			sortedArray = Merge(left, right);
			return sortedArray;
		}

		/// <summary>
		/// Merges two incoming arrays into a new ordered array.
		/// </summary>
		/// <param name="left">Left side sub-array.</param>
		/// <param name="right">Right side sub-array.</param>
		/// <returns>A sorted array containing all elements of both left and
		/// right arrays.</returns>
		private static int[] Merge(int[] left, int[] right)
		{
			int combinedSize = left.Length + right.Length;
			int[] result = new int[combinedSize];
			int leftIndex = 0, rightIndex = 0, resultIndex = 0;
			while (leftIndex < left.Length && rightIndex < right.Length)
			{
				if (left[leftIndex] <= right[rightIndex])
				{
					result[resultIndex] = left[leftIndex];
					resultIndex++;
					leftIndex++;
				}
				else
				{
					result[resultIndex] = right[rightIndex];
					resultIndex++;
					rightIndex++;
				}
			}

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

			return result;
		}
	}
}
