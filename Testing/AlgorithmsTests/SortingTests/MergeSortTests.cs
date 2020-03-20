// -----------------------------------------------------------------------------
// <copyright file="MergeSortTests.cs" company="Andrew P R Brown">
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
	/// Suite of tests for the MergeSorter class.
	/// </summary>
	public class MergeSortTests
	{
		private readonly ITestOutputHelper output;

		/// <summary>
		/// Initializes a new instance of the <see cref="MergeSortTests"/>
		/// class.
		/// </summary>
		/// <param name="output">Instance of ITestOutputHelper.</param>
		public MergeSortTests(ITestOutputHelper output)
		{
			this.output = output;
		}

		/// <summary>
		/// Test that an array of 25 Random integers is correctly sorted with
		/// Bubble Sort.
		/// </summary>
		[Fact]
		public void MergeSortAnArrayOfTwentyFiveRandomIntegers()
		{
			int[] random = SortingTestHelpers.GetRandomTwentyFiveArray();
			int[] sorted = SortingTestHelpers.GetSortedTwentyFiveArray();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintArray());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintArray());

			random = random.MergeSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintArray());

			Assert.Equal(sorted, random);
		}

		/// <summary>
		/// Test that an array of 50 Random integers is correctly sorted with
		/// Bubble Sort.
		/// </summary>
		[Fact]
		public void MergeSortAnArrayOfFiftyRandomIntegers()
		{
			int[] random = SortingTestHelpers.GetRandomFiftyArray();
			int[] sorted = SortingTestHelpers.GetSortedFiftyArray();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintArray());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintArray());

			random = random.MergeSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintArray());

			Assert.Equal(sorted, random);
		}

		/// <summary>
		/// Test that an array of 100 Random integers is correctly sorted with
		/// Bubble Sort.
		/// </summary>
		[Fact]
		public void MergeSortAnArrayOfOneHundredRandomIntegers()
		{
			int[] random = SortingTestHelpers.GetRandomHundredArray();
			int[] sorted = SortingTestHelpers.GetSortedHundredArray();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintArray());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintArray());

			random = random.MergeSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintArray());

			Assert.Equal(sorted, random);
		}

		/// <summary>
		/// Test that calling MergeSort on null remains a null.
		/// </summary>
		[Fact]
		public void CallingMergeSortOnANullReturnsNull()
		{
			int[] nullArray = null;
			nullArray = nullArray.MergeSort();
			Assert.Null(nullArray);
		}

		/// <summary>
		/// Test that calling MergeSort on an Empty array results in an empty
		/// array.
		/// </summary>
		[Fact]
		public void CallingMergeSortOnAnEmptyArrayReturnsEmptyArray()
		{
			int[] empty = Array.Empty<int>();
			empty = empty.MergeSort();
			Assert.Empty(empty);
		}
	}
}
