// -----------------------------------------------------------------------------
// <copyright file="BubbleSorter.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full
// license information.
// </copyright>
// -----------------------------------------------------------------------------

namespace Algorithms.Sorting
{
	using System;
	using System.Collections.Generic;
	using Algorithms.Helpers;

	/// <summary>
	/// Implementation of the Bubble Sort algorithm to sort a list of elements.
	/// The algorithm iterates over the list and compares two adjacent elements,
	/// if the elements are in the wrong order they are swapped. At the end of
	/// an iteration the final element will be in order. The process repeats up
	/// until the last element from the previous iteration. If no swaps are made
	/// during an iteration then the list is in order and the process ends.
	/// </summary>
	public static class BubbleSorter
	{
		/// <summary>
		/// Public method to invoke Bubble Sort on a list to order it from
		/// lowest to highest or highest to lowest.
		/// </summary>
		/// <typeparam name="T">Type of element to be sorted.</typeparam>
		/// <param name="list">List to be sorted.</param>
		/// <param name="reversed">Whether list should be sorted low to high
		/// (false) or high to low (true).</param>
		public static void BubbleSort<T>(
			this IList<T> list, bool reversed = false)
			where T : IComparable<T>
		{
			if (list == null || list.Count < 2) return;

			if (reversed) list.Reversed();
			else list.Ordered();
		}

		private static void Ordered<T>(this IList<T> list)
			where T : IComparable<T>
		{
			int iterations = list.Count;
			bool swapped;
			for (int i = 0; i < list.Count; i++)
			{
				swapped = false;
				for (int j = 1; j < iterations; j++)
				{
					if (list[j - 1].CompareTo(list[j]) > 0)
					{
						list.Swap(j - 1, j);
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

		private static void Reversed<T>(this IList<T> list)
			where T : IComparable<T>
		{
			int iterations = list.Count;
			bool swapped;
			for (int i = 0; i < list.Count; i++)
			{
				swapped = false;
				for (int j = 1; j < iterations; j++)
				{
					if (list[j - 1].CompareTo(list[j]) < 0)
					{
						list.Swap(j - 1, j);
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
