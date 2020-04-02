// -----------------------------------------------------------------------------
// <copyright file="SortingTests.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full
// license information.
// </copyright>
// -----------------------------------------------------------------------------

namespace Testing.AlgorithmsTests.SortingTests
{
	using System.Collections.Generic;

	/// <summary>
	/// To facilitate testing of sorting on lists of integers, this class will
	/// return copies of the lists to ensure each test gets the same list to
	/// test on.
	/// </summary>
	internal sealed class SortingTests
	{
		private List<int> randomList25 = new List<int>
		{
			44, -41, -30, -19, 0, 32, 0, -47, 20, 48, -21, 39, -14, 20, 35, 24,
			-17, 36, -15, 24, 44, 8, 48, -50, 14,
		};

		private List<int> orderedList25 = new List<int>
		{
			-50, -47, -41, -30, -21, -19, -17, -15, -14, 0, 0, 8, 14, 20, 20,
			24, 24, 32, 35, 36, 39, 44, 44, 48, 48,
		};

		private List<int> reversedList25 = new List<int>
		{
			48, 48, 44, 44, 39, 36, 35, 32, 24, 24, 20, 20, 14, 8, 0, 0, -14,
			-15, -17, -19, -21, -30, -41, -47, -50,
		};

		private List<int> randomList50 = new List<int>
		{
			86, 52, -14, -47, 65, 9, 79, -52, -66, 56, 10, -38, -79, 75, 72, 3,
			85, 48, 62, 66, 76, -12, -21, 58, -96, 64, -95, -3, -17, 64, -83,
			68, 85, -20, -40, 58, 58, -2, 21, -68, -76, -26, 83, 30, -95, -69,
			90, 42, -56, 91,
		};

		private List<int> orderedList50 = new List<int>
		{
			-96, -95, -95, -83, -79, -76, -69, -68, -66, -56, -52, -47, -40,
			-38, -26, -21, -20, -17, -14, -12, -3, -2, 3, 9, 10, 21, 30, 42, 48,
			52, 56, 58, 58, 58, 62, 64, 64, 65, 66, 68, 72, 75, 76, 79, 83, 85,
			85, 86, 90, 91,
		};

		private List<int> reversedList50 = new List<int>
		{
			91, 90, 86, 85, 85, 83, 79, 76, 75, 72, 68, 66, 65, 64, 64, 62, 58,
			58, 58, 56, 52, 48, 42, 30, 21, 10, 9, 3, -2, -3, -12, -14, -17,
			-20, -21, -26, -38, -40, -47, -52, -56, -66, -68, -69, -76, -79,
			-83, -95, -95, -96,
		};

		private List<int> randomList100 = new List<int>
		{
			96, 28, 159, 161, -7, -115, -164, -54, 189, 92, -103, -147, 20,
			-170, -31, -25, -156, -27, -79, 118, -21, -134, 144, -51, -27, -106,
			-98, -11, -3, 35, 37, -184, 196, -126, 123, -104, 68, 101, 56, 125,
			-30, -139, -103, 41, 57, 85, 19, 26, 181, -75, 109, -102, -146,
			-139, -106, -80, -26, -100, -122, 189, 73, -63, 39, -156, 145, 171,
			147, -164,197, 163, -3, -167, 7, -114, -163, -192, 59, 192, -18,
			-22, -35, -34, -102, 162, 15, -171, 52, 25, 70, -107, 11, -142, -87,
			-43, 142, 123, -88, 143, -13, -24,
		};

		private List<int> orderedList100 = new List<int>
		{
			-192, -184, -171, -170, -167, -164, -164, -163, -156, -156, -147,
			-146, -142, -139, -139, -134, -126, -122, -115, -114, -107, -106,
			-106, -104, -103, -103, -102, -102, -100, -98, -88, -87, -80, -79,
			-75, -63, -54, -51, -43, -35, -34, -31, -30, -27, -27, -26, -25,
			-24, -22, -21, -18, -13, -11, -7, -3, -3, 7, 11, 15, 19, 20, 25, 26,
			28, 35, 37, 39, 41, 52, 56, 57, 59, 68, 70, 73, 85, 92, 96, 101,
			109, 118, 123, 123, 125, 142, 143, 144, 145, 147, 159, 161, 162,
			163, 171, 181, 189, 189, 192, 196, 197,
		};

		private List<int> reversedList100 = new List<int>
		{
			197, 196, 192, 189, 189, 181, 171, 163, 162, 161, 159, 147, 145,
			144, 143, 142, 125, 123, 123, 118, 109, 101, 96, 92, 85, 73, 70, 68,
			59, 57, 56, 52, 41, 39, 37, 35, 28, 26, 25, 20, 19, 15, 11, 7, -3,
			-3, -7, -11, -13, -18, -21, -22, -24, -25, -26, -27, -27, -30, -31,
			-34, -35, -43, -51, -54, -63, -75, -79, -80, -87, -88, -98, -100,
			-102, -102, -103, -103, -104, -106, -106, -107, -114, -115, -122,
			-126, -134, -139, -139, -142, -146, -147, -156, -156, -163, -164,
			-164, -167, -170, -171, -184, -192,
		};

		/// <summary>
		/// Initializes a new instance of the <see cref="SortingTests"/> class.
		/// </summary>
		public SortingTests() { }

		/// <summary>
		/// Gets a copy of randomList25.
		/// </summary>
		/// <returns>A List of 25 randomly ordered integers.</returns>
		public List<int> GetRandomList25() => new List<int>(this.randomList25);

		/// <summary>
		/// Gets a copy of orderedList25.
		/// </summary>
		/// <returns>A List of 25 ordered integers.</returns>
		public List<int> GetOrderedList25() => new List<int>(this.orderedList25);

		/// <summary>
		/// Gets a copy of reversedList25.
		/// </summary>
		/// <returns>A List of 25 reverse ordered integers.</returns>
		public List<int> GetReversedList25() => new List<int>(this.reversedList25);

		/// <summary>
		/// Gets a copy of randomList50.
		/// </summary>
		/// <returns>A List of 50 randomly ordered integers.</returns>
		public List<int> GetRandomList50() => new List<int>(this.randomList50);

		/// <summary>
		/// Gets a copy of orderedList50.
		/// </summary>
		/// <returns>A List of 50 ordered integers.</returns>
		public List<int> GetOrderedList50() => new List<int>(this.orderedList50);

		/// <summary>
		/// Gets a copy of reversedList50.
		/// </summary>
		/// <returns>A List of 50 reverse ordered integers.</returns>
		public List<int> GetReversedList50() => new List<int>(this.reversedList50);

		/// <summary>
		/// Gets a copy of randomList100.
		/// </summary>
		/// <returns>A List of 100 randomly ordered integers.</returns>
		public List<int> GetRandomList100() => new List<int>(this.randomList100);

		/// <summary>
		/// Gets a copy of orderedList100.
		/// </summary>
		/// <returns>A List of 100 ordered integers.</returns>
		public List<int> GetOrderedList100() => new List<int>(this.orderedList100);

		/// <summary>
		/// Gets a copy of reversedList100.
		/// </summary>
		/// <returns>A List of 100 reverse ordered integers.</returns>
		public List<int> GetReversedList100() => new List<int>(this.reversedList100);
	}
}
