namespace Benchmarks
{
    class Utils
    {
        public static int[] RandomFillIntArray(int sizeOfArray)
        {
            return Algorithms.Helpers.Utilities.RandomFillIntArray(sizeOfArray);
        }

        public static int[] FillOrderedArray(int sizeOfArray)
        {
            return Algorithms.Helpers.Utilities.FillOrderedArray(sizeOfArray);
        }

        public static int[] FillReverseOrderedArray(int sizeOfArray)
        {
            return Algorithms.Helpers.Utilities.FillReverseOrderedArray(sizeOfArray);
        }

    }
}
