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
	using Xunit;
	using Xunit.Abstractions;

	public class QuickSortTests
	{
		private readonly ITestOutputHelper output;
		private readonly SortingTests sT = SortingTests.Instance;

		public QuickSortTests(ITestOutputHelper output)
		{
			this.output = output;
		}

		[Fact]
		public void QuickSortWillOrderAListOf25ElementsFromLowestToHighest()
		{
			IList<int> random = this.sT.GetRandom25();
			IList<int> sorted = this.sT.GetOrdered25();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintList());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintList());

			random.QuickSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintList());

			Assert.Equal(sorted, random);
		}

		[Fact]
		public void QuickSortWillOrderAListOf50ElementsFromLowestToHighest()
		{
			IList<int> random = this.sT.GetRandom50();
			IList<int> sorted = this.sT.GetOrdered50();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintList());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintList());

			random.QuickSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintList());

			Assert.Equal(sorted, random);
		}

		[Fact]
		public void QuickSortWillOrderAListOf100ElementsFromLowestToHighest()
		{
			IList<int> random = this.sT.GetRandom100();
			IList<int> sorted = this.sT.GetOrdered100();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintList());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintList());

			random.QuickSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintList());

			Assert.Equal(sorted, random);
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
