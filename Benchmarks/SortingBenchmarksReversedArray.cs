// <copyright file="SortingBenchmarksReversedArray.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Benchmarks
{
	using System;
	using Algorithms.Helpers;
	using Algorithms.Sorting;
	using BenchmarkDotNet.Attributes;

	/// <summary>
	/// A suite of benchmarks to test a variety of sorting algorithms against an
	/// array which is reverse order (highest to lowest).
	/// </summary>
	[MemoryDiagnoser]
	public class SortingBenchmarksReversedArray
	{
		/// <summary>
		/// Integer array for algorithms to be benchmarked against.
		/// </summary>
		private int[] reversedArray;

		/// <summary>
		/// Method to be called before running each benchmark. Generating a
		/// fresh array to run the benchmark against.
		/// </summary>
		[GlobalSetup]
		public void GlobalSetup()
		{
			int sizeOfArray = Program.SizeOfArray;
			this.reversedArray =
				ArrayUtils.FillReverseOrderedArray(sizeOfArray);
		}

		// ** Reverse Ordered Array Benchmarks *********************************

		// -- Insertion Methods ------------------------------------------------

		/// <summary>
		/// Benchmark the Insertion Sort Algorithm and assign its performance as
		/// the baseline others will be compared to.
		/// </summary>
		[Benchmark]
		public void InsertionSortReverse()
		{
			int[] insertionSortReverse =
				ArrayUtils.CopyFullArray(this.reversedArray);
			insertionSortReverse.InsertionSort();
		}

		// -- Selection Methods ------------------------------------------------

		/// <summary>
		/// Benchmark the Selection Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void SelectionSortReverse()
		{
			int[] selectionSortReverse =
				ArrayUtils.CopyFullArray(this.reversedArray);
			selectionSortReverse.SelectionSort();
		}

		/// <summary>
		/// Benchmark the Heap Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void HeapSortReverse()
		{
			int[] heapSortReverse =
				ArrayUtils.CopyFullArray(this.reversedArray);
			heapSortReverse.HeapSort();
		}

		// -- Merging Methods --------------------------------------------------

		/// <summary>
		/// Benchmark the Merge Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void MergeSortReverse()
		{
			int[] mergeSortReverse =
				ArrayUtils.CopyFullArray(this.reversedArray);
			mergeSortReverse.MergeSort();
		}

		// -- Partitioning Methods ---------------------------------------------

		/// <summary>
		/// Benchmark the Quick Sort Algorithm.
		/// </summary>
		[Benchmark]
		public void QuickSortReverse()
		{
			int[] quickSortReverse =
				ArrayUtils.CopyFullArray(this.reversedArray);
			quickSortReverse.QuickSort();
		}

		// -- Exchanging Methods -----------------------------------------------

		/// <summary>
		/// Benchmark the Bubble Sort Algorithm.
		/// </summary>
		[Benchmark(Baseline = true)]
		public void BubbleSortReverse()
		{
			int[] bubbleSortReverse =
				ArrayUtils.CopyFullArray(this.reversedArray);
			bubbleSortReverse.BubbleSort();
		}
	}
}
