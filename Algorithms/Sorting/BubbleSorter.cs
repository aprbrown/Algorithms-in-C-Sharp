// -----------------------------------------------------------------------------
// <copyright file="BubbleSorter.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full
// license information.
// </copyright>
// -----------------------------------------------------------------------------

namespace Algorithms.Sorting
{
	using Algorithms.Helpers;

	/// <summary>
	/// Implementation of the Bubble Sort Algorithm. Stepping through a list and
	/// comparing two items, swapping them if they are in the wrong order. The
	/// process repeats until no swaps are made for
	/// an entire pass.
	/// </summary>
	public static class BubbleSorter
	{
		/// <summary>
		/// Public method to be called on an array ordering it from lowest to
		/// highest using the Bubble Sort algorithm.
		/// </summary>
		/// <param name="array">An integer array to be sorted.</param>
		public static void BubbleSort(this int[] array)
		{
			if (array == null || array.Length < 2)
			{
				return;
			}

			int iterations = array.Length;
			bool swapped;
			for (int i = 0; i < array.Length; i++)
			{
				swapped = false;
				for (int j = 1; j < iterations; j++)
				{
					if (array[j - 1] > array[j])
					{
						array.Swap(j - 1, j);
						swapped = true;
					}
				}

				iterations--;
				if (!swapped)
				{
					break;
				}
			}
		}
	}
}
