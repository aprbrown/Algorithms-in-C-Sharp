// -----------------------------------------------------------------------------
// <copyright file="SelectionSorter.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full
// license information.
// </copyright>
// -----------------------------------------------------------------------------

namespace Algorithms.Sorting
{
	/// <summary>
	/// Implementation of the Selection Sort Algorithm. The array is divided in
	/// two, a sorted sub-list at the left of the array and remaining unsorted
	/// elements to the right. Iterating over the unsorted elements, the lowest
	/// value is found and swapped with the leftmost value (of unsorted
	/// elements) adding it to the end of the sorted sub-list. This repeats
	/// until the list is sorted.
	/// </summary>
	public static class SelectionSorter
	{
		/// <summary>
		/// Public method to be called on an array ordering it from lowest to
		/// highest using the Selection Sort algorithm.
		/// </summary>
		/// <param name="array">An integer array to be sorted.</param>
		public static void SelectionSort(this int[] array)
		{
			if (array == null || array.Length < 2)
			{
				return;
			}

			for (int i = 0; i < array.Length; i++)
			{
				int min = array[i];
				int minIndex = i;
				for (int j = i + 1; j < array.Length; j++)
				{
					if (array[j] < min)
					{
						min = array[j];
						minIndex = j;
					}
				}

				if (minIndex != i)
				{
					array[minIndex] = array[i];
					array[i] = min;
				}
			}
		}
	}
}
