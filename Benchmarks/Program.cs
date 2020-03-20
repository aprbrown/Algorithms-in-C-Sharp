// <copyright file="Program.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Benchmarks
{
	using System;
	using System.Collections.Generic;
	using BenchmarkDotNet.Running;

	/// <summary>
	/// Main class of Benchmarks program.
	/// </summary>
	public static class Program
	{
		/// <summary>
		/// The size of the array for benchmarks to run against.
		/// </summary>
		internal const int SizeOfArray = 250_000;

		/// <summary>
		/// Main program to run benchmarks against the implemented algorithms
		/// throughout the project. Directories are created and report files
		/// moved to them based on size of array benchmarked against and the
		/// time the benchmark was initiated.
		/// </summary>
		public static void Main()
		{
			BenchmarkUtils.GenerateDirectories(SizeOfArray);
			Dictionary<string, string> directoryPaths =
				BenchmarkUtils.GetDirectoryPaths(SizeOfArray);

			// Start benchmark runner for Random Arrays.
			var randomArraySummary =
				BenchmarkRunner.Run<SortingBenchmarksRandomArray>();
			Console.WriteLine(randomArraySummary);

			string randomSourcePath = randomArraySummary.ResultsDirectoryPath;
			BenchmarkUtils.MoveBenchmarkReports(
				randomSourcePath,
				directoryPaths["random"]);

			// Start benchmark runner for Ordered Arrays.
			var orderedArraySummary =
				BenchmarkRunner.Run<SortingBenchmarksOrderedArray>();
			Console.WriteLine(orderedArraySummary);

			string orderedSourcePath = orderedArraySummary.ResultsDirectoryPath;
			BenchmarkUtils.MoveBenchmarkReports(
				orderedSourcePath,
				directoryPaths["ordered"]);

			// Start benchmark runner for Reversed Arrays.
			var reversedArraySummary =
				BenchmarkRunner.Run<SortingBenchmarksReversedArray>();
			Console.WriteLine(reversedArraySummary);

			string reversedSourcePath =
				reversedArraySummary.ResultsDirectoryPath;
			BenchmarkUtils.MoveBenchmarkReports(
				reversedSourcePath,
				directoryPaths["reversed"]);
		}
	}
}