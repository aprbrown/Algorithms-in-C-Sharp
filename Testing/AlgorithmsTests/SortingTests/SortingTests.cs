// -----------------------------------------------------------------------------
// <copyright file="SortingTests.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full
// license information.
// </copyright>
// -----------------------------------------------------------------------------

namespace Testing.AlgorithmsTests.SortingTests
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Runtime.Serialization.Formatters.Binary;

	/// <summary>
	/// A class to streamline testing of the sorting algorithms. Lists are
	/// created and saved to disk and if a list already exists it is read from
	/// file. All lists are loaded into a thread safe Singleton to prevent IO
	/// exceptions when multiple test classes access the files at the same time.
	/// All get methods return a copy of the list so tests do not alter original
	/// lists.
	/// </summary>
	internal sealed class SortingTests : IDisposable
	{
		private static readonly object SyncLock = new object();
		private static volatile SortingTests instance;
		private readonly List<int> random25;
		private readonly List<int> ordered25;
		private readonly List<int> reversed25;
		private readonly List<int> random50;
		private readonly List<int> ordered50;
		private readonly List<int> reversed50;
		private readonly List<int> random100;
		private readonly List<int> ordered100;
		private readonly List<int> reversed100;
		private bool disposed = false;

		private SortingTests()
		{
			this.random25 = this.GetListFromFile(25, ListStyles.Random);
			this.ordered25 = this.GetListFromFile(25, ListStyles.Ordered);
			this.reversed25 = this.GetListFromFile(25, ListStyles.Reversed);

			this.random50 = this.GetListFromFile(50, ListStyles.Random);
			this.ordered50 = this.GetListFromFile(50, ListStyles.Ordered);
			this.reversed50 = this.GetListFromFile(50, ListStyles.Reversed);

			this.random100 = this.GetListFromFile(100, ListStyles.Random);
			this.ordered100 = this.GetListFromFile(100, ListStyles.Ordered);
			this.reversed100 = this.GetListFromFile(100, ListStyles.Reversed);
		}

		/// <summary>
		/// Finalizes an instance of the <see cref="SortingTests"/> class.
		/// </summary>
		~SortingTests()
		{
			this.Dispose(false);
		}

		private enum ListStyles
		{
			Random,
			Ordered,
			Reversed,
		}

		/// <summary>
		/// Gets a singleton instance of SortingTests.
		/// </summary>
		public static SortingTests Instance
		{
			get
			{
				if (instance != null) return instance;

				lock (SyncLock)
				{
					if (instance == null)
					{
						instance = new SortingTests();
					}
				}

				return instance;
			}
		}

		/// <summary>
		/// Gets a list of 25 random integers.
		/// </summary>
		/// <returns>Copy of the random25 list.</returns>
		public List<int> GetRandom25()
		{
			return new List<int>(this.random25);
		}

		/// <summary>
		/// Gets a list of 25 ordered integers.
		/// </summary>
		/// <returns>Copy of the ordered25 list.</returns>
		public List<int> GetOrdered25()
		{
			return new List<int>(this.ordered25);
		}

		/// <summary>
		/// Gets a list of 25 reverse ordered integers.
		/// </summary>
		/// <returns>Copy of the reversed25 list.</returns>
		public List<int> GetReversed25()
		{
			return new List<int>(this.reversed25);
		}

		/// <summary>
		/// Gets a list of 50 random integers.
		/// </summary>
		/// <returns>Copy of the random50 list.</returns>
		public List<int> GetRandom50()
		{
			return new List<int>(this.random50);
		}

		/// <summary>
		/// Gets a list of 50 ordered integers.
		/// </summary>
		/// <returns>Copy of the ordered50 list.</returns>
		public List<int> GetOrdered50()
		{
			return new List<int>(this.ordered50);
		}

		/// <summary>
		/// Gets a list of 50 reverse ordered integers.
		/// </summary>
		/// <returns>Copy of the reversed50 list.</returns>
		public List<int> GetReversed50()
		{
			return new List<int>(this.reversed50);
		}

		/// <summary>
		/// Gets a list of 100 random integers.
		/// </summary>
		/// <returns>Copy of the random100 list.</returns>
		public List<int> GetRandom100()
		{
			return new List<int>(this.random100);
		}

		/// <summary>
		/// Gets a list of 100 ordered integers.
		/// </summary>
		/// <returns>Copy of the ordered100 list.</returns>
		public List<int> GetOrdered100()
		{
			return new List<int>(this.ordered100);
		}

		/// <summary>
		/// Gets a list of 100 reverse ordered integers.
		/// </summary>
		/// <returns>Copy of the reversed100 list.</returns>
		public List<int> GetReversed100()
		{
			return new List<int>(this.reversed100);
		}

		/// <inheritdoc/>
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		private static Dictionary<string, string> GetDirectoryPaths(
			int sizeOfList)
		{
			string root = Environment.GetFolderPath(
				Environment.SpecialFolder.Personal) +
				$@"\Algorithms-In-C-Sharp-Generated-Files";
			string lists = $@"{root}\Lists\";
			Dictionary<string, string> paths =
				new Dictionary<string, string>
				{
					{
						"root",
						root
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

		private List<int> GetListFromFile(int sizeOfList, ListStyles style)
		{
			Dictionary<string, string> paths = GetDirectoryPaths(sizeOfList);

			// Check if directories exist and if not create them.
			if (!Directory.Exists(paths["root"]))
			{
				Directory.CreateDirectory(paths["root"]);
			}

			if (!Directory.Exists(paths["lists"]))
			{
				Directory.CreateDirectory(paths["lists"]);
			}

			List<int> randomList, orderedList, reversedList;

			string randomPath = paths["randomListFile"];
			string orderedPath = paths["orderedListFile"];
			string reversedPath = paths["reversedListFile"];

			if (!File.Exists(randomPath))
			{
				int min = sizeOfList - (3 * sizeOfList);
				int max = 2 * sizeOfList;

				randomList = new List<int>();
				Random rand = new Random();

				for (int i = 0; i < sizeOfList; i++)
					randomList.Add(rand.Next(min, max));

				Stream stream = File.Open(randomPath, FileMode.Create);
				BinaryFormatter bin = new BinaryFormatter();
				bin.Serialize(stream, randomList);
				stream.Close();
			}
			else
			{
				Stream stream = File.Open(randomPath, FileMode.Open);
				BinaryFormatter bin = new BinaryFormatter();
				randomList = (List<int>)bin.Deserialize(stream);
				stream.Close();
			}

			if (!File.Exists(orderedPath))
			{
				orderedList = new List<int>(randomList);
				orderedList.Sort();

				Stream stream = File.Open(orderedPath, FileMode.Create);
				BinaryFormatter bin = new BinaryFormatter();
				bin.Serialize(stream, orderedList);
				stream.Close();
			}
			else
			{
				Stream stream = File.Open(orderedPath, FileMode.Open);
				BinaryFormatter bin = new BinaryFormatter();
				orderedList = (List<int>)bin.Deserialize(stream);
				stream.Close();
			}

			if (!File.Exists(reversedPath))
			{
				reversedList = new List<int>(orderedList);
				reversedList.Reverse();

				Stream stream = File.Open(reversedPath, FileMode.Create);
				BinaryFormatter bin = new BinaryFormatter();
				bin.Serialize(stream, reversedList);
				stream.Close();
			}
			else
			{
				Stream stream = File.Open(reversedPath, FileMode.Open);
				BinaryFormatter bin = new BinaryFormatter();
				reversedList = (List<int>)bin.Deserialize(stream);
				stream.Close();
			}

			if (style == ListStyles.Random) return randomList;
			if (style == ListStyles.Ordered) return orderedList;
			if (style == ListStyles.Reversed) return reversedList;

			return new List<int>();
		}

		private void Dispose(bool disposing)
		{
			if (this.disposed)
				return;

			if (disposing)
				instance = null;

			this.disposed = true;
		}
	}
}
