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
	using System.Globalization;
	using System.IO;
	using BenchmarkDotNet.Running;
	using Benchmarks.Helpers;

	/// <summary>
	/// Main program for benchmarks to be run.
	/// </summary>
	public static class Program
	{
		/// <summary>
		/// Main program to run benchmarks against the implemented algorithms
		/// throughout the project. Directories are created and report files
		/// moved to them based on size of array benchmarked against and the
		/// time the benchmark was initiated.
		/// </summary>
		public static void Main()
		{
			Dictionary<string, string> paths = GetDirectoryPaths(Benchmarks.SizeOfList);

			if (!Directory.Exists(paths["randomResults"])) Directory.CreateDirectory(paths["randomResults"]);
			if (!Directory.Exists(paths["orderedResults"])) Directory.CreateDirectory(paths["orderedResults"]);
			if (!Directory.Exists(paths["reversedResults"])) Directory.CreateDirectory(paths["reversedResults"]);
			if (!Directory.Exists(paths["lists"])) Directory.CreateDirectory(paths["lists"]);

			RunRandomListBenchmarks(paths);

			RunOrderedListBenchmarks(paths);

			RunReversedListBenchmarks(paths);
		}

		private static void RunReversedListBenchmarks(Dictionary<string, string> paths)
		{
			// Start benchmark runner for Reversed Arrays.
			var reversedListSummary =
				BenchmarkRunner.Run<SortingReversedList>();
			Console.WriteLine(reversedListSummary);

			string reversedSourcePath =
				reversedListSummary.ResultsDirectoryPath;
			MoveBenchmarkReports(reversedSourcePath, paths["reversedResults"]);
		}

		private static void RunOrderedListBenchmarks(Dictionary<string, string> paths)
		{
			// Start benchmark runner for Ordered Arrays.
			var orderedListSummary =
				BenchmarkRunner.Run<SortingOrderedList>();
			Console.WriteLine(orderedListSummary);

			string orderedSourcePath = orderedListSummary.ResultsDirectoryPath;
			MoveBenchmarkReports(orderedSourcePath, paths["orderedResults"]);
		}

		private static void RunRandomListBenchmarks(Dictionary<string, string> paths)
		{
			// Start benchmark runner for Random Lists.
			var randomListSummary =
				BenchmarkRunner.Run<SortingRandomList>();
			Console.WriteLine(randomListSummary);

			string randomSourcePath = randomListSummary.ResultsDirectoryPath;
			MoveBenchmarkReports(randomSourcePath, paths["randomResults"]);
		}

		internal static Dictionary<string, string> GetDirectoryPaths(int sizeOfList)
		{
			string today = DateTime.Now.ToString(
				"yyyy-MM-dd_HH-mm",
				new CultureInfo("en-GB"));

			string root =
				Environment.GetFolderPath(Environment.SpecialFolder.Personal) +
				$@"\Algorithms-In-C-Sharp-Generated-Files";

			string benchmarks =
				$@"{root}\BenchmarkResults";

			Dictionary<string, string> paths = new Dictionary<string, string>
			{
				{
					"randomResults",
					$@"{benchmarks}\{sizeOfList}\{today}\1_RandomLists\"
				},
				{
					"orderedResults",
					$@"{benchmarks}\{sizeOfList}\{today}\2_OrderedLists\"
				},
				{
					"reversedResults",
					$@"{benchmarks}\{sizeOfList}\{today}\3_ReversedLists\"
				},
				{
					"lists",
					$@"{root}\Lists"
				},
			};

			return paths;
		}

		private static void MoveBenchmarkReports(
			string reportPath, string destinationPath)
		{
			// Move resulting benchmark results to a new folder organised by
			// array size and the date and time benchmark was run.
			if (Directory.Exists(reportPath))
			{
				string[] files = Directory.GetFiles(reportPath);

				foreach (string s in files)
				{
					string fileName = Path.GetFileName(s);
					string sourcePath = Path.GetFullPath(s);
					string destPath = Path.Combine(destinationPath, fileName);

					File.Move(sourcePath, destPath, true);
				}
			}
		}
	}
}
