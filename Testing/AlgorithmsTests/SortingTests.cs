using Algorithms.Sorting;
using System.Linq;
using Xunit;

namespace Testing.AlgorithmsTests
{
    public class SortingTests
    {
        int[] unorderedArray = { 4, 5, 3, 1, 5, 7, 10, 5, 3, 5, 2, 9, 3, 8, 5, 6 };
        int[] expectedSortedArray = { 1, 2, 3, 3, 3, 4, 5, 5, 5, 5, 5, 6, 7, 8, 9, 10 };

        [Fact]
        public void BubbleSortTest()
        {
            int[] sortedArray = unorderedArray.BubbleSort();
            Assert.True(sortedArray.SequenceEqual(expectedSortedArray));
        }

        [Fact]
        public void SelectionSortTest()
        {
            int[] sortedArray = unorderedArray.SelectionSort();
            Assert.True(sortedArray.SequenceEqual(expectedSortedArray));
        }

        [Fact]
        public void MergeSortTest()
        {
            int[] sortedArray = unorderedArray.MergeSort();
            Assert.True(sortedArray.SequenceEqual(expectedSortedArray));
        }

        [Fact]
        public void QuickSortTest()
        {
            int[] sortedArray = unorderedArray.QuickSort();
            Assert.True(sortedArray.SequenceEqual(expectedSortedArray));
        }

        [Fact]
        public void HeapSortTest()
        {
            int[] sortedArray = unorderedArray.HeapSort();
            Assert.True(sortedArray.SequenceEqual(expectedSortedArray));
        }
    }
}
