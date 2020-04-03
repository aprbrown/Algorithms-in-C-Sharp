// -----------------------------------------------------------------------------
// <copyright file="BubbleSortTests.cs" company="Andrew P R Brown">
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
	/// Tests for BubbleSort.
	/// </summary>
	public class BubbleSortTests : SortingTests
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BubbleSortTests"/>
		/// class.
		/// </summary>
		/// <param name="output">Instance of ITestOutputHelper allowing tests to
		/// show additional information.</param>
		public BubbleSortTests(ITestOutputHelper output)
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

			random.BubbleSort();

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

			random.BubbleSort(true);

			this.Output.WriteLine("Random After Sort:\n{0}", random.PrintList());

			Assert.Equal(random, reversed);
		}

		/// <inheritdoc/>
		[Fact]
		public override void CallingSortOnAnEmptyListRemainsEmpty()
		{
			IList<int> empty = new List<int>();
			empty.BubbleSort();
			Assert.Empty(empty);
		}

		/// <inheritdoc/>
		[Fact]
		public override void CallingSortOnANullReturnsNull()
		{
			IList<int> nullList = null;
			nullList.BubbleSort();
			Assert.Null(nullList);
		}
	}
}
