namespace Algorithms.Sorting
{
	using System;
	using System.Collections.Generic;
	using Algorithms.Helpers;

	public static class QuickSorter
	{
		public static void QuickSort<T>(
			this IList<T> list, int left = 0, int right = -1)
			where T : IComparable<T>
		{
			if (list == null || list.Count < 2) return;

			if (right == -1) right = list.Count - 1;

			if (left < right)
			{
				int pivot = Partition(list, left, right);
				QuickSort(list, left, pivot);
				QuickSort(list, pivot + 1, right);
			}
		}

		private static int Partition<T>(IList<T> list, int left, int right)
			where T : IComparable<T>
		{
			int mid = (left + right) / 2;
			if (list[mid].CompareTo(list[left]) < 0)
			{
				list.Swap(left, mid);
			}

			if (list[right].CompareTo(list[left]) < 0)
			{
				list.Swap(left, right);
			}

			if (list[mid].CompareTo(list[right]) < 0)
			{
				list.Swap(mid, right);
			}

			T pivot = list[right];
			while (true)
			{
				while (list[left].CompareTo(pivot) < 0)
				{
					left++;
				}

				while (list[right].CompareTo(pivot) > 0)
				{
					right--;
				}

				if (left >= right)
				{
					return right;
				}

				list.Swap(left, right);
				if (list[left].CompareTo(list[right]) == 0)
				{
					left++;
					right--;
				}
			}
		}
	}
}
