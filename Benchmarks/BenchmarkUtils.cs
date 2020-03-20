// <copyright file="BenchmarkUtils.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Benchmarks
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.IO;
	using Algorithms.Helpers;

	/// <summary>
	/// Utility methods for use in the Benchmarks package.
	/// </summary>
	internal static class BenchmarkUtils
	{
		/// <summary>
		/// Method to check if a file of the required array length already
		/// exists, if it does then read the existing file and populate an array
		/// then return it. If not create a new file from a randomly generated
		/// array and then return the array. The purpose of this is so each
		/// benchmark is operating against the same array.
		/// </summary>
		/// <param name="sizeOfArray">Integer to determine the size of the
		/// returned array.</param>
		/// <returns>An integer array in random order.</returns>
		internal static int[] TestArray(int sizeOfArray)
		{
			Dictionary<string, string> directoryPaths =
				GetDirectoryPaths(sizeOfArray);

			int[] testArray = new int[sizeOfArray];

			if (!File.Exists(directoryPaths["randomArrayFile"]))
			{
				using StreamWriter sw =
					File.CreateText(directoryPaths["randomArrayFile"]);
				testArray = ArrayUtils.RandomisedArray(sizeOfArray);
				foreach (int number in testArray)
				{
					sw.WriteLine(number);
				}
			}
			else
			{
				using StreamReader sr =
					File.OpenText(directoryPaths["randomArrayFile"]);
				string s;
				for (int i = 0; i < sizeOfArray; i++)
				{
					if ((s = sr.ReadLine()) != null)
					{
						testArray[i] = int.Parse(
						s, CultureInfo.CurrentCulture);
					}
				}
			}

			return testArray;
		}

		/// <summary>
		/// Creates a set of directories to store artifacts relating to the
		/// Benchmarks being run if they do not already exist.
		/// </summary>
		/// <param name="sizeOfArray">integer of array size to generate paths
		/// relevant to the benchmarks being run.</param>
		internal static void GenerateDirectories(int sizeOfArray)
		{
			Dictionary<string, string> paths =
				GetDirectoryPaths(sizeOfArray);

			// Check if directories exist and if not create them.
			if (!Directory.Exists(paths["top"]))
			{
				Directory.CreateDirectory(paths["top"]);
			}

			if (!Directory.Exists(paths["random"]))
			{
				Directory.CreateDirectory(paths["random"]);
			}

			if (!Directory.Exists(paths["ordered"]))
			{
				Directory.CreateDirectory(paths["ordered"]);
			}

			if (!Directory.Exists(paths["reversed"]))
			{
				Directory.CreateDirectory(paths["reversed"]);
			}

			if (!Directory.Exists(paths["randomArrays"]))
			{
				Directory.CreateDirectory(paths["randomArrays"]);
			}
		}

		/// <summary>
		/// Creates a dictionary of strings representing directory and file
		/// paths for a number of uses with reporting Benchmarks.
		/// </summary>
		/// <param name="sizeOfArray">integer of array size to generate paths
		/// relevant to the benchmarks being run.</param>
		/// <returns>A Dictonary of string key and string value.</returns>
		internal static Dictionary<string, string> GetDirectoryPaths(int sizeOfArray)
		{
			DateTime dateTimeNow = DateTime.Now;
			string now = dateTimeNow.ToString(
			"yyyy-MM-dd_HH-mm", CultureInfo.CurrentCulture);

			Dictionary<string, string> paths =
				new Dictionary<string, string>();

			paths.Add(
				"fileStore",
				@"C:\Users\Public\Algorithms-In-C-Sharp-Generated-Files\");

			paths.Add(
				"top",
				paths["fileStore"] + @"BenchmarkResults\" + sizeOfArray + @"\" + now);

			paths.Add(
				"random",
				paths["top"] + @"\1_RandomArrays");

			paths.Add(
				"ordered",
				paths["top"] + @"\2_OrderedArrays");

			paths.Add(
				"reversed",
				paths["top"] + @"\3_ReversedArrays");

			paths.Add(
				"randomArrays",
				paths["fileStore"] + @"\RandomArrays");

			paths.Add(
				"randomArrayFile",
				paths["randomArrays"] + @"\" + sizeOfArray + ".txt");

			return paths;
		}

		/// <summary>
		/// Finds the files relating to a benchmark and moves them to a relevant
		/// location.
		/// </summary>
		/// <param name="reportPath">The path of the BencharkRunner.</param>
		/// <param name="destinationPath">The path of the destination
		/// directory.</param>
		internal static void MoveBenchmarkReports(string reportPath, string destinationPath)
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
