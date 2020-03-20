// -----------------------------------------------------------------------------
// <copyright file="QuickSorter.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full
// license information.
// </copyright>
// -----------------------------------------------------------------------------

namespace Algorithms.Sorting
{
	using Algorithms.Helpers;

	/// <summary>
	/// Implementation of the Quick Sort Algorithm. An element from the array is
	/// selected and named the pivot. Where some implementations take the
	/// rightmost element for the pivot, the median of three values is chosen
	/// instead. The array is then partitioned so that all elements lower than
	/// the pivot are on the left and those greater than the pivot are on the
	/// right. This process is then applied recursively until the array is in
	/// order.
	/// </summary>
	public static class QuickSorter
	{
		/// <summary>
		/// Public method to be called on an array ordering it from lowest to
		/// highest using the QuickSort algorithm.
		/// </summary>
		/// <param name="array">An integer array to be sorted.</param>
		/// <param name="left">Index of the leftmost element to be
		/// sorted.</param>
		/// <param name="right">Index of the rightmost element to be
		/// sorted.</param>
		public static void QuickSort(
			this int[] array, int left = 0, int right = -1)
		{
			if (array == null || array.Length < 2)
			{
				return;
			}

			if (right == -1)
			{
				right = array.Length - 1;
			}

			if (left < right)
			{
				int pivot = Partition(array, left, right);
				QuickSort(array, left, pivot);
				QuickSort(array, pivot + 1, right);
			}
		}

		/// <summary>
		/// Reorder the elements in the array so items lower than pivot are on
		/// the left and items greater than the pivot are on the right and then
		/// calculate a new pivot for recursive calls.
		/// </summary>
		/// <param name="array">An integer array to be sorted.</param>
		/// <param name="left">Index of the leftmost element to be
		/// sorted.</param>
		/// <param name="right">Index of the rightmost element to be
		/// sorted.</param>
		/// <returns>Integer to be used as the next pivot.</returns>
		private static int Partition(int[] array, int left, int right)
		{
			int mid = (left + right) / 2;
			if (array[mid] < array[left])
			{
				array.Swap(left, mid);
			}

			if (array[right] < array[left])
			{
				array.Swap(left, right);
			}

			if (array[mid] < array[right])
			{
				array.Swap(mid, right);
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

				if (left >= right)
				{
					return right;
				}

				array.Swap(left, right);
				if (array[left] == array[right])
				{
					left++;
					right--;
				}
			}
		}
	}
}
