namespace Algorithms.Sorting
{
	using System;
	using System.Collections.Generic;

	public static class MergeSorter
	{
		public static IList<T> MergeSort<T>(this IList<T> list)
			where T : IComparable<T>
		{
			if (list == null || list.Count < 2) return list;

			IList<T> left, right, sortedArray = new List<T>();
			List<T> unsortedList = new List<T>(list);

			int midpoint = list.Count / 2;

			left = unsortedList.GetRange(0, midpoint);
			right = unsortedList.GetRange(
				midpoint, unsortedList.Count - midpoint);

			left = MergeSort(left);
			right = MergeSort(right);
			sortedArray = Merge(left, right);
			return sortedArray;
		}

		private static IList<T> Merge<T>(IList<T> left, IList<T> right)
			where T : IComparable<T>
		{
			IList<T> result = new List<T>();
			Queue<T> leftQueue = new Queue<T>(left);
			Queue<T> rightQueue = new Queue<T>(right);

			while (leftQueue.Count > 0 && rightQueue.Count > 0)
			{
				if (leftQueue.Peek().CompareTo(rightQueue.Peek()) <= 0)
				{
					result.Add(leftQueue.Dequeue());
				}
				else
				{
					result.Add(rightQueue.Dequeue());
				}
			}

			while (leftQueue.Count > 0) result.Add(leftQueue.Dequeue());

			while (rightQueue.Count > 0) result.Add(rightQueue.Dequeue());

			return result;
		}
	}
}
