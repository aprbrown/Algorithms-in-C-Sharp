using System;

namespace Algorithms.Helpers
{
    public static class Utilities
    {
        public static void Swap(this int[] array, int firstIndex, int secondIndex)
        {
            int temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }

        public static string PrintArray(this int[] arrayToPrint)
        {
            string array = "[";
            for (int i = 0; i < arrayToPrint.Length; i++)
            {
                if (i != arrayToPrint.Length - 1)
                {
                    array += arrayToPrint[i];
                    array += ", ";
                }
                else array += arrayToPrint[i];
            }
            array += "]";

            return array;
        }

        public static int[] RandomFillIntArray(int sizeOfArray)
        {
            int[] randomIntArray = new int[sizeOfArray];
            var rand = new Random();
            for (int i = 0; i < sizeOfArray; i++) randomIntArray[i] = rand.Next(sizeOfArray) + 1;

            return randomIntArray;
        }

        public static int[] FillOrderedArray(int sizeOfArray)
        {
            int[] orderedArray = new int[sizeOfArray];
            for (int i = 0; i < sizeOfArray; i++)
                orderedArray[i] = i + 1;

            return orderedArray;
        }

        public static int[] FillReverseOrderedArray(int sizeOfArray)
        {
            int[] reversedArray = new int[sizeOfArray];
            int value = sizeOfArray;
            for (int i = 0; i < sizeOfArray; i++)
            {
                reversedArray[i] = value;
                value--;
            }

            return reversedArray;
        }
    }
}
