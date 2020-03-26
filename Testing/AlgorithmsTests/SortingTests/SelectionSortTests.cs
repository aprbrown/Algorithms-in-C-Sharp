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
	using Xunit;
	using Xunit.Abstractions;

	public class SelectionSortTests
	{
		private readonly ITestOutputHelper output;
		private readonly SortingTests sT = SortingTests.Instance;

		public SelectionSortTests(ITestOutputHelper output)
		{
			this.output = output;
		}

		[Fact]
		public void SelectionSortWillOrderAListOf25ElementsFromLowestToHighest()
		{
			IList<int> random = this.sT.GetRandom25();
			IList<int> sorted = this.sT.GetOrdered25();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintList());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintList());

			random.SelectionSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintList());

			Assert.Equal(sorted, random);
		}

		[Fact]
		public void SelectionSortWillOrderAListOf50ElementsFromLowestToHighest()
		{
			IList<int> random = this.sT.GetRandom50();
			IList<int> sorted = this.sT.GetOrdered50();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintList());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintList());

			random.SelectionSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintList());

			Assert.Equal(sorted, random);
		}

		[Fact]
		public void SelectionSortWillOrderAListOf100ElementsFromLowestToHighest()
		{
			IList<int> random = this.sT.GetRandom100();
			IList<int> sorted = this.sT.GetOrdered100();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintList());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintList());

			random.SelectionSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintList());

			Assert.Equal(sorted, random);
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
