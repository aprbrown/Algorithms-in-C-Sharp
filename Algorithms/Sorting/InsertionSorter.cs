// -----------------------------------------------------------------------------
// <copyright file="InsertionSorter.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full
// license information.
// </copyright>
// -----------------------------------------------------------------------------

namespace Algorithms.Sorting
{
	using System;
	using System.Collections.Generic;

	public static class InsertionSorter
	{
		public static void InsertionSort<T>(this IList<T> list)
			where T : IComparable<T>
		{
			if (list == null || list.Count < 2) return;

			int i = 1;
			int j;

			while (i < list.Count)
			{
				T x = list[i];
				j = i - 1;
				while (j >= 0 && list[j].CompareTo(x) > 0)
				{
					list[j + 1] = list[j];
					j--;
				}

				list[j + 1] = x;
				i++;
			}
		}
	}
}
