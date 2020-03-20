// -----------------------------------------------------------------------------
// <copyright file="HeapSortTests.cs" company="Andrew P R Brown">
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
	/// Suite of tests for the HeapSorter class.
	/// </summary>
	public class HeapSortTests
	{
		private readonly ITestOutputHelper output;

		/// <summary>
		/// Initializes a new instance of the <see cref="HeapSortTests"/>
		/// class.
		/// </summary>
		/// <param name="output">Instance of ITestOutputHelper.</param>
		public HeapSortTests(ITestOutputHelper output)
		{
			this.output = output;
		}

		/// <summary>
		/// Test that an array of 25 Random integers is correctly sorted with
		/// Bubble Sort.
		/// </summary>
		[Fact]
		public void HeapSortAnArrayOfTwentyFiveRandomIntegers()
		{
			int[] random = SortingTestHelpers.GetRandomTwentyFiveArray();
			int[] sorted = SortingTestHelpers.GetSortedTwentyFiveArray();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintArray());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintArray());

			random.HeapSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintArray());

			Assert.Equal(sorted, random);
		}

		/// <summary>
		/// Test that an array of 50 Random integers is correctly sorted with
		/// Bubble Sort.
		/// </summary>
		[Fact]
		public void HeapSortAnArrayOfFiftyRandomIntegers()
		{
			int[] random = SortingTestHelpers.GetRandomFiftyArray();
			int[] sorted = SortingTestHelpers.GetSortedFiftyArray();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintArray());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintArray());

			random.HeapSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintArray());

			Assert.Equal(sorted, random);
		}

		/// <summary>
		/// Test that an array of 100 Random integers is correctly sorted with
		/// Bubble Sort.
		/// </summary>
		[Fact]
		public void HeapSortAnArrayOfOneHundredRandomIntegers()
		{
			int[] random = SortingTestHelpers.GetRandomHundredArray();
			int[] sorted = SortingTestHelpers.GetSortedHundredArray();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintArray());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintArray());

			random.HeapSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintArray());

			Assert.Equal(sorted, random);
		}

		/// <summary>
		/// Test that calling HeapSort on null remains a null.
		/// </summary>
		[Fact]
		public void CallingHeapSortOnANullReturnsNull()
		{
			int[] nullArray = null;
			nullArray.HeapSort();
			Assert.Null(nullArray);
		}

		/// <summary>
		/// Test that calling HeapSort on an Empty array results in an empty
		/// array.
		/// </summary>
		[Fact]
		public void CallingHeapSortOnAnEmptyArrayReturnsEmptyArray()
		{
			int[] empty = Array.Empty<int>();
			empty.HeapSort();
			Assert.Empty(empty);
		}
	}
}
