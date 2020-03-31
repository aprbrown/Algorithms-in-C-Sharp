// -----------------------------------------------------------------------------
// <copyright file="Benchmarks.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full
// license information.
// </copyright>
// -----------------------------------------------------------------------------

namespace Benchmarks.Helpers
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Runtime.Serialization.Formatters.Binary;

	internal sealed class Benchmarks : IDisposable
	{
		internal static int SizeOfList { get; set; } = 2000;

		private static readonly object SyncLock = new object();
		private static readonly Dictionary<string, string> Paths =
			new Dictionary<string, string>
		{
			{
				"randomListFile",
				Environment.GetFolderPath(
				Environment.SpecialFolder.Personal) +
				$@"\Algorithms-In-C-Sharp-Generated-Files\Lists\{SizeOfList}_random.bin"
			},
			{
				"orderedListFile",
				Environment.GetFolderPath(
				Environment.SpecialFolder.Personal) +
				$@"\Algorithms-In-C-Sharp-Generated-Files\Lists\{SizeOfList}_ordered.bin"
			},
			{
				"reversedListFile",
				Environment.GetFolderPath(
				Environment.SpecialFolder.Personal) +
				$@"\Algorithms-In-C-Sharp-Generated-Files\Lists\{SizeOfList}_reversed.bin"
			},
		};

		private static volatile Benchmarks instance = null;

		private List<int> randomList;
		private List<int> orderedList;
		private List<int> reversedList;

		private bool disposed = false;

		private Benchmarks()
		{
			this.GenerateLists(SizeOfList);
		}

		~Benchmarks() => this.Dispose(false);

		public static Benchmarks Instance
		{
			get
			{
				if (instance == null)
				{
					lock (SyncLock)
					{
						if (instance == null)
						{
							instance = new Benchmarks();
						}
					}
				}

				return instance;
			}
		}

		public List<int> GetRandomList() => new List<int>(this.randomList);

		public List<int> GetOrderedList() => new List<int>(this.orderedList);

		public List<int> GetReversedList() => new List<int>(this.reversedList);

		public void GenerateLists(int sizeOfList)
		{
			string randomPath = Paths["randomListFile"];
			string orderedPath = Paths["orderedListFile"];
			string reversedPath = Paths["reversedListFile"];

			// XOR check to see if any files are missing. If one or two files of
			// the required three are missing, then the remaining files are
			// removed.
			if (!File.Exists(randomPath) ^ !File.Exists(orderedPath) ^ !File.Exists(reversedPath))
			{
				if (File.Exists(randomPath)) File.Delete(randomPath);
				if (File.Exists(orderedPath)) File.Delete(orderedPath);
				if (File.Exists(reversedPath)) File.Delete(reversedPath);
			}

			// AND check to see if all files are missing. If no files are
			// present then they are created. If they are present, the contents
			// are loaded from file.
			if (!File.Exists(randomPath) && !File.Exists(orderedPath) && !File.Exists(reversedPath))
			{
				int min = sizeOfList - (3 * sizeOfList);
				int max = 2 * sizeOfList;

				this.randomList = new List<int>();
				Random rand = new Random();

				for (int i = 0; i < sizeOfList; i++)
					this.randomList.Add(rand.Next(min, max));

				this.orderedList = new List<int>(this.randomList);
				this.orderedList.Sort();
				this.reversedList = new List<int>(this.orderedList);
				this.reversedList.Reverse();

				BinaryFormatter bin = new BinaryFormatter();

				Stream stream = File.Open(randomPath, FileMode.Create);
				bin.Serialize(stream, this.randomList);
				stream.Dispose();

				stream = File.Open(orderedPath, FileMode.Create);
				bin.Serialize(stream, this.orderedList);
				stream.Dispose();

				stream = File.Open(reversedPath, FileMode.Create);
				bin.Serialize(stream, this.reversedList);

				stream.Close();
			}
			else if (File.Exists(randomPath) && File.Exists(orderedPath) && File.Exists(reversedPath))
			{
				BinaryFormatter bin = new BinaryFormatter();

				Stream stream = File.Open(randomPath, FileMode.Open);
				this.randomList = (List<int>)bin.Deserialize(stream);
				stream.Dispose();

				stream = File.Open(orderedPath, FileMode.Open);
				this.orderedList = (List<int>)bin.Deserialize(stream);
				stream.Dispose();

				stream = File.Open(reversedPath, FileMode.Open);
				this.reversedList = (List<int>)bin.Deserialize(stream);

				stream.Close();
			}
		}

		/// <inheritdoc/>
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
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
