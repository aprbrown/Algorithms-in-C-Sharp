// -----------------------------------------------------------------------------
// <copyright file="MergeSortTests.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full
// license information.
// </copyright>
// -----------------------------------------------------------------------------

namespace Testing.AlgorithmsTests.SortingTesters
{
	using System.Collections.Generic;
	using Algorithms.Sorting;
	using Testing.AlgorithmsTests.Helpers;
	using Xunit;
	using Xunit.Abstractions;

	/// <summary>
	/// Tests for MergeSort.
	/// </summary>
	public class MergeSortTests : SortingTests
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MergeSortTests"/>
		/// class.
		/// </summary>
		/// <param name="output">Instance of ITestOutputHelper allowing tests to
		/// show additional information.</param>
		public MergeSortTests(ITestOutputHelper output)
			: base(output)
		{
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(GetDataForAscendingSort))]
		public override void SortListsInAscendingOrder(IList<int> random, IList<int> ordered)
		{
			this.Output.WriteLine("Random Before Sort:\n{0}", random.PrintList());

			this.Output.WriteLine("Ordered Array:\n{0}", ordered.PrintList());

			random = random.MergeSort();

			this.Output.WriteLine("Random After Sort:\n{0}", random.PrintList());

			Assert.Equal(random, ordered);
		}

		/// <inheritdoc/>
		[Theory]
		[MemberData(nameof(GetDataForDescendingSort))]
		public override void SortListsInDescendingOrder(IList<int> random, IList<int> reversed)
		{
			this.Output.WriteLine("Random Before Sort:\n{0}", random.PrintList());

			this.Output.WriteLine("Reversed Array:\n{0}", reversed.PrintList());

			// random = random.MergeSort(true);
			this.Output.WriteLine("Random After Sort:\n{0}", random.PrintList());

			Assert.Equal(random, reversed);
		}

		/// <inheritdoc/>
		[Fact]
		public override void CallingSortOnAnEmptyListRemainsEmpty()
		{
			IList<int> empty = new List<int>();
			empty.MergeSort();
			Assert.Empty(empty);
		}

		/// <inheritdoc/>
		[Fact]
		public override void CallingSortOnANullReturnsNull()
		{
			IList<int> nullList = null;
			nullList.MergeSort();
			Assert.Null(nullList);
		}
	}
}
