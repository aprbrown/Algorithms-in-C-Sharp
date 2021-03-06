﻿// -----------------------------------------------------------------------------
// <copyright file="SortingReversedList.cs" company="Andrew P R Brown">
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

	/// <summary>
	/// A class to benchmark sorting algorithms against a list of reverse
	/// ordered integers, this can highlight worst case performance in some
	/// algorithms.
	/// </summary>
	[MemoryDiagnoser]
	[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
	[RankColumn]
	public class SortingReversedList
	{
		private static Benchmarks instance;

		private List<int> insertionSort;
		private List<int> treeSort;
		private List<int> selectionSort;
		private List<int> heapSort;
		private List<int> mergeSort;
		private List<int> quickSort;
		private List<int> bubbleSort;

		/// <summary>
		/// A setup operation to generate an instance of the Benchmarks class.
		/// </summary>
		[GlobalSetup]
		public static void GlobalSetup()
		{
			instance = Benchmarks.Instance;
		}

		/// <summary>
		/// A setup operation for each iterations of the benchmark. This resets
		/// each list to the reference list.
		/// </summary>
		[IterationSetup]
		public void IterationSetup()
		{
			this.insertionSort = instance.GetReversedList();
			this.treeSort = instance.GetReversedList();
			this.selectionSort = instance.GetReversedList();
			this.heapSort = instance.GetReversedList();
			this.mergeSort = instance.GetReversedList();
			this.quickSort = instance.GetReversedList();
			this.bubbleSort = instance.GetReversedList();
		}

		// ** Reverse Ordered Array Benchmarks *********************************

			// -- Insertion Methods ------------------------------------------------

			/// <summary>
			/// Benchmark the Insertion Sort Algorithm and assign its performance as
			/// the baseline others will be compared to.
			/// </summary>
		[Benchmark]
		public void InsertionSort() => this.insertionSort.InsertionSort();

		/// <summary>
		/// Benchmark the Tree Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void TreeSort() => this.treeSort.TreeSort();

		// -- Selection Methods ------------------------------------------------

		/// <summary>
		/// Benchmark the Selection Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void SelectionSort() => this.selectionSort.SelectionSort();

		/// <summary>
		/// Benchmark the Heap Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void HeapSort() => this.heapSort.HeapSort();

		// -- Merging Methods --------------------------------------------------

		/// <summary>
		/// Benchmark the Merge Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void MergeSort() => this.mergeSort.MergeSort();

		// -- Partitioning Methods ---------------------------------------------

		/// <summary>
		/// Benchmark the Quick Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void QuickSort() => this.quickSort.QuickSort();

		// -- Exchanging Methods -----------------------------------------------

		/// <summary>
		/// Benchmark the Bubble Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void BubbleSort() => this.bubbleSort.BubbleSort();
	}
}
