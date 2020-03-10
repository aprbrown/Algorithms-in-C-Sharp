using System;
using BenchmarkDotNet.Running;

namespace Benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<AlgorithmsSortingBenchmarks>();
            Console.WriteLine(summary);

            Console.ReadLine();
        }
    }
}