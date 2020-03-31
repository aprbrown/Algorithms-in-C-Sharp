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
		private static readonly SortingTests Lists = SortingTests.Instance;
		private readonly ITestOutputHelper output;

		public SelectionSortTests(ITestOutputHelper output)
		{
			this.output = output;
		}

		public static IEnumerable<object[]> SelectionSortDataAscending =>
			new List<object[]>
		{
			new object[] { Lists.GetRandomList1(), Lists.GetOrderedList1() },
			new object[] { Lists.GetRandomList2(), Lists.GetOrderedList2() },
			new object[] { Lists.GetRandomList3(), Lists.GetOrderedList3() },
		};

		public static IEnumerable<object[]> SelectionSortDataDescending =>
			new List<object[]>
		{
			new object[] { Lists.GetRandomList1(), Lists.GetReversedList1() },
			new object[] { Lists.GetRandomList2(), Lists.GetReversedList2() },
			new object[] { Lists.GetRandomList3(), Lists.GetReversedList3() },
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
