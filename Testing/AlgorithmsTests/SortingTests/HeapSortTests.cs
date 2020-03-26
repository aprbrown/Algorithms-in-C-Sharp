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
	using Xunit;
	using Xunit.Abstractions;

	public class HeapSortTests
	{
		private readonly ITestOutputHelper output;
		private readonly SortingTests sT = SortingTests.Instance;

		public HeapSortTests(ITestOutputHelper output)
		{
			this.output = output;
		}

		[Fact]
		public void HeapSortWillOrderAListOf25ElementsFromLowestToHighest()
		{
			IList<int> random = this.sT.GetRandom25();
			IList<int> sorted = this.sT.GetOrdered25();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintList());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintList());

			random.HeapSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintList());

			Assert.Equal(sorted, random);
		}

		/// <summary>
		/// Test that an array of 25 Random integers is correctly sorted in
		/// reverse order with Heap Sort when reversed equals true.
		/// </summary>
		[Fact]
		public void HeapSortWithReverseTrueWillOrderAListOf25ElementsFromHighestToLowest()
		{
			IList<int> random = this.sT.GetRandom25();
			IList<int> sorted = this.sT.GetReversed25();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintList());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintList());

			random.HeapSort(true);

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintList());

			Assert.Equal(sorted, random);
		}

		/// <summary>
		/// Test that an array of 50 Random integers is correctly sorted with
		/// Bubble Sort.
		/// </summary>
		[Fact]
		public void HeapSortWillOrderAListOf50ElementsFromLowestToHighest()
		{
			IList<int> random = this.sT.GetRandom50();
			IList<int> sorted = this.sT.GetOrdered50();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintList());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintList());

			random.HeapSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintList());

			Assert.Equal(sorted, random);
		}

		/// <summary>
		/// Test that an array of 50 Random integers is correctly sorted in
		/// reverse order with Heap Sort when reversed equals true.
		/// </summary>
		[Fact]
		public void HeapSortWithReverseTrueWillOrderAListOf50ElementsFromHighestToLowest()
		{
			IList<int> random = this.sT.GetRandom50();
			IList<int> sorted = this.sT.GetReversed50();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintList());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintList());

			random.HeapSort(true);

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintList());

			Assert.Equal(sorted, random);
		}

		/// <summary>
		/// Test that an array of 100 Random integers is correctly sorted with
		/// Bubble Sort.
		/// </summary>
		[Fact]
		public void HeapSortWillOrderAListOf100ElementsFromLowestToHighest()
		{
			IList<int> random = this.sT.GetRandom100();
			IList<int> sorted = this.sT.GetOrdered100();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintList());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintList());

			random.HeapSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintList());

			Assert.Equal(sorted, random);
		}

		/// <summary>
		/// Test that an array of 100 Random integers is correctly sorted in
		/// reverse order with Heap Sort when reversed equals true.
		/// </summary>
		[Fact]
		public void HeapSortWithReverseTrueWillOrderAListOf100ElementsFromHighestToLowest()
		{
			IList<int> random = this.sT.GetRandom100();
			IList<int> sorted = this.sT.GetReversed100();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintList());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintList());

			random.HeapSort(true);

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintList());

			Assert.Equal(sorted, random);
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
