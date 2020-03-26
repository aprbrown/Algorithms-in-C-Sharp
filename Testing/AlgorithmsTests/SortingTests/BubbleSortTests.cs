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
	using Xunit;
	using Xunit.Abstractions;

	/// <summary>
	/// Tests for BubbleSort.
	/// </summary>
	public class BubbleSortTests
	{
		private readonly ITestOutputHelper output;
		private readonly SortingTests sT = SortingTests.Instance;

		/// <summary>
		/// Initializes a new instance of the <see cref="BubbleSortTests"/>
		/// class.
		/// </summary>
		/// <param name="output">Instance of ITestOutputHelper.</param>
		public BubbleSortTests(ITestOutputHelper output)
		{
			this.output = output;
		}

		/// <summary>
		/// Test that an array of 25 Random integers is correctly sorted with
		/// Bubble Sort.
		/// </summary>
		[Fact]
		public void BubbleSortWillOrderAListOf25ElementsFromLowestToHighest()
		{
			IList<int> random = this.sT.GetRandom25();
			IList<int> sorted = this.sT.GetOrdered25();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintList());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintList());

			random.BubbleSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintList());

			Assert.Equal(sorted, random);
		}

		/// <summary>
		/// Test that an array of 25 Random integers is correctly sorted in
		/// reverse order with Bubble Sort when reversed equals true.
		/// </summary>
		[Fact]
		public void BubbleSortWithReverseTrueWillOrderAListOf25ElementsFromHighestToLowest()
		{
			IList<int> random = this.sT.GetRandom25();
			IList<int> sorted = this.sT.GetReversed25();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintList());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintList());

			random.BubbleSort(true);

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintList());

			Assert.Equal(sorted, random);
		}

		/// <summary>
		/// Test that an array of 50 Random integers is correctly sorted with
		/// Bubble Sort.
		/// </summary>
		[Fact]
		public void BubbleSortWillOrderAListOf50ElementsFromLowestToHighest()
		{
			IList<int> random = this.sT.GetRandom50();
			IList<int> sorted = this.sT.GetOrdered50();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintList());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintList());

			random.BubbleSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintList());

			Assert.Equal(sorted, random);
		}

		/// <summary>
		/// Test that an array of 50 Random integers is correctly sorted in
		/// reverse order with Bubble Sort when reversed equals true.
		/// </summary>
		[Fact]
		public void BubbleSortWithReverseTrueWillOrderAListOf50ElementsFromHighestToLowest()
		{
			IList<int> random = this.sT.GetRandom50();
			IList<int> sorted = this.sT.GetReversed50();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintList());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintList());

			random.BubbleSort(true);

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintList());

			Assert.Equal(sorted, random);
		}

		/// <summary>
		/// Test that an array of 100 Random integers is correctly sorted with
		/// Bubble Sort.
		/// </summary>
		[Fact]
		public void BubbleSortWillOrderAListOf100ElementsFromLowestToHighest()
		{
			IList<int> random = this.sT.GetRandom100();
			IList<int> sorted = this.sT.GetOrdered100();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintList());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintList());

			random.BubbleSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintList());

			Assert.Equal(sorted, random);
		}

		/// <summary>
		/// Test that an array of 100 Random integers is correctly sorted in
		/// reverse order with Bubble Sort when reversed equals true.
		/// </summary>
		[Fact]
		public void BubbleSortWithReverseTrueWillOrderAListOf100ElementsFromHighestToLowest()
		{
			IList<int> random = this.sT.GetRandom100();
			IList<int> sorted = this.sT.GetReversed100();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintList());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintList());

			random.BubbleSort(true);

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintList());

			Assert.Equal(sorted, random);
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
