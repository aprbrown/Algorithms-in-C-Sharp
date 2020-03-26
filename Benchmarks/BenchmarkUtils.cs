// -----------------------------------------------------------------------------
// <copyright file="BenchmarkUtils.cs" company="Andrew P R Brown">
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
	using System.Runtime.Serialization.Formatters.Binary;

	internal static class BenchmarkUtils
	{
		public static List<int> GetOrderedListFromFile(int sizeOfList)
		{
			Dictionary<string, string> paths =
				GetDirectoryPaths(sizeOfList);

			List<int> list;
			string path = paths["orderedListFile"];

			if (!File.Exists(path))
			{
				list = GetRandomListFromFile(sizeOfList);
				list.Sort();

				Stream stream = File.Open(path, FileMode.Create);
				BinaryFormatter bin = new BinaryFormatter();
				bin.Serialize(stream, list);
				stream.Close();
			}
			else
			{
				Stream stream = File.Open(path, FileMode.Open);
				BinaryFormatter bin = new BinaryFormatter();
				list = (List<int>)bin.Deserialize(stream);
				stream.Close();
			}

			return list;
		}

		public static List<int> GetReverseOrderedListFromFile(int sizeOfList)
		{
			Dictionary<string, string> paths =
				GetDirectoryPaths(sizeOfList);

			List<int> list;
			string path = paths["reversedListFile"];

			if (!File.Exists(path))
			{
				list = GetOrderedListFromFile(sizeOfList);
				list.Reverse();

				Stream stream = File.Open(path, FileMode.Create);
				BinaryFormatter bin = new BinaryFormatter();
				bin.Serialize(stream, list);
				stream.Close();
			}
			else
			{
				Stream stream = File.Open(path, FileMode.Open);
				BinaryFormatter bin = new BinaryFormatter();
				list = (List<int>)bin.Deserialize(stream);
				stream.Close();
			}

			return list;
		}

		internal static Dictionary<string, string> GetDirectoryPaths(
			int sizeOfList)
		{
			DateTime now = DateTime.Now;
			string today = now.ToString(
				"yyyy-MM-dd_HH-mm",
				new CultureInfo("en-GB"));
			string root = Environment.GetFolderPath(
				Environment.SpecialFolder.Personal) +
				$@"\Algorithms-In-C-Sharp-Generated-Files";
			string benchmarks =
				$@"{root}\BenchmarkResults";
			string lists =
				$@"{root}\Lists";
			Dictionary<string, string> paths = new Dictionary<string, string>
			{
				{
					"root",
					root
				},
				{
					"benchmarks",
					benchmarks
				},
				{
					"bMarkListSize",
					$@"{benchmarks}\{sizeOfList}\"
				},
				{
					"bMarkDate",
					$@"{benchmarks}\{sizeOfList}\{today}"
				},
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
					lists
				},
				{
					"randomListFile",
					$@"{lists}\{sizeOfList}_random.bin"
				},
				{
					"orderedListFile",
					$@"{lists}\{sizeOfList}_ordered.bin"
				},
				{
					"reversedListFile",
					$@"{lists}\{sizeOfList}_reversed.bin"
				},
			};

			return paths;
		}

		internal static void GenerateDirectories(int sizeOfArray)
		{
			Dictionary<string, string> paths =
				GetDirectoryPaths(sizeOfArray);

			// Check if directories exist and if not create them.
			if (!Directory.Exists(paths["root"]))
			{
				Directory.CreateDirectory(paths["root"]);
			}

			if (!Directory.Exists(paths["randomResults"]))
			{
				Directory.CreateDirectory(paths["randomResults"]);
			}

			if (!Directory.Exists(paths["orderedResults"]))
			{
				Directory.CreateDirectory(paths["orderedResults"]);
			}

			if (!Directory.Exists(paths["reversedResults"]))
			{
				Directory.CreateDirectory(paths["reversedResults"]);
			}

			if (!Directory.Exists(paths["lists"]))
			{
				Directory.CreateDirectory(paths["lists"]);
			}
		}

		internal static List<int> GetRandomListFromFile(int sizeOfList)
		{
			Dictionary<string, string> paths =
				GetDirectoryPaths(sizeOfList);

			List<int> list;

			string path = paths["randomListFile"];

			if (!File.Exists(path))
			{
				int min = sizeOfList - (3 * sizeOfList);
				int max = 2 * sizeOfList;

				list = new List<int>();
				Random rand = new Random();

				for (int i = 0; i < sizeOfList; i++)
					list.Add(rand.Next(min, max));

				Stream stream = File.Open(path, FileMode.Create);
				BinaryFormatter bin = new BinaryFormatter();
				bin.Serialize(stream, list);
				stream.Close();
			}
			else
			{
				Stream stream = File.Open(path, FileMode.Open);
				BinaryFormatter bin = new BinaryFormatter();
				list = (List<int>)bin.Deserialize(stream);
				stream.Close();
			}

			return list;
		}

		internal static void MoveBenchmarkReports(
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
