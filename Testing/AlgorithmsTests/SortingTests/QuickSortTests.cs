// -----------------------------------------------------------------------------
// <copyright file="QuickSortTests.cs" company="Andrew P R Brown">
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

	public class QuickSortTests
	{
		private static readonly SortingTests Lists = SortingTests.Instance;
		private readonly ITestOutputHelper output;

		public QuickSortTests(ITestOutputHelper output)
		{
			this.output = output;
		}

		public static IEnumerable<object[]> QuickSortDataAscending =>
			new List<object[]>
		{
			new object[] { Lists.GetRandomList1(), Lists.GetOrderedList1() },
			new object[] { Lists.GetRandomList2(), Lists.GetOrderedList2() },
			new object[] { Lists.GetRandomList3(), Lists.GetOrderedList3() },
		};

		public static IEnumerable<object[]> QuickSortDataDescending =>
			new List<object[]>
		{
			new object[] { Lists.GetRandomList1(), Lists.GetReversedList1() },
			new object[] { Lists.GetRandomList2(), Lists.GetReversedList2() },
			new object[] { Lists.GetRandomList3(), Lists.GetReversedList3() },
		};

		[Theory]
		[MemberData(nameof(QuickSortDataAscending))]
		public void QuickSortWillSortAListInAscendingOrder(
			IList<int> random, IList<int> ordered)
		{
			this.output.WriteLine("Random Before Sort:\n{0}", random.PrintList());

			this.output.WriteLine("Ordered Array:\n{0}", ordered.PrintList());

			random.QuickSort();

			this.output.WriteLine("Random After Sort:\n{0}", random.PrintList());

			Assert.Equal(random, ordered);
		}

		[Theory]
		[MemberData(nameof(QuickSortDataDescending))]
		public void QuickSortWillSortAListInDescendingOrderWhenDescendingIsTrue(
			IList<int> random, IList<int> reversed)
		{
			this.output.WriteLine("Random Before Sort:\n{0}", random.PrintList());

			this.output.WriteLine("Reversed Array:\n{0}", reversed.PrintList());

			random.QuickSort();

			this.output.WriteLine("Random After Sort:\n{0}", random.PrintList());

			Assert.Equal(random, reversed);
		}

		[Fact]
		public void CallingQuickSortOnANullReturnsNull()
		{
			IList<int> nullList = null;
			nullList.QuickSort();
			Assert.Null(nullList);
		}

		[Fact]
		public void CallingQuickSortOnAnEmptyArrayReturnsEmptyArray()
		{
			IList<int> empty = new List<int>();
			empty.QuickSort();
			Assert.Empty(empty);
		}
	}
}
