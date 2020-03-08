using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace SortingAlgorithms
{
    [MemoryDiagnoser]
    public class SortingAlgorithmsBenchmarks
    {
        static int sizeOfArray = 1_000_000;

        int[] jumbledArray = RandomFillIntArray(sizeOfArray);

        // [Benchmark(Baseline = true)]
        // public void RunBubbleSort()
        // {
        //     Bubble.Sort(jumbledArray);
        // }

        [Benchmark]
        public void RunMergeSort()
        {
            Merge.Sort(jumbledArray);
        }

        [Benchmark]
        public void RunQuickSort()
        {
            Quick.Sort(jumbledArray);
        }

        static int[] RandomFillIntArray(int numberOfElements)
        {
            int[] randomIntArray = new int[numberOfElements];
            var rand = new Random();
            for (int i = 0; i < numberOfElements; i++) randomIntArray[i] = rand.Next(numberOfElements) + 1;
            return randomIntArray;
        }
    }
}
