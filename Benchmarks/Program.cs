// -----------------------------------------------------------------------------
// <copyright file="Program.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full
// license information.
// </copyright>
// -----------------------------------------------------------------------------

namespace Benchmarks
{
	using System;
	using System.Collections.Generic;
	using BenchmarkDotNet.Running;

	/// <summary>
	/// Main program for benchmarks to be run.
	/// </summary>
	public static class Program
	{
		/// <summary>
		/// Gets the size of the list which benchmarks will be run against.
		/// </summary>
		internal static int SizeOfList { get; } = 250_000;

		/// <summary>
		/// Main program to run benchmarks against the implemented algorithms
		/// throughout the project. Directories are created and report files
		/// moved to them based on size of array benchmarked against and the
		/// time the benchmark was initiated.
		/// </summary>
		public static void Main()
		{
			BenchmarkUtils.GenerateDirectories(SizeOfList);
			Dictionary<string, string> directoryPaths =
				BenchmarkUtils.GetDirectoryPaths(SizeOfList);

			// Start benchmark runner for Random Arrays.
			var randomListSummary =
				BenchmarkRunner.Run<SortingRandomList>();
			Console.WriteLine(randomListSummary);

			string randomSourcePath = randomListSummary.ResultsDirectoryPath;
			BenchmarkUtils.MoveBenchmarkReports(
				randomSourcePath,
				directoryPaths["randomResults"]);

			// Start benchmark runner for Ordered Arrays.
			var orderedListSummary =
				BenchmarkRunner.Run<SortingOrderedList>();
			Console.WriteLine(orderedListSummary);

			string orderedSourcePath = orderedListSummary.ResultsDirectoryPath;
			BenchmarkUtils.MoveBenchmarkReports(
				orderedSourcePath,
				directoryPaths["orderedResults"]);

			// Start benchmark runner for Reversed Arrays.
			var reversedListSummary =
				BenchmarkRunner.Run<SortingReversedList>();
			Console.WriteLine(reversedListSummary);

			string reversedSourcePath =
				reversedListSummary.ResultsDirectoryPath;
			BenchmarkUtils.MoveBenchmarkReports(
				reversedSourcePath,
				directoryPaths["reversedResults"]);
		}
	}
}
