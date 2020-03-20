// -----------------------------------------------------------------------------
// <copyright file="SortingBenchmarksRandomArray.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full
// license information.
// </copyright>
// -----------------------------------------------------------------------------

namespace Benchmarks
{
	using Algorithms.Helpers;
	using Algorithms.Sorting;
	using BenchmarkDotNet.Attributes;

	/// <summary>
	/// A suite of benchmarks to test a variety of sorting algorithms against a
	/// randomly ordered array.
	/// </summary>
	[MemoryDiagnoser]
	public class SortingBenchmarksRandomArray
	{
		/// <summary>
		/// Integer array for algorithms to be benchmarked against.
		/// </summary>
		private int[] randomArray;

		/// <summary>
		/// Method to be called before running each benchmark. Generating a
		/// fresh array to run the benchmark against.
		/// </summary>
		[GlobalSetup]
		public void GlobalSetup()
		{
			int sizeOfArray = Program.SizeOfArray;
			this.randomArray = BenchmarkUtils.TestArray(sizeOfArray);
		}

		// ** Random Array Benchmarks ******************************************

		// -- Insertion Methods ------------------------------------------------

		/// <summary>
		/// Benchmark the Insertion Sort Algorithm and assign its performance as
		/// the baseline others will be compared to.
		/// </summary>
		[Benchmark]
		public void InsertionSortRandom()
		{
			int[] insertionSortRandom =
				ArrayUtils.CopyFullArray(this.randomArray);
			insertionSortRandom.InsertionSort();
		}

		// -- Selection Methods ------------------------------------------------

		/// <summary>
		/// Benchmark the Selection Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void SelectionSortRandom()
		{
			int[] selectionSortRandom =
				ArrayUtils.CopyFullArray(this.randomArray);
			selectionSortRandom.SelectionSort();
		}

		/// <summary>
		/// Benchmark the Heap Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void HeapSortRandom()
		{
			int[] heapSortRandom = ArrayUtils.CopyFullArray(this.randomArray);
			heapSortRandom.HeapSort();
		}

		// -- Merging Methods --------------------------------------------------

		/// <summary>
		/// Benchmark the Merge Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void MergeSortRandom()
		{
			int[] mergeSortRandom = ArrayUtils.CopyFullArray(this.randomArray);
			mergeSortRandom.MergeSort();
		}

		// -- Partitioning Methods ---------------------------------------------

		/// <summary>
		/// Benchmark the Quick Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void QuickSortRandom()
		{
			int[] quickSortRandom = ArrayUtils.CopyFullArray(this.randomArray);
			quickSortRandom.QuickSort();
		}

		// -- Exchanging Methods -----------------------------------------------

		/// <summary>
		/// Benchmark the Bubble Sort Algorithm.
		/// </summary>
		[Benchmark(Baseline = true)]
		public void BubbleSortRandom()
		{
			int[] bubbleSortRandom = ArrayUtils.CopyFullArray(this.randomArray);
			bubbleSortRandom.BubbleSort();
		}
	}
}
