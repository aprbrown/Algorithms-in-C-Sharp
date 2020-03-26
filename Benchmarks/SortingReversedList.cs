// -----------------------------------------------------------------------------
// <copyright file="SortingReversedList.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full
// license information.
// </copyright>
// -----------------------------------------------------------------------------

namespace Benchmarks
{
	using System.Collections.Generic;
	using Algorithms.Helpers;
	using Algorithms.Sorting;
	using BenchmarkDotNet.Attributes;
	using BenchmarkDotNet.Order;

	[MemoryDiagnoser]
	[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
	[RankColumn]
	public class SortingReversedList
	{
		private readonly int sizeOfList = Program.SizeOfList;
		private List<int> reversedList;

		[GlobalSetup]
		public void GlobalSetup()
		{
			this.reversedList =
				BenchmarkUtils.GetReverseOrderedListFromFile(this.sizeOfList);
		}

		// ** Reverse Ordered Array Benchmarks *********************************

		// -- Insertion Methods ------------------------------------------------

		/// <summary>
		/// Benchmark the Insertion Sort Algorithm and assign its performance as
		/// the baseline others will be compared to.
		/// </summary>
		[Benchmark]
		public void InsertionSort()
		{
			List<int> insertionSortReverse = new List<int>(this.reversedList);
			insertionSortReverse.InsertionSort();
		}

		/// <summary>
		/// Benchmark the Tree Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void TreeSort()
		{
			List<int> treeSortReverse = new List<int>(this.reversedList);
			treeSortReverse.TreeSort();
		}

		// -- Selection Methods ------------------------------------------------

		/// <summary>
		/// Benchmark the Selection Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void SelectionSort()
		{
			List<int> selectionSortReverse = new List<int>(this.reversedList);
			selectionSortReverse.SelectionSort();
		}

		/// <summary>
		/// Benchmark the Heap Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void HeapSort()
		{
			List<int> heapSortReverse = new List<int>(this.reversedList);
			heapSortReverse.HeapSort();
		}

		// -- Merging Methods --------------------------------------------------

		/// <summary>
		/// Benchmark the Merge Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void MergeSort()
		{
			List<int> mergeSortReverse = new List<int>(this.reversedList);
			mergeSortReverse.MergeSort();
		}

		// -- Partitioning Methods ---------------------------------------------

		/// <summary>
		/// Benchmark the Quick Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void QuickSort()
		{
			List<int> quickSortReverse = new List<int>(this.reversedList);
			quickSortReverse.QuickSort();
		}

		// -- Exchanging Methods -----------------------------------------------

		/// <summary>
		/// Benchmark the Bubble Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void BubbleSort()
		{
			List<int> bubbleSortReverse = new List<int>(this.reversedList);
			bubbleSortReverse.BubbleSort();
		}

		[GlobalCleanup]
		public void GlobalCleanup()
		{
			this.reversedList =
				BenchmarkUtils.GetReverseOrderedListFromFile(this.sizeOfList);
		}
	}
}
