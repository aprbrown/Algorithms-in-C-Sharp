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
		private const int SizeOfList1 = 25;
		private const int SizeOfList2 = 50;
		private const int SizeOfList3 = 100;

		private static readonly int[] ListSizes =
		{
			SizeOfList1, SizeOfList2, SizeOfList3,
		};

		private static readonly object SyncLock = new object();
		private static readonly Dictionary<string, string> Paths =
			GetDirectoryPaths();

		private static volatile SortingTests instance = null;

		private bool disposed = false;

		private List<int> randomList1;
		private List<int> orderedList1;
		private List<int> reversedList1;
		private List<int> randomList2;
		private List<int> orderedList2;
		private List<int> reversedList2;
		private List<int> randomList3;
		private List<int> orderedList3;
		private List<int> reversedList3;

		private SortingTests()
		{
			this.GenerateDirectories();
			this.PopulateLists();
		}

		/// <summary>
		/// Finalizes an instance of the <see cref="SortingTests"/> class.
		/// </summary>
		~SortingTests()
		{
			this.Dispose(false);
		}

		/// <summary>
		/// Gets a singleton instance of SortingTests.
		/// </summary>
		public static SortingTests Instance
		{
			get
			{
				if (instance == null)
				{
					lock (SyncLock)
					{
						if (instance == null)
							instance = new SortingTests();
					}
				}

				return instance;
			}
		}

		/// <summary>
		/// Gets a list of random integers according to <value>SizeOfList1</value>.
		/// </summary>
		public List<int> GetRandomList1() => new List<int>(this.randomList1);

		/// <summary>
		/// Gets a list of ordered integers according to <value>SizeOfList1</value>.
		/// </summary>
		public List<int> GetOrderedList1() => new List<int>(this.orderedList1);

		/// <summary>
		/// Gets a list of reverse ordered integers according to <value>SizeOfList1</value>.
		/// </summary>
		public List<int> GetReversedList1() => new List<int>(this.reversedList1);

		/// <summary>
		/// Gets a list of random integers according to <value>SizeOfList2</value>.
		/// </summary>
		public List<int> GetRandomList2() => new List<int>(this.randomList2);

		/// <summary>
		/// Gets a list of ordered integers according to <value>SizeOfList2</value>.
		/// </summary>
		public List<int> GetOrderedList2() => new List<int>(this.orderedList2);

		/// <summary>
		/// Gets a list of reverse ordered integers according to <value>SizeOfList2</value>.
		/// </summary>
		public List<int> GetReversedList2() => new List<int>(this.reversedList2);

		/// <summary>
		/// Gets a list of random integers according to <value>SizeOfList3</value>.
		/// </summary>
		public List<int> GetRandomList3() => new List<int>(this.randomList3);

		/// <summary>
		/// Gets a list of ordered integers according to <value>SizeOfList3</value>.
		/// </summary>
		public List<int> GetOrderedList3() => new List<int>(this.orderedList3);

		/// <summary>
		/// Gets a list of reverse ordered integers according to <value>SizeOfList3</value>.
		/// </summary>
		public List<int> GetReversedList3() => new List<int>(this.reversedList3);

		/// <inheritdoc/>
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		private static Dictionary<string, string> GetDirectoryPaths()
		{
			string root = Environment.GetFolderPath(
				Environment.SpecialFolder.Personal) +
				$@"\Algorithms-In-C-Sharp-Generated-Files";

			string lists = $@"{root}\Lists\";

			Dictionary<string, string> paths = new Dictionary<string, string>
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
					$"randomListFile{SizeOfList1}",
					$@"{lists}\{SizeOfList1}_random.bin"
				},
				{
					$"orderedListFile{SizeOfList1}",
					$@"{lists}\{SizeOfList1}_ordered.bin"
				},
				{
					$"reversedListFile{SizeOfList1}",
					$@"{lists}\{SizeOfList1}_reversed.bin"
				},
				{
					$"randomListFile{SizeOfList2}",
					$@"{lists}\{SizeOfList2}_random.bin"
				},
				{
					$"orderedListFile{SizeOfList2}",
					$@"{lists}\{SizeOfList2}_ordered.bin"
				},
				{
					$"reversedListFile{SizeOfList2}",
					$@"{lists}\{SizeOfList2}_reversed.bin"
				},
				{
					$"randomListFile{SizeOfList3}",
					$@"{lists}\{SizeOfList3}_random.bin"
				},
				{
					$"orderedListFile{SizeOfList3}",
					$@"{lists}\{SizeOfList3}_ordered.bin"
				},
				{
					$"reversedListFile{SizeOfList3}",
					$@"{lists}\{SizeOfList3}_reversed.bin"
				},
			};

			return paths;
		}

		private void GenerateDirectories()
		{
			// Check if directories exist and if not create them.
			if (!Directory.Exists(Paths["root"]))
			{
				Directory.CreateDirectory(Paths["root"]);
			}

			if (!Directory.Exists(Paths["lists"]))
			{
				Directory.CreateDirectory(Paths["lists"]);
			}
		}

		private void PopulateLists()
		{
			string randomPath1 = Paths[$"randomListFile{SizeOfList1}"];
			string orderedPath1 = Paths[$"orderedListFile{SizeOfList1}"];
			string reversedPath1 = Paths[$"reversedListFile{SizeOfList1}"];

			string randomPath2 = Paths[$"randomListFile{SizeOfList2}"];
			string orderedPath2 = Paths[$"orderedListFile{SizeOfList2}"];
			string reversedPath2 = Paths[$"reversedListFile{SizeOfList2}"];

			string randomPath3 = Paths[$"randomListFile{SizeOfList3}"];
			string orderedPath3 = Paths[$"orderedListFile{SizeOfList3}"];
			string reversedPath3 = Paths[$"reversedListFile{SizeOfList3}"];

			// XOR check to see if any files are missing. If one or two files of
			// the required three are missing, then the remaining files are
			// removed.
			if (!File.Exists(randomPath1) ^ !File.Exists(orderedPath1) ^ !File.Exists(reversedPath1) ^
				!File.Exists(randomPath2) ^ !File.Exists(orderedPath2) ^ !File.Exists(reversedPath2) ^
				!File.Exists(randomPath3) ^ !File.Exists(orderedPath3) ^ !File.Exists(reversedPath3))
			{
				if (File.Exists(randomPath1)) File.Delete(randomPath1);
				if (File.Exists(orderedPath1)) File.Delete(orderedPath1);
				if (File.Exists(reversedPath1)) File.Delete(reversedPath1);
				if (File.Exists(randomPath2)) File.Delete(randomPath2);
				if (File.Exists(orderedPath2)) File.Delete(orderedPath2);
				if (File.Exists(reversedPath2)) File.Delete(reversedPath2);
				if (File.Exists(randomPath3)) File.Delete(randomPath3);
				if (File.Exists(orderedPath3)) File.Delete(orderedPath3);
				if (File.Exists(reversedPath3)) File.Delete(reversedPath3);
			}

			// Checks if one file exists, due to previous check if one exists,
			// all other files do too.
			if (!File.Exists(randomPath1))
			{
				this.randomList1 = new List<int>();
				this.randomList2 = new List<int>();
				this.randomList3 = new List<int>();

				foreach (int size in ListSizes)
				{
					List<int> listToFill = new List<int>();
					switch (size)
					{
						case SizeOfList1:
							listToFill = this.randomList1;
							break;
						case SizeOfList2:
							listToFill = this.randomList2;
							break;
						case SizeOfList3:
							listToFill = this.randomList3;
							break;
					}

					for (int i = 0; i < size; i++)
					{
						int min = size - (3 * size);
						int max = 2 * size;

						Random rand = new Random();
						listToFill.Add(rand.Next(min, max));
					}
				}

				this.orderedList1 = new List<int>(this.randomList1);
				this.orderedList1.Sort();

				this.orderedList2 = new List<int>(this.randomList2);
				this.orderedList2.Sort();

				this.orderedList3 = new List<int>(this.randomList3);
				this.orderedList3.Sort();

				this.reversedList1 = new List<int>(this.orderedList1);
				this.reversedList1.Reverse();

				this.reversedList2 = new List<int>(this.orderedList2);
				this.reversedList2.Reverse();

				this.reversedList3 = new List<int>(this.orderedList3);
				this.reversedList3.Reverse();

				BinaryFormatter bin = new BinaryFormatter();
				Stream stream;

				stream = File.Open(randomPath1, FileMode.Create);
				bin.Serialize(stream, this.randomList1);
				stream.Dispose();

				stream = File.Open(randomPath2, FileMode.Create);
				bin.Serialize(stream, this.randomList2);
				stream.Dispose();

				stream = File.Open(randomPath3, FileMode.Create);
				bin.Serialize(stream, this.randomList3);
				stream.Dispose();

				stream = File.Open(orderedPath1, FileMode.Create);
				bin.Serialize(stream, this.orderedList1);
				stream.Dispose();

				stream = File.Open(orderedPath2, FileMode.Create);
				bin.Serialize(stream, this.orderedList2);
				stream.Dispose();

				stream = File.Open(orderedPath3, FileMode.Create);
				bin.Serialize(stream, this.orderedList3);
				stream.Dispose();

				stream = File.Open(reversedPath1, FileMode.Create);
				bin.Serialize(stream, this.reversedList1);
				stream.Dispose();

				stream = File.Open(reversedPath2, FileMode.Create);
				bin.Serialize(stream, this.reversedList2);
				stream.Dispose();

				stream = File.Open(reversedPath3, FileMode.Create);
				bin.Serialize(stream, this.reversedList3);
				stream.Close();
			}
			else
			{
				BinaryFormatter bin = new BinaryFormatter();
				Stream stream;

				stream = File.Open(randomPath1, FileMode.Open);
				this.randomList1 = (List<int>)bin.Deserialize(stream);
				stream.Dispose();

				stream = File.Open(randomPath2, FileMode.Open);
				this.randomList2 = (List<int>)bin.Deserialize(stream);
				stream.Dispose();

				stream = File.Open(randomPath3, FileMode.Open);
				this.randomList3 = (List<int>)bin.Deserialize(stream);
				stream.Dispose();

				stream = File.Open(orderedPath1, FileMode.Open);
				this.orderedList1 = (List<int>)bin.Deserialize(stream);
				stream.Dispose();

				stream = File.Open(orderedPath2, FileMode.Open);
				this.orderedList2 = (List<int>)bin.Deserialize(stream);
				stream.Dispose();

				stream = File.Open(orderedPath3, FileMode.Open);
				this.orderedList3 = (List<int>)bin.Deserialize(stream);
				stream.Dispose();

				stream = File.Open(reversedPath1, FileMode.Open);
				this.reversedList1 = (List<int>)bin.Deserialize(stream);
				stream.Dispose();

				stream = File.Open(reversedPath2, FileMode.Open);
				this.reversedList2 = (List<int>)bin.Deserialize(stream);
				stream.Dispose();

				stream = File.Open(reversedPath3, FileMode.Open);
				this.reversedList3 = (List<int>)bin.Deserialize(stream);

				stream.Close();
			}
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
