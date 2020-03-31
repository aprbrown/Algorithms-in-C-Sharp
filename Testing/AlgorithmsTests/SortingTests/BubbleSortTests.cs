// -----------------------------------------------------------------------------
// <copyright file="BubbleSortTests.cs" company="Andrew P R Brown">
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

	/// <summary>
	/// Tests for BubbleSort.
	/// </summary>
	public class BubbleSortTests
	{
		private static readonly SortingTests Lists = SortingTests.Instance;
		private readonly ITestOutputHelper output;

		/// <summary>
		/// Initializes a new instance of the <see cref="BubbleSortTests"/>
		/// class.
		/// </summary>
		/// <param name="output">Instance of ITestOutputHelper.</param>
		public BubbleSortTests(ITestOutputHelper output)
		{
			this.output = output;
		}

		public static IEnumerable<object[]> BubbleSortDataAscending =>
			new List<object[]>
		{
			new object[] { Lists.GetRandomList1(), Lists.GetOrderedList1() },
			new object[] { Lists.GetRandomList2(), Lists.GetOrderedList2() },
			new object[] { Lists.GetRandomList3(), Lists.GetOrderedList3() },
		};

		public static IEnumerable<object[]> BubbleSortDataDescending =>
			new List<object[]>
		{
			new object[] { Lists.GetRandomList1(), Lists.GetReversedList1() },
			new object[] { Lists.GetRandomList2(), Lists.GetReversedList2() },
			new object[] { Lists.GetRandomList3(), Lists.GetReversedList3() },
		};

		[Theory]
		[MemberData(nameof(BubbleSortDataAscending))]
		public void BubbleSortWillSortAListInAscendingOrder(
			IList<int> random, IList<int> ordered)
		{
			this.output.WriteLine("Random Before Sort:\n{0}", random.PrintList());

			this.output.WriteLine("Ordered Array:\n{0}", ordered.PrintList());

			random.BubbleSort();

			this.output.WriteLine("Random After Sort:\n{0}", random.PrintList());

			Assert.Equal(random, ordered);
		}

		[Theory]
		[MemberData(nameof(BubbleSortDataDescending))]
		public void BubbleSortWillSortAListInDescendingOrderWhenDescendingIsTrue(
			IList<int> random, IList<int> reversed)
		{
			this.output.WriteLine("Random Before Sort:\n{0}", random.PrintList());

			this.output.WriteLine("Reversed Array:\n{0}", reversed.PrintList());

			random.BubbleSort(true);

			this.output.WriteLine("Random After Sort:\n{0}", random.PrintList());

			Assert.Equal(random, reversed);
		}

		/// <summary>
		/// Test that calling BubbleSort on null remains a null.
		/// </summary>
		[Fact]
		public void CallingBubbleSortOnANullReturnsNull()
		{
			IList<int> nullList = null;
			nullList.BubbleSort();
			Assert.Null(nullList);
		}

		/// <summary>
		/// Test that calling BubbleSort on an Empty array results in an empty
		/// array.
		/// </summary>
		[Fact]
		public void CallingBubbleSortOnAnEmptyListRemainsEmpty()
		{
			IList<int> empty = new List<int>();
			empty.BubbleSort();
			Assert.Empty(empty);
		}
	}
}
