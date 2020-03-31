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
		private static readonly SortingTests Lists = SortingTests.Instance;
		private readonly ITestOutputHelper output;

		public InsertionSortTests(ITestOutputHelper output)
		{
			this.output = output;
		}

		public static IEnumerable<object[]> InsertionSortDataAscending =>
			new List<object[]>
		{
			new object[] { Lists.GetRandomList1(), Lists.GetOrderedList1() },
			new object[] { Lists.GetRandomList2(), Lists.GetOrderedList2() },
			new object[] { Lists.GetRandomList3(), Lists.GetOrderedList3() },
		};

		public static IEnumerable<object[]> InsertionSortDataDescending =>
			new List<object[]>
		{
			new object[] { Lists.GetRandomList1(), Lists.GetReversedList1() },
			new object[] { Lists.GetRandomList2(), Lists.GetReversedList2() },
			new object[] { Lists.GetRandomList3(), Lists.GetReversedList3() },
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
