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

	/// <summary>
	/// Main program for benchmarks to be run.
	/// </summary>
	public static class Program
	{
		private const bool RunRandomBenchmark = true;
		private const bool RunOrderedBenchmark = true;
		private const bool RunReversedBenchmark = true;

		private static readonly CultureInfo Culture = new CultureInfo("en-GB");

		/// <summary>
		/// Main program to run benchmarks against the implemented algorithms
		/// throughout the project. Directories are created and report files
		/// moved to them based on size of array benchmarked against and the
		/// time the benchmark was initiated.
		/// </summary>
		public static void Main()
		{
			// Goto Benchmarks.cs to set the size of lists to be benchmarked.
			Dictionary<string, string> paths = GetDirectoryPaths(
				Benchmarks.SizeOfList);

			if (!Directory.Exists(paths["csv"]))
				Directory.CreateDirectory(paths["csv"]);

			if (!Directory.Exists(paths["html"]))
				Directory.CreateDirectory(paths["html"]);

			if (!Directory.Exists(paths["md"]))
				Directory.CreateDirectory(paths["md"]);

			string reportsPath;

			if (RunRandomBenchmark)
			{
				// Start benchmark runner for Random Lists.
				var randomListSummary =
					BenchmarkRunner.Run<SortingRandomList>();
				Console.WriteLine(randomListSummary);

				reportsPath = randomListSummary.ResultsDirectoryPath;
				MoveReports(reportsPath, paths);
			}

			if (RunOrderedBenchmark)
			{
				// Start benchmark runner for Ordered Arrays.
				var orderedListSummary =
					BenchmarkRunner.Run<SortingOrderedList>();
				Console.WriteLine(orderedListSummary);

				reportsPath = orderedListSummary.ResultsDirectoryPath;
				MoveReports(reportsPath, paths);
			}

			if (RunReversedBenchmark)
			{
				// Start benchmark runner for Reversed Arrays.
				var reversedListSummary =
					BenchmarkRunner.Run<SortingReversedList>();
				Console.WriteLine(reversedListSummary);

				reportsPath = reversedListSummary.ResultsDirectoryPath;
				MoveReports(reportsPath, paths);
			}
		}

		private static void MoveReports(
			string reportsPath, Dictionary<string, string> paths)
		{
			// Move resulting benchmark results to a new folder organised by
			// array size and the date and time benchmark was run.
			if (Directory.Exists(reportsPath))
			{
				string[] files = Directory.GetFiles(reportsPath);

				foreach (string s in files)
				{
					string fileName = Path.GetFileName(s);
					string sourcePath = Path.GetFullPath(s);

					if (fileName.EndsWith(".csv", true, Culture))
					{
						string destPath = Path.Combine(paths["csv"], fileName);
						File.Move(sourcePath, destPath, true);
					}

					if (fileName.EndsWith(".html", true, Culture))
					{
						string destPath = Path.Combine(paths["html"], fileName);
						File.Move(sourcePath, destPath, true);
					}

					if (fileName.EndsWith(".md", true, Culture))
					{
						string destPath = Path.Combine(paths["md"], fileName);
						File.Move(sourcePath, destPath, true);
					}
				}
			}
		}

		private static Dictionary<string, string> GetDirectoryPaths(int sizeOfList)
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
					"csv",
					$@"{benchmarks}\{today} - {sizeOfList}\CSV_Reports\"
				},
				{
					"html",
					$@"{benchmarks}\{today} - {sizeOfList}\HTML_Reports\"
				},
				{
					"md",
					$@"{benchmarks}\{today} - {sizeOfList}\MD_Reports\"
				},
			};

			return paths;
		}
	}
}
