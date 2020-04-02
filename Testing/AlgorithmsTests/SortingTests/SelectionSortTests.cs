// -----------------------------------------------------------------------------
// <copyright file="SelectionSortTests.cs" company="Andrew P R Brown">
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

	public class SelectionSortTests
	{
		private static SortingTests Lists = new SortingTests();
		private readonly ITestOutputHelper output;

		public SelectionSortTests(ITestOutputHelper output)
		{
			this.output = output;
		}

		public static IEnumerable<object[]> SelectionSortDataAscending =>
			new List<object[]>
		{
			new object[] { Lists.GetRandomList25(), Lists.GetOrderedList25() },
			new object[] { Lists.GetRandomList50(), Lists.GetOrderedList50() },
			new object[] { Lists.GetRandomList100(), Lists.GetOrderedList100() },
		};

		public static IEnumerable<object[]> SelectionSortDataDescending =>
			new List<object[]>
		{
			new object[] { Lists.GetRandomList25(), Lists.GetReversedList25() },
			new object[] { Lists.GetRandomList50(), Lists.GetReversedList50() },
			new object[] { Lists.GetRandomList100(), Lists.GetReversedList100() },
		};

		[Theory]
		[MemberData(nameof(SelectionSortDataAscending))]
		public void SelectionSortWillSortAListInAscendingOrder(
			IList<int> random, IList<int> ordered)
		{
			this.output.WriteLine("Random Before Sort:\n{0}", random.PrintList());

			this.output.WriteLine("Ordered Array:\n{0}", ordered.PrintList());

			random.SelectionSort();

			this.output.WriteLine("Random After Sort:\n{0}", random.PrintList());

			Assert.Equal(random, ordered);
		}

		[Theory]
		[MemberData(nameof(SelectionSortDataDescending))]
		public void SelectionSortWillSortAListInDescendingOrderWhenDescendingIsTrue(
			IList<int> random, IList<int> reversed)
		{
			this.output.WriteLine("Random Before Sort:\n{0}", random.PrintList());

			this.output.WriteLine("Reversed Array:\n{0}", reversed.PrintList());

			random.SelectionSort();

			this.output.WriteLine("Random After Sort:\n{0}", random.PrintList());

			Assert.Equal(random, reversed);
		}

		[Fact]
		public void CallingSelectionSortOnANullReturnsNull()
		{
			IList<int> nullList = null;
			nullList.SelectionSort();
			Assert.Null(nullList);
		}

		[Fact]
		public void CallingSelectionSortOnAnEmptyArrayReturnsEmptyArray()
		{
			IList<int> empty = new List<int>();
			empty.SelectionSort();
			Assert.Empty(empty);
		}
	}
}
