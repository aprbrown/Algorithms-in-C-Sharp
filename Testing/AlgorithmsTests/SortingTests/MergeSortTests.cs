// -----------------------------------------------------------------------------
// <copyright file="MergeSortTests.cs" company="Andrew P R Brown">
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

	public class MergeSortTests
	{
		private readonly ITestOutputHelper output;
		private readonly SortingTests sT = SortingTests.Instance;

		public MergeSortTests(ITestOutputHelper output)
		{
			this.output = output;
		}

		[Fact]
		public void MergeSortWillOrderAListOf25ElementsFromLowestToHighest()
		{
			IList<int> random = this.sT.GetRandom25();
			IList<int> sorted = this.sT.GetOrdered25();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintList());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintList());

			random = random.MergeSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintList());

			Assert.Equal(sorted, random);
		}

		[Fact]
		public void MergeSortWillOrderAListOf50ElementsFromLowestToHighest()
		{
			IList<int> random = this.sT.GetRandom50();
			IList<int> sorted = this.sT.GetOrdered50();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintList());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintList());

			random = random.MergeSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintList());

			Assert.Equal(sorted, random);
		}

		[Fact]
		public void MergeSortWillOrderAListOf100ElementsFromLowestToHighest()
		{
			IList<int> random = this.sT.GetRandom100();
			IList<int> sorted = this.sT.GetOrdered100();

			this.output.WriteLine(
				"Random Before Sort:\n {0}", random.PrintList());

			this.output.WriteLine(
				"Sorted Array:\n {0}", sorted.PrintList());

			random = random.MergeSort();

			this.output.WriteLine(
				"Random After Sort:\n {0}", random.PrintList());

			Assert.Equal(sorted, random);
		}

		[Fact]
		public void CallingMergeSortOnANullReturnsNull()
		{
			IList<int> nullList = null;
			nullList = nullList.MergeSort();
			Assert.Null(nullList);
		}

		[Fact]
		public void CallingMergeSortOnAnEmptyArrayReturnsEmptyArray()
		{
			IList<int> empty = new List<int>();
			empty = empty.MergeSort();
			Assert.Empty(empty);
		}
	}
}
