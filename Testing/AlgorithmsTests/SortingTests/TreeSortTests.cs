// -----------------------------------------------------------------------------
// <copyright file="TreeSortTests.cs" company="Andrew P R Brown">
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

	public class TreeSortTests
	{
		private static SortingTests Lists = new SortingTests();
		private readonly ITestOutputHelper output;

		public TreeSortTests(ITestOutputHelper output)
		{
			this.output = output;
		}

		public static IEnumerable<object[]> TreeSortDataAscending =>
			new List<object[]>
		{
			new object[] { Lists.GetRandomList25(), Lists.GetOrderedList25() },
			new object[] { Lists.GetRandomList50(), Lists.GetOrderedList50() },
			new object[] { Lists.GetRandomList100(), Lists.GetOrderedList100() },
		};

		public static IEnumerable<object[]> TreeSortDataDescending =>
			new List<object[]>
		{
			new object[] { Lists.GetRandomList25(), Lists.GetReversedList25() },
			new object[] { Lists.GetRandomList50(), Lists.GetReversedList50() },
			new object[] { Lists.GetRandomList100(), Lists.GetReversedList100() },
		};

		[Theory]
		[MemberData(nameof(TreeSortDataAscending))]
		public void TreeSortWillSortAListInAscendingOrder(
			IList<int> random, IList<int> ordered)
		{
			this.output.WriteLine("Random Before Sort:\n{0}", random.PrintList());

			this.output.WriteLine("Ordered Array:\n{0}", ordered.PrintList());

			random.TreeSort();

			this.output.WriteLine("Random After Sort:\n{0}", random.PrintList());

			Assert.Equal(random, ordered);
		}

		[Theory]
		[MemberData(nameof(TreeSortDataDescending))]
		public void TreeSortWillSortAListInDescendingOrderWhenDescendingIsTrue(
			IList<int> random, IList<int> reversed)
		{
			this.output.WriteLine("Random Before Sort:\n{0}", random.PrintList());

			this.output.WriteLine("Reversed Array:\n{0}", reversed.PrintList());

			random.TreeSort();

			this.output.WriteLine("Random After Sort:\n{0}", random.PrintList());

			Assert.Equal(random, reversed);
		}

		/// <summary>
		/// Test that calling TreeSort on null remains a null.
		/// </summary>
		[Fact]
		public void CallingTreeSortOnANullReturnsNull()
		{
			IList<int> nullList = null;
			nullList.TreeSort();
			Assert.Null(nullList);
		}

		/// <summary>
		/// Test that calling TreeSort on an Empty array results in an empty
		/// array.
		/// </summary>
		[Fact]
		public void CallingTreeSortOnAnEmptyArrayReturnsEmptyArray()
		{
			IList<int> empty = new List<int>();
			empty.TreeSort();
			Assert.Empty(empty);
		}
	}
}
