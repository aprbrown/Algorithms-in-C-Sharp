// -----------------------------------------------------------------------------
// <copyright file="SortingRandomList.cs" company="Andrew P R Brown">
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
	public class SortingRandomList
	{
		private readonly int sizeOfList = Program.SizeOfList;
		private List<int> randomList;

		[GlobalSetup]
		public void GlobalSetup()
		{
			this.randomList =
				BenchmarkUtils.GetRandomListFromFile(this.sizeOfList);
		}

		// ** Random Array Benchmarks ******************************************

		// -- Insertion Methods ------------------------------------------------

		/// <summary>
		/// Benchmark the Insertion Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void InsertionSort()
		{
			List<int> insertionSortRandom = new List<int>(this.randomList);
			insertionSortRandom.InsertionSort();
		}

		/// <summary>
		/// Benchmark the Tree Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void TreeSort()
		{
			List<int> treeSortRandom = new List<int>(this.randomList);
			treeSortRandom.TreeSort();
		}

		// -- Selection Methods ------------------------------------------------

		/// <summary>
		/// Benchmark the Selection Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void SelectionSort()
		{
			List<int> selectionSortRandom = new List<int>(this.randomList);
			selectionSortRandom.SelectionSort();
		}

		/// <summary>
		/// Benchmark the Heap Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void HeapSort()
		{
			List<int> heapSortRandom = new List<int>(this.randomList);
			heapSortRandom.HeapSort();
		}

		// -- Merging Methods --------------------------------------------------

		/// <summary>
		/// Benchmark the Merge Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void MergeSort()
		{
			List<int> mergeSortRandom = new List<int>(this.randomList);
			mergeSortRandom.MergeSort();
		}

		// -- Partitioning Methods ---------------------------------------------

		/// <summary>
		/// Benchmark the Quick Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void QuickSort()
		{
			List<int> quickSortRandom = new List<int>(this.randomList);
			quickSortRandom.QuickSort();
		}

		// -- Exchanging Methods -----------------------------------------------

		/// <summary>
		/// Benchmark the Bubble Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void BubbleSort()
		{
			List<int> bubbleSortRandom = new List<int>(this.randomList);
			bubbleSortRandom.BubbleSort();
		}

		[GlobalCleanup]
		public void GlobalCleanup()
		{
			this.randomList =
				BenchmarkUtils.GetRandomListFromFile(this.sizeOfList);
		}
	}
}
