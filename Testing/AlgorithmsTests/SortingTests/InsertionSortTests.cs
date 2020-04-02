// -----------------------------------------------------------------------------
// <copyright file="InsertionSortTests.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full
// license information.
// </copyright>
// -----------------------------------------------------------------------------

namespace Testing.AlgorithmsTests.SortingTests
{
	using System.Collections.Generic;
	using Algorithms.Sorting;
	using Testing.AlgorithmsTests.Helpers;
	using Xunit;
	using Xunit.Abstractions;

	public class InsertionSortTests
	{
		private static SortingTests Lists = new SortingTests();
		private readonly ITestOutputHelper output;

		public InsertionSortTests(ITestOutputHelper output)
		{
			this.output = output;
		}

		public static IEnumerable<object[]> InsertionSortDataAscending =>
			new List<object[]>
		{
			new object[] { Lists.GetRandomList25(), Lists.GetOrderedList25() },
			new object[] { Lists.GetRandomList50(), Lists.GetOrderedList50() },
			new object[] { Lists.GetRandomList100(), Lists.GetOrderedList100() },
		};

		public static IEnumerable<object[]> InsertionSortDataDescending =>
			new List<object[]>
		{
			new object[] { Lists.GetRandomList25(), Lists.GetReversedList25() },
			new object[] { Lists.GetRandomList50(), Lists.GetReversedList50() },
			new object[] { Lists.GetRandomList100(), Lists.GetReversedList100() },
		};

		[Theory]
		[MemberData(nameof(InsertionSortDataAscending))]
		public void InsertionSortWillSortAListInAscendingOrder(
			List<int> random, List<int> ordered)
		{
			this.output.WriteLine("Random Before Sort:\n{0}", random.PrintList());

			this.output.WriteLine("Ordered Array:\n{0}", ordered.PrintList());

			random.InsertionSort();

			this.output.WriteLine("Random After Sort:\n{0}", random.PrintList());

			Assert.Equal(random, ordered);
		}

		[Theory]
		[MemberData(nameof(InsertionSortDataDescending))]
		public void InsertionSortWillSortAListInDescendingOrderWhenDescendingIsTrue(
			List<int> random, List<int> reversed)
		{
			this.output.WriteLine("Random Before Sort:\n{0}", random.PrintList());

			this.output.WriteLine("Reversed Array:\n{0}", reversed.PrintList());

			random.InsertionSort();

			this.output.WriteLine("Random After Sort:\n{0}", random.PrintList());

			Assert.Equal(random, reversed);
		}

		[Fact]
		public void CallingInsertionSortOnANullReturnsNull()
		{
			IList<int> nullList = null;
			nullList.InsertionSort();
			Assert.Null(nullList);
		}

		[Fact]
		public void CallingInsertionSortOnAnEmptyArrayReturnsEmptyArray()
		{
			IList<int> empty = new List<int>();
			empty.InsertionSort();
			Assert.Empty(empty);
		}
	}
}
