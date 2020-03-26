// -----------------------------------------------------------------------------
// <copyright file="SortingOrderedList.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full
// license information.
// </copyright>
// -----------------------------------------------------------------------------

namespace Benchmarks
{
	using System.Collections.Generic;
	using Algorithms.Sorting;
	using BenchmarkDotNet.Attributes;
	using BenchmarkDotNet.Order;

	[MemoryDiagnoser]
	[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
	[RankColumn]
	public class SortingOrderedList
	{
		private readonly int sizeOfList = Program.SizeOfList;
		private List<int> sortedList;

		[GlobalSetup]
		public void GlobalSetup()
		{
			this.sortedList =
				BenchmarkUtils.GetOrderedListFromFile(this.sizeOfList);
		}

		// ** Ordered Array Benchmarks *****************************************

		// -- Insertion Methods ------------------------------------------------

		/// <summary>
		/// Benchmark the Insertion Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void InsertionSort()
		{
			List<int> insertionSortOrdered = new List<int>(this.sortedList);
			insertionSortOrdered.InsertionSort();
		}

		/// <summary>
		/// Benchmark the Tree Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void TreeSort()
		{
			List<int> treeSortOrdered = new List<int>(this.sortedList);
			treeSortOrdered.TreeSort();
		}

		// -- Selection Methods ------------------------------------------------

		/// <summary>
		/// Benchmark the Selection Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void SelectionSort()
		{
			List<int> selectionSortOrdered = new List<int>(this.sortedList);
			selectionSortOrdered.SelectionSort();
		}

		/// <summary>
		/// Benchmark the Heap Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void HeapSort()
		{
			List<int> heapSortOrdered = new List<int>(this.sortedList);
			heapSortOrdered.HeapSort();
		}

		// -- Merging Methods --------------------------------------------------

		/// <summary>
		/// Benchmark the Merge Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void MergeSort()
		{
			List<int> mergeSortOrdered = new List<int>(this.sortedList);
			mergeSortOrdered.MergeSort();
		}

		// -- Partitioning Methods ---------------------------------------------

		/// <summary>
		/// Benchmark the Quick Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void QuickSort()
		{
			List<int> quickSortOrdered = new List<int>(this.sortedList);
			quickSortOrdered.QuickSort();
		}

		// -- Exchanging Methods -----------------------------------------------

		/// <summary>
		/// Benchmark the Bubble Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void BubbleSort()
		{
			List<int> bubbleSortOrdered = new List<int>(this.sortedList);
			bubbleSortOrdered.BubbleSort();
		}

		[GlobalCleanup]
		public void GlobalCleanup()
		{
			this.sortedList =
				BenchmarkUtils.GetOrderedListFromFile(this.sizeOfList);
		}
	}
}
