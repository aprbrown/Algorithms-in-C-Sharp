// -----------------------------------------------------------------------------
// <copyright file="InsertionSorter.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full
// license information.
// </copyright>
// -----------------------------------------------------------------------------

namespace Algorithms.Sorting
{
	/// <summary>
	/// Implementation of the Insertion Sort Algorithm. Iterating over a list,
	/// an element is compared with elements preceding it, moving elements not
	/// in order up through the array, until inserting the element into its
	/// correct position.
	/// </summary>
	public static class InsertionSorter
	{
		/// <summary>
		/// Public method to be called on an array ordering it from lowest to
		/// highest using the Insertion Sort algorithm.
		/// </summary>
		/// <param name="array">An integer array to be sorted.</param>
		public static void InsertionSort(this int[] array)
		{
			if (array == null || array.Length < 2)
			{
				return;
			}

			int i = 1;
			while (i < array.Length)
			{
				int x = array[i];
				int j = i - 1;
				while (j >= 0 && array[j] > x)
				{
					array[j + 1] = array[j];
					j--;
				}

				array[j + 1] = x;
				i++;
			}
		}
	}
}
