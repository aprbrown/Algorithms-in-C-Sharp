namespace Algorithms.Sorting
{
	using System;
	using System.Collections.Generic;

	public static class SelectionSorter
	{
		public static void SelectionSort<T>(this IList<T> list)
			where T : IComparable<T>
		{
			if (list == null || list.Count < 2) return;

			for (int i = 0; i < list.Count; i++)
			{
				T min = list[i];
				int minIndex = i;
				for (int j = i + 1; j < list.Count; j++)
				{
					if (list[j].CompareTo(min) < 0)
					{
						min = list[j];
						minIndex = j;
					}
				}

				if (minIndex != i)
				{
					list[minIndex] = list[i];
					list[i] = min;
				}
			}
		}
	}
}
