using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SortingAlgorithmsBenchmarks>();
            Console.WriteLine(summary);

            Console.ReadLine();
        }

        static string PrintArray(int[] arrayToPrint)
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
    }
}
