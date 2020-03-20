// <copyright file="SortingBenchmarksOrderedArray.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Benchmarks
{
	using Algorithms.Helpers;
	using Algorithms.Sorting;
	using BenchmarkDotNet.Attributes;

	/// <summary>
	/// A suite of benchmarks to test a variety of sorting algorithms against an
	/// array which is already in order.
	/// </summary>
	[MemoryDiagnoser]
	public class SortingBenchmarksOrderedArray
	{
		/// <summary>
		/// Integer array for algorithms to be benchmarked against.
		/// </summary>
		private int[] orderedArray;

		/// <summary>
		/// Method to be called before running each benchmark. Generating a
		/// fresh array to run the benchmark against.
		/// </summary>
		[GlobalSetup]
		public void GlobalSetup()
		{
			int sizeOfArray = Program.SizeOfArray;
			this.orderedArray = ArrayUtils.FillOrderedArray(sizeOfArray);
		}

		// ** Ordered Array Benchmarks *****************************************

		// -- Insertion Methods ------------------------------------------------

		/// <summary>
		/// Benchmark the Insertion Sort Algorithm and assign its performance as
		/// the baseline others will be compared to.
		/// </summary>
		[Benchmark]
		public void InsertionSortOrdered() => this.orderedArray.InsertionSort();

		// -- Selection Methods ------------------------------------------------

		/// <summary>
		/// Benchmark the Selection Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void SelectionSortOrdered() => this.orderedArray.SelectionSort();

		/// <summary>
		/// Benchmark the Heap Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void HeapSortOrdered() => this.orderedArray.HeapSort();

		// -- Merging Methods --------------------------------------------------

		/// <summary>
		/// Benchmark the Merge Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void MergeSortOrdered() => this.orderedArray.MergeSort();

		// -- Partitioning Methods ---------------------------------------------

		/// <summary>
		/// Benchmark the Quick Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void QuickSortOrdered() => this.orderedArray.QuickSort();

		// -- Exchanging Methods -----------------------------------------------

		/// <summary>
		/// Benchmark the Bubble Sort Algorithm.
		/// </summary>
		[Benchmark(Baseline = true)]
		public void BubbleSortOrdered() => this.orderedArray.BubbleSort();
	}
}
