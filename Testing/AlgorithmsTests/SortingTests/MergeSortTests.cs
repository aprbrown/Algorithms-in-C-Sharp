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
		private static SortingTests Lists = new SortingTests();
		private readonly ITestOutputHelper output;

		public MergeSortTests(ITestOutputHelper output)
		{
			this.output = output;
		}

		public static IEnumerable<object[]> MergeSortDataAscending =>
			new List<object[]>
		{
			new object[] { Lists.GetRandomList25(), Lists.GetOrderedList25()},
			new object[] { Lists.GetRandomList50(), Lists.GetOrderedList50()},
			new object[] { Lists.GetRandomList100(), Lists.GetOrderedList100()},
		};

		public static IEnumerable<object[]> MergeSortDataDescending =>
			new List<object[]>
		{
			new object[] { Lists.GetRandomList25(), Lists.GetReversedList25()},
			new object[] { Lists.GetRandomList50(), Lists.GetReversedList50()},
			new object[] { Lists.GetRandomList100(), Lists.GetReversedList100()},
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
