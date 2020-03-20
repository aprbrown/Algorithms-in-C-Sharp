// -----------------------------------------------------------------------------
// <copyright file="HeapSorter.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full
// license information.
// </copyright>
// -----------------------------------------------------------------------------

namespace Algorithms.Sorting
{
	using Algorithms.Helpers;

	/// <summary>
	/// Implementation of the Heap Sort Algorithm, organizing an array into a
	/// heap, then dividing the array into a sorted and unsorted section. After
	/// a new element is added to the sorted section, the unsorted section is
	/// reorganized into a heap and then a new element is added to the sorted
	/// section until the entire array is sorted.
	/// </summary>
	public static class HeapSorter
	{
		/// <summary>
		/// Public method to be called on an array ordering it from lowest to
		/// highest using the HeapSort algorithm.
		/// </summary>
		/// <param name="array">An integer array to be sorted.</param>
		public static void HeapSort(this int[] array)
		{
			if (array == null || array.Length < 2)
			{
				return;
			}

			MaxHeapify(array, array.Length);

			int end = array.Length - 1;
			while (end > 0)
			{
				array.Swap(end, 0);
				end--;
				SiftDown(array, 0, end);
			}
		}

		/// <summary>
		/// Reorders an incoming array in such a way that when visualized as
		/// a binary tree the max value is the top node and no child is larger
		/// than its parent.
		/// </summary>
		/// <param name="array">The integer array to be formed as a
		/// heap.</param>
		/// <param name="length">The max value in the array to be considered for
		/// the heap.</param>
		private static void MaxHeapify(int[] array, int length)
		{
			int start = ParentIndex(length - 1);

			while (start >= 0)
			{
				SiftDown(array, start, length - 1);
				start--;
			}
		}

		/// <summary>
		/// Repairs the incoming heap whose root element is located at the index
		/// 'start' and final child element located at index 'end'.
		/// </summary>
		/// <param name="array">A heap in the form of an integer array.</param>
		/// <param name="start">The index of the root element.</param>
		/// <param name="end">Index of the final element in this branch.</param>
		private static void SiftDown(int[] array, int start, int end)
		{
			int root = start;

			while (LeftChildIndex(root) <= end)
			{
				int child = LeftChildIndex(root);
				int swap = root;

				if (array[swap] < array[child])
				{
					swap = child;
				}

				if (child + 1 <= end && array[swap] < array[child + 1])
				{
					swap = child + 1;
				}

				if (swap == root)
				{
					return;
				}
				else
				{
					array.Swap(root, swap);
					root = swap;
				}
			}
		}

		/// <summary>
		/// Given an index, calculate the index of its parent node.
		/// </summary>
		/// <param name="index">Index from which to determine a parent
		/// node.</param>
		/// <returns>Index of Parent node.</returns>
		private static int ParentIndex(int index)
		{
			return (index - 1) / 2;
		}

		/// <summary>
		/// Given an index, calculate the index of child element on the left
		/// hand side.
		/// </summary>
		/// <param name="index">Index from which to determine left child
		/// node.</param>
		/// <returns>Index of left child node.</returns>
		private static int LeftChildIndex(int index)
		{
			return (2 * index) + 1;
		}

		/// <summary>
		/// Given an index, calculate the index of child element on the right
		/// hand side.
		/// </summary>
		/// <param name="index">Index from which to determine right child
		/// node.</param>
		/// <returns>Index of right child node.</returns>
		private static int RightChildIndex(int index)
		{
			return (2 * index) + 2;
		}
	}
}
