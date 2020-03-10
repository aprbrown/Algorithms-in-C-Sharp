using BenchmarkDotNet.Attributes;
using Algorithms.Sorting;

namespace Benchmarks
{
    [MemoryDiagnoser]
    public class AlgorithmsSortingBenchmarks
    {
        // Setup
        // *********************************************************************
        static int sizeOfArray = 10_000;
        int[] randomArray = Utils.RandomFillIntArray(sizeOfArray);
        int[] orderedArray = Utils.FillOrderedArray(sizeOfArray);
        int[] reversedArray = Utils.FillReverseOrderedArray(sizeOfArray);

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
        // ---- HeapSort
        [Benchmark]
        public void RunHeapSortRandom()
        {
            randomArray.HeapSort();
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
        // ---- HeapSort
        [Benchmark]
        public void RunHeapSortOrdered()
        {
            orderedArray.HeapSort();
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
        // ---- HeapSort
        [Benchmark]
        public void RunHeapSortReverse()
        {
            reversedArray.HeapSort();
        }

        // ---------------------------------------------------------------------
    }
}
