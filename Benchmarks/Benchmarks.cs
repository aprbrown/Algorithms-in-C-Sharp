// -----------------------------------------------------------------------------
// <copyright file="Benchmarks.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full
// license information.
// </copyright>
// -----------------------------------------------------------------------------

namespace Benchmarks
{
	using System;
	using System.Collections.Generic;

	/// <summary>
	/// A Class to facilitate the benchmarking of sorting algorithms.
	/// </summary>
	internal sealed class Benchmarks : IDisposable
	{
		private static readonly object SyncLock = new object();
		private static volatile Benchmarks instance = null;

		private List<int> randomList;
		private List<int> orderedList;
		private List<int> reversedList;

		private bool disposed = false;

		private Benchmarks()
		{
			this.GenerateLists(SizeOfList);
		}

		/// <summary>
		/// Finalizes an instance of the <see cref="Benchmarks"/> class.
		/// </summary>
		~Benchmarks() => this.Dispose(false);

		/// <summary>
		/// Gets the singleton instance of the <see cref="Benchmarks"/> class.
		/// </summary>
		public static Benchmarks Instance
		{
			get
			{
				if (instance == null)
				{
					lock (SyncLock)
					{
						if (instance == null) instance = new Benchmarks();
					}
				}

				return instance;
			}
		}

		/// <summary>
		/// Gets the size of the list for benchmarks to be ran against.
		/// </summary>
		internal static int SizeOfList { get; } = 250_000;

		/// <summary>
		/// Gets a copy of randomList.
		/// </summary>
		/// <returns>A List of random integers.</returns>
		public List<int> GetRandomList() => new List<int>(this.randomList);

		/// <summary>
		/// Gets a copy of orderedList.
		/// </summary>
		/// <returns>A List of ordered integers.</returns>
		public List<int> GetOrderedList() => new List<int>(this.orderedList);

		/// <summary>
		/// Gets a copy of reversedList.
		/// </summary>
		/// <returns>A List of reverse ordered integers.</returns>
		public List<int> GetReversedList() => new List<int>(this.reversedList);

		/// <summary>
		/// Generates a list of random integers, and lists of ordered and
		/// reverse ordered integers based on the values of the random list.
		/// </summary>
		/// <param name="sizeOfList">An integer determining the size of the
		/// lists to be generated.</param>
		public void GenerateLists(int sizeOfList)
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
