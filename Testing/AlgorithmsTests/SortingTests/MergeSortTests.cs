// -----------------------------------------------------------------------------
// <copyright file="MergeSortTests.cs" company="Andrew P R Brown">
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

	public class MergeSortTests
	{
		private static readonly SortingTests Lists = SortingTests.Instance;
		private readonly ITestOutputHelper output;

		public MergeSortTests(ITestOutputHelper output)
		{
			this.output = output;
		}

		public static IEnumerable<object[]> MergeSortDataAscending =>
			new List<object[]>
		{
			new object[] { Lists.GetRandomList1(), Lists.GetOrderedList1()},
			new object[] { Lists.GetRandomList2(), Lists.GetOrderedList2()},
			new object[] { Lists.GetRandomList3(), Lists.GetOrderedList3()},
		};

		public static IEnumerable<object[]> MergeSortDataDescending =>
			new List<object[]>
		{
			new object[] { Lists.GetRandomList1(), Lists.GetReversedList1()},
			new object[] { Lists.GetRandomList2(), Lists.GetReversedList2()},
			new object[] { Lists.GetRandomList3(), Lists.GetReversedList3()},
		};

		[Theory]
		[MemberData(nameof(MergeSortDataAscending))]
		public void MergeSortWillSortAListInAscendingOrder(
			IList<int> random, IList<int> ordered)
		{
			this.output.WriteLine("Random Before Sort:\n{0}", random.PrintList());

			this.output.WriteLine("Ordered Array:\n{0}", ordered.PrintList());

			random = random.MergeSort();

			this.output.WriteLine("Random After Sort:\n{0}", random.PrintList());

			Assert.Equal(random, ordered);
		}

		[Theory]
		[MemberData(nameof(MergeSortDataDescending))]
		public void MergeSortWillSortAListInDescendingOrderWhenDescendingIsTrue(
			IList<int> random, IList<int> reversed)
		{
			this.output.WriteLine("Random Before Sort:\n{0}", random.PrintList());

			this.output.WriteLine("Reversed Array:\n{0}", reversed.PrintList());

			random = random.MergeSort();

			this.output.WriteLine("Random After Sort:\n{0}", random.PrintList());

			Assert.Equal(random, reversed);
		}

		[Fact]
		public void CallingMergeSortOnANullReturnsNull()
		{
			IList<int> nullList = null;
			nullList = nullList.MergeSort();
			Assert.Null(nullList);
		}

		[Fact]
		public void CallingMergeSortOnAnEmptyArrayReturnsEmptyArray()
		{
			IList<int> empty = new List<int>();
			empty = empty.MergeSort();
			Assert.Empty(empty);
		}
	}
}
