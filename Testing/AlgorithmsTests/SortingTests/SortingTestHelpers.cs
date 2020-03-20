// -----------------------------------------------------------------------------
// <copyright file="SortingTestHelpers.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full
// license information.
// </copyright>
// -----------------------------------------------------------------------------

namespace Testing.AlgorithmsTests
{
	using Algorithms.Helpers;

	/// <summary>
	/// Helper for different sorting test classes. To create and maintain arrays
	/// to be tested against.
	/// </summary>
	internal static class SortingTestHelpers
	{
		private static readonly int[] RandTwentyFiveReference =
		{
			3, 31, 34, 18, 27, 46, 16, 17, 30, 4, 14, 50, 32, 33, 36, 6, 15, 1,
			23, 25, 42, 10, 9, 21, 11,
		};

		private static readonly int[] SortedTwentyFiveReference =
		{
			1, 3, 4, 6, 9, 10, 11, 14, 15, 16, 17, 18, 21, 23, 25, 27, 30, 31,
			32, 33, 34, 36, 42, 46, 50,
		};

		private static readonly int[] RandFiftyReference =
		{
			73, 93, 43, 50, 12, 44, 85, 94, 16, 46, 54, 63, 3, 80, 30, 86, 7, 2,
			76, 27, 33, 31, 36, 47, 66, 99, 41, 11, 4, 68, 78, 17, 24, 88, 91,
			22, 81, 65, 57, 87, 92, 1, 42, 23, 71, 20, 79, 70, 40, 61,
		};

		private static readonly int[] SortedFiftyReference =
		{
			1, 2, 3, 4, 7, 11, 12, 16, 17, 20, 22, 23, 24, 27, 30, 31, 33, 36,
			40, 41, 42, 43, 44, 46, 47, 50, 54, 57, 61, 63, 65, 66, 68, 70, 71,
			73, 76, 78, 79, 80, 81, 85, 86, 87, 88, 91, 92, 93, 94, 99,
		};

		private static readonly int[] RandHundredReference =
		{
			80, -98, 182, 7, -84, 172, -2, -110, 74, 170, 50, -35, -62, -133,
			84, -192, 119, 183, 192, 3, -146, -26, 82, 83, 117, -30, 156, -137,
			-71, 18, -135, -23, -52, 69, 191, -49, 185, -127, 94, 26, -104,
			-128, 107, -44, 62, -176, 36, 118, 72, -191, -196, -4, 135, -88,
			114, 14, 125, 136, -113, -46, -173, -188, 162, -139, 54, 30, 120,
			-91, -108, -198, 75, -168, -194, -130, 24, -89, -103, -147, -193,
			53, 99, -115, 165, 131, -59, 104, -170, -3, 197, -172, 141, -177,
			-29, -199, -31, -90, 21, -184, -190, 35,
		};

		private static readonly int[] SortedHundredReference =
		{
			-199, -198, -196, -194, -193, -192, -191, -190, -188, -184, -177,
			-176, -173, -172, -170, -168, -147, -146, -139, -137, -135, -133,
			-130, -128, -127, -115, -113, -110, -108, -104, -103, -98, -91, -90,
			-89, -88, -84, -71, -62, -59, -52, -49, -46, -44, -35, -31, -30,
			-29, -26, -23, -4, -3, -2, 3, 7, 14, 18, 21, 24, 26, 30, 35, 36, 50,
			53, 54, 62, 69, 72, 74, 75, 80, 82, 83, 84, 94, 99, 104, 107, 114,
			117, 118, 119, 120, 125, 131, 135, 136, 141, 156, 162, 165, 170,
			172, 182, 183, 185, 191, 192, 197,
		};

		/// <summary>
		/// Provide a copy of the random array of 25 digits.
		/// </summary>
		/// <returns>int[] of 25 random values.</returns>
		internal static int[] GetRandomTwentyFiveArray()
		{
			int[] randTwentyFive =
				ArrayUtils.CopyFullArray(RandTwentyFiveReference);

			return randTwentyFive;
		}

		/// <summary>
		/// To provide a sorted array of the 25 digits in the random array.
		/// </summary>
		/// <returns>int[] of 25 sorted values.</returns>
		internal static int[] GetSortedTwentyFiveArray()
		{
			return SortedTwentyFiveReference;
		}

		/// <summary>
		/// Provide a copy of the random array of 50 digits.
		/// </summary>
		/// <returns>int[] of 50 random values.</returns>
		internal static int[] GetRandomFiftyArray()
		{
			int[] randFifty =
				ArrayUtils.CopyFullArray(RandFiftyReference);

			return randFifty;
		}

		/// <summary>
		/// To provide a sorted array of the 50 digits in the random array.
		/// </summary>
		/// <returns>int[] of 50 sorted values.</returns>
		internal static int[] GetSortedFiftyArray()
		{
			return SortedFiftyReference;
		}

		/// <summary>
		/// Provide a copy of the random array of 100 digits.
		/// </summary>
		/// <returns>int[] of 100 random values.</returns>
		internal static int[] GetRandomHundredArray()
		{
			int[] randHundred =
				ArrayUtils.CopyFullArray(RandHundredReference);

			return randHundred;
		}

		/// <summary>
		/// To provide a sorted array of the 100 digits in the random array.
		/// </summary>
		/// <returns>int[] of 100 sorted values.</returns>
		internal static int[] GetSortedHundredArray()
		{
			return SortedHundredReference;
		}
	}
}
