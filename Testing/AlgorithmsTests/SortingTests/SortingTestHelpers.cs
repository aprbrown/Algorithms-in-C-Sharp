// -----------------------------------------------------------------------------
// <copyright file="SortingTestHelpers.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full
// license information.
// </copyright>
// -----------------------------------------------------------------------------

namespace Testing.AlgorithmsTests
{
	using System.Collections.Generic;

	internal static class SortingTestHelpers
	{
		public static string PrintList<T>(this IList<T> listToPrint)
		{
			if (listToPrint == null || listToPrint.Count == 0)
				return string.Empty;

			string list = string.Empty;
			foreach (T item in listToPrint)
				list += item.ToString() + ", ";

			return list;
		}
	}
}
