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
	using Benchmarks.Helpers;

	[MemoryDiagnoser]
	[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
	[RankColumn]
	public class SortingRandomList
	{
		private static Benchmarks instance;

		private List<int> insertionSort;
		private List<int> treeSort;
		private List<int> selectionSort;
		private List<int> heapSort;
		private List<int> mergeSort;
		private List<int> quickSort;
		private List<int> bubbleSort;

		[GlobalSetup]
		public void GlobalSetup()
		{
			instance = Benchmarks.Instance;
		}

		[IterationSetup]
		public void IterationSetup()
		{
			this.insertionSort = instance.GetRandomList();
			this.treeSort = instance.GetRandomList();
			this.selectionSort = instance.GetRandomList();
			this.heapSort = instance.GetRandomList();
			this.mergeSort = instance.GetRandomList();
			this.quickSort = instance.GetRandomList();
			this.bubbleSort = instance.GetRandomList();
		}

		// ** Random Array Benchmarks ******************************************

			// -- Insertion Methods ------------------------------------------------

			/// <summary>
			/// Benchmark the Insertion Sort Algorithm.
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
