using System;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Algorithms.Sorting;

namespace Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class AlgorithmsSortingBenchmarks
    {
        // Setup
        // *********************************************************************
        static int sizeOfArray = 5_000;
        int[] randomArray = Utilities.RandomFillIntArray(sizeOfArray);
        int[] orderedArray = Utilities.FillOrderedArray(sizeOfArray);
        int[] reversedArray = Utilities.FillReverseOrderedArray(sizeOfArray);

        // Benchmarks
        // *********************************************************************
        // Random Array Benchmarks

        // ---- BubbleSort
        [Benchmark(Baseline = true)]
        public void RunBubbleSortRandom()
        {
            randomArray.BubbleSort();
        }
        // ---- SelectionSort
        [Benchmark]
        public void RunSelectionSortRandom()
        {
            randomArray.SelectionSort();
        }
        // ---- MergeSort
        [Benchmark]
        public void RunMergeSortRandom()
        {
            randomArray.MergeSort();
        }
        // ---- QuickSort
        [Benchmark]
        public void RunQuickSortRandom()
        {
            randomArray.QuickSort();
        }

        // ---------------------------------------------------------------------
        // Ordered Array Benchmarks

        // ---- BubbleSort
        [Benchmark]
        public void RunBubbleSortOrdered()
        {
            orderedArray.BubbleSort();
        }
        // ---- SelectionSort
        [Benchmark]
        public void RunSelectionSortOrdered()
        {
            orderedArray.SelectionSort();
        }
        // ---- MergeSort
        [Benchmark]
        public void RunMergeSortOrdered()
        {
            orderedArray.MergeSort();
        }
        // ---- QuickSort
        [Benchmark]
        public void RunQuickSortOrdered()
        {
            orderedArray.QuickSort();
        }

        // ---------------------------------------------------------------------
        // Reverse Ordered Array Benchmarks

        // ---- BubbleSort
        [Benchmark]
        public void RunBubbleSortReverse()
        {
            reversedArray.BubbleSort();
        }
        // ---- SelectionSort
        [Benchmark]
        public void RunSelectionSortReverse()
        {
            reversedArray.SelectionSort();
        }
        // ---- MergeSort
        [Benchmark]
        public void RunMergeSortReverse()
        {
            reversedArray.MergeSort();
        }
        // ---- QuickSort
        [Benchmark]
        public void RunQuickSortReverse()
        {
            reversedArray.QuickSort();
        }

        // ---------------------------------------------------------------------
    }
}
