// -----------------------------------------------------------------------------
// <copyright file="SortingUtils.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full
// license information.
// </copyright>
// -----------------------------------------------------------------------------

namespace Algorithms.Helpers
{
	using System.Collections.Generic;

	/// <summary>
	/// Utility class for methods associated with Sorting Algorithms.
	/// </summary>
	public static class SortingUtils
	{
		/// <summary>
		/// Given the index of two elements in an IList, swap both
		/// elements.
		/// </summary>
		/// <typeparam name="T">The type of elements in the list.</typeparam>
		/// <param name="list">The list in which the swap is to be made.</param>
		/// <param name="firstIndex">Index of the first item to swap.</param>
		/// <param name="secondIndex">Index of the second item to swap.</param>
		public static void Swap<T>(
			this IList<T> list, int firstIndex, int secondIndex)
		{
			if (list == null || list.Count < 2) return;

			T temp = list[firstIndex];
			list[firstIndex] = list[secondIndex];
			list[secondIndex] = temp;
		}
	}
}
