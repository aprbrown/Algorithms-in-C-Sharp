// -----------------------------------------------------------------------------
// <copyright file="HeapSorter.cs" company="Andrew P R Brown">
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
	/// Implementation of the Heap Sort algorithm. Depending on whether the user
	/// requires the List to be sorted from low to high or high to low, two
	/// different strategies are implemented both creating heaps. Low to High
	/// creates max heaps where parents are larger than their children, while
	/// High to Low created min heaps where parents are lower than their
	/// children. The first and last elements are then swapped resulting in the
	/// final item being sorted. The next element to be swapped is then sifted
	/// up or down (depending on the order of final sort) and the process
	/// repeats until complete.
	/// </summary>
	public static class HeapSorter
	{
		/// <summary>
		/// Public method to invoke Heap Sort on a list to order it from
		/// lowest to highest or highest to lowest.
		/// </summary>
		/// <typeparam name="T">Type of element to be sorted.</typeparam>
		/// <param name="list">List to be sorted.</param>
		/// <param name="reversed">Whether list should be sorted low to high
		/// (false) or high to low (true).</param>
		public static void HeapSort<T>(
			this IList<T> list, bool reversed = false)
			where T : IComparable<T>
		{
			if (list == null || list.Count < 2) return;

			if (reversed)
			{
				MinHeapify(list, list.Count - 1);

				int end = list.Count - 1;
				while (end > 0)
				{
					list.Swap(end, 0);
					end--;
					SiftUp(list, 0, end);
				}
			}
			else
			{
				MaxHeapify(list, list.Count - 1);

				int end = list.Count - 1;
				while (end > 0)
				{
					list.Swap(end, 0);
					end--;
					SiftDown(list, 0, end);
				}
			}
		}

		private static void MaxHeapify<T>(IList<T> list, int lastIndex)
			where T : IComparable<T>
		{
			int start = ParentIndex(lastIndex);

			while (start >= 0)
			{
				SiftDown(list, start, lastIndex);
				start--;
			}
		}

		private static void MinHeapify<T>(IList<T> list, int lastIndex)
			where T : IComparable<T>
		{
			int start = ParentIndex(lastIndex);

			while (start >= 0)
			{
				SiftUp(list, start, lastIndex);
				start--;
			}
		}

		private static void SiftDown<T>(IList<T> list, int start, int end)
			where T : IComparable<T>
		{
			int root = start;

			while (LeftChildIndex(root) <= end)
			{
				int child = LeftChildIndex(root);
				int swap = root;

				if (list[swap].CompareTo(list[child]) < 0)
					swap = child;

				if (child + 1 <= end &&
					list[swap].CompareTo(list[child + 1]) < 0)
					swap = child + 1;

				if (swap == root)
				{
					return;
				}
				else
				{
					list.Swap(root, swap);
					root = swap;
				}
			}
		}

		private static void SiftUp<T>(IList<T> list, int start, int end)
			where T : IComparable<T>
		{
			int root = start;

			while (LeftChildIndex(root) <= end)
			{
				int child = LeftChildIndex(root);
				int swap = root;

				if (list[swap].CompareTo(list[child]) > 0)
					swap = child;

				if (child + 1 <= end &&
					list[swap].CompareTo(list[child + 1]) > 0)
					swap = child + 1;

				if (swap == root)
				{
					return;
				}
				else
				{
					list.Swap(root, swap);
					root = swap;
				}
			}
		}

		private static int ParentIndex(int index)
		{
			return (index - 1) / 2;
		}

		private static int LeftChildIndex(int index)
		{
			return (2 * index) + 1;
		}
	}
}
