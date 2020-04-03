// -----------------------------------------------------------------------------
// <copyright file="SortingTestHelpers.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full
// license information.
// </copyright>
// -----------------------------------------------------------------------------

namespace Testing.AlgorithmsTests.Helpers
{
	using System.Collections.Generic;

	/// <summary>
	/// Class for utility methods for use during testing.
	/// </summary>
	public static class SortingTestHelpers
	{
		/// <summary>
		/// Generates a string of values in an IList compatible List. Utilises
		/// the ToString method of the incoming data type to do so. This is to
		/// allow tests to display before and after views of lists so the user
		/// can verify testing is being conducted on the correct informations.
		/// </summary>
		/// <typeparam name="T">The type of element stored in the list.</typeparam>
		/// <param name="listToPrint">The list to be represented as a string.</param>
		/// <returns>A string representation of the list.</returns>
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
