// -----------------------------------------------------------------------------
// <copyright file="TreeSortTests.cs" company="Andrew P R Brown">
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
	/// Suite of tests for the TreeSorter class.
	/// </summary>
	public class TreeSortTests
	{
		private readonly ITestOutputHelper output;

		/// <summary>
		/// Initializes a new instance of the <see cref="TreeSortTests"/>
		/// class.
		/// </summary>
		/// <param name="output">Instance of ITestOutputHelper.</param>
		public TreeSortTests(ITestOutputHelper output)
		{
			this.output = output;
		}

		/// <summary>
		/// Test that an array of 25 Random integers is correctly sorted with
		/// Tree Sort.
		/// </summary>
		[Fact]
		public void TreeSortAnArrayOfTwentyFiveRandomIntegers()
		{
			int[] random = SortingTestHelpers.GetRandomTwentyFiveArray();
			int[] sorted = SortingTestHelpers.GetSortedTwentyFiveArray();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintArray());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintArray());

			random.TreeSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintArray());

			Assert.Equal(sorted, random);
		}

		/// <summary>
		/// Test that an array of 50 Random integers is correctly sorted with
		/// Tree Sort.
		/// </summary>
		[Fact]
		public void TreeSortAnArrayOfFiftyRandomIntegers()
		{
			int[] random = SortingTestHelpers.GetRandomFiftyArray();
			int[] sorted = SortingTestHelpers.GetSortedFiftyArray();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintArray());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintArray());

			random.TreeSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintArray());

			Assert.Equal(sorted, random);
		}

		/// <summary>
		/// Test that an array of 100 Random integers is correctly sorted with
		/// Tree Sort.
		/// </summary>
		[Fact]
		public void TreeSortAnArrayOfOneHundredRandomIntegers()
		{
			int[] random = SortingTestHelpers.GetRandomHundredArray();
			int[] sorted = SortingTestHelpers.GetSortedHundredArray();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintArray());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintArray());

			random.TreeSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintArray());

			Assert.Equal(sorted, random);
		}

		/// <summary>
		/// Test that calling TreeSort on null remains a null.
		/// </summary>
		[Fact]
		public void CallingTreeSortOnANullReturnsNull()
		{
			int[] nullArray = null;
			nullArray.TreeSort();
			Assert.Null(nullArray);
		}

		/// <summary>
		/// Test that calling TreeSort on an Empty array results in an empty
		/// array.
		/// </summary>
		[Fact]
		public void CallingTreeSortOnAnEmptyArrayReturnsEmptyArray()
		{
			int[] empty = Array.Empty<int>();
			empty.TreeSort();
			Assert.Empty(empty);
		}
	}
}
