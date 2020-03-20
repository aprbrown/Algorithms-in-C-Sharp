// -----------------------------------------------------------------------------
// <copyright file="BubbleSortTests.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full
// license information.
// </copyright>
// -----------------------------------------------------------------------------

namespace Testing.AlgorithmsTests.SortingTests
{
	using System;
	using Algorithms.Helpers;
	using Algorithms.Sorting;
	using Xunit;
	using Xunit.Abstractions;

	/// <summary>
	/// Suite of tests for the BubbleSorter class.
	/// </summary>
	public class BubbleSortTests
	{
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

		/// <summary>
		/// Test that an array of 25 Random integers is correctly sorted with
		/// Bubble Sort.
		/// </summary>
		[Fact]
		public void BubbleSortAnArrayOfTwentyFiveRandomIntegers()
		{
			int[] random = SortingTestHelpers.GetRandomTwentyFiveArray();
			int[] sorted = SortingTestHelpers.GetSortedTwentyFiveArray();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintArray());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintArray());

			random.BubbleSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintArray());

			Assert.Equal(sorted, random);
		}

		/// <summary>
		/// Test that an array of 50 Random integers is correctly sorted with
		/// Bubble Sort.
		/// </summary>
		[Fact]
		public void BubbleSortAnArrayOfFiftyRandomIntegers()
		{
			int[] random = SortingTestHelpers.GetRandomFiftyArray();
			int[] sorted = SortingTestHelpers.GetSortedFiftyArray();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintArray());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintArray());

			random.BubbleSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintArray());

			Assert.Equal(sorted, random);
		}

		/// <summary>
		/// Test that an array of 100 Random integers is correctly sorted with
		/// Bubble Sort.
		/// </summary>
		[Fact]
		public void BubbleSortAnArrayOfOneHundredRandomIntegers()
		{
			int[] random = SortingTestHelpers.GetRandomHundredArray();
			int[] sorted = SortingTestHelpers.GetSortedHundredArray();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintArray());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintArray());

			random.BubbleSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintArray());

			Assert.Equal(sorted, random);
		}

		/// <summary>
		/// Test that calling BubbleSort on null remains a null.
		/// </summary>
		[Fact]
		public void CallingBubbleSortOnANullReturnsNull()
		{
			int[] nullArray = null;
			nullArray.BubbleSort();
			Assert.Null(nullArray);
		}

		/// <summary>
		/// Test that calling BubbleSort on an Empty array results in an empty
		/// array.
		/// </summary>
		[Fact]
		public void CallingBubbleSortOnAnEmptyArrayReturnsEmptyArray()
		{
			int[] empty = Array.Empty<int>();
			empty.BubbleSort();
			Assert.Empty(empty);
		}
	}
}
