// -----------------------------------------------------------------------------
// <copyright file="HeapSortTests.cs" company="Andrew P R Brown">
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

	public class HeapSortTests
	{
		private static SortingTests Lists = new SortingTests();
		private readonly ITestOutputHelper output;

		public HeapSortTests(ITestOutputHelper output)
		{
			this.output = output;
		}

		public static IEnumerable<object[]> HeapSortDataAscending =>
			new List<object[]>
		{
			new object[] { Lists.GetRandomList25(), Lists.GetOrderedList25() },
			new object[] { Lists.GetRandomList50(), Lists.GetOrderedList50() },
			new object[] { Lists.GetRandomList100(), Lists.GetOrderedList100() },
		};

		public static IEnumerable<object[]> HeapSortDataDescending =>
			new List<object[]>
		{
			new object[] { Lists.GetRandomList25(), Lists.GetReversedList25() },
			new object[] { Lists.GetRandomList50(), Lists.GetReversedList50() },
			new object[] { Lists.GetRandomList100(), Lists.GetReversedList100() },
		};

		[Theory]
		[MemberData(nameof(HeapSortDataAscending))]
		public void HeapSortWillSortAListInAscendingOrder(
			List<int> random, List<int> ordered)
		{
			this.output.WriteLine("Random Before Sort:\n{0}", random.PrintList());

			this.output.WriteLine("Ordered Array:\n{0}", ordered.PrintList());

			random.HeapSort();

			this.output.WriteLine("Random After Sort:\n{0}", random.PrintList());

			Assert.Equal(random, ordered);
		}

		[Theory]
		[MemberData(nameof(HeapSortDataDescending))]
		public void HeapSortWillSortAListInDescendingOrderWhenDescendingIsTrue(
			List<int> random, List<int> reversed)
		{
			this.output.WriteLine("Random Before Sort:\n{0}", random.PrintList());

			this.output.WriteLine("Reversed Array:\n{0}", reversed.PrintList());

			random.HeapSort(true);

			this.output.WriteLine("Random After Sort:\n{0}", random.PrintList());

			Assert.Equal(random, reversed);
		}

		/// <summary>
		/// Test that calling HeapSort on null remains a null.
		/// </summary>
		[Fact]
		public void CallingHeapSortOnANullReturnsNull()
		{
			IList<int> nullList = null;
			nullList.HeapSort();
			Assert.Null(nullList);
		}

		/// <summary>
		/// Test that calling HeapSort on an Empty array results in an empty
		/// array.
		/// </summary>
		[Fact]
		public void CallingHeapSortOnAnEmptyArrayReturnsEmptyArray()
		{
			IList<int> empty = new List<int>();
			empty.HeapSort();
			Assert.Empty(empty);
		}
	}
}
