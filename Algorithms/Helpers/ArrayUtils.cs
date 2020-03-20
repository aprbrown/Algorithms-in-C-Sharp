// -----------------------------------------------------------------------------
// <copyright file="ArrayUtils.cs" company="Andrew P R Brown">
// Copyright (c) Andrew P R Brown. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full
// license information.
// </copyright>
// -----------------------------------------------------------------------------

namespace Algorithms.Helpers
{
	using System;
	using System.Collections.Generic;

	/// <summary>
	/// A collection of helper methods for working with integer arrays.
	/// </summary>
	public static class ArrayUtils
	{
		/// <summary>
		/// Given an integer array and the indexes of two elements, the two
		/// elements are swapped in the array.
		/// </summary>
		/// <param name="array">Integer array for swap to occur in.</param>
		/// <param name="firstIndex">Index of first element to swap.</param>
		/// <param name="secondIndex">Index of second element to swap.</param>
		public static void Swap(
			this int[] array, int firstIndex, int secondIndex)
		{
			if (array == null || array.Length < 2)
			{
				return;
			}

			int temp = array[firstIndex];
			array[firstIndex] = array[secondIndex];
			array[secondIndex] = temp;
		}

		/// <summary>
		/// Creates a string representation of an integer array with square
		/// brackets and commas separating elements.
		/// </summary>
		/// <param name="arrayToPrint">Integer array to represent as a
		/// string.</param>
		/// <returns>String representation of array.</returns>
		public static string PrintArray(this int[] arrayToPrint)
		{
			if (arrayToPrint == null)
			{
				return "[]";
			}

			string array = "[";
			for (int i = 0; i < arrayToPrint.Length; i++)
			{
				if (i != arrayToPrint.Length - 1)
				{
					array += arrayToPrint[i];
					array += ", ";
				}
				else
				{
					array += arrayToPrint[i];
				}
			}

			array += "]";

			return array;
		}

		/// <summary>
		/// Create an integer array of a given length, the array is then
		/// populated with random values ranging from 1 to the given value. Not
		/// all numbers in the range are guaranteed to be included and
		/// duplicates can occur.
		/// </summary>
		/// <param name="sizeOfArray">Integer representing the size of the array
		/// and upper bound of values to include in the array.</param>
		/// <returns>A randomly populated integer array.</returns>
		public static int[] RandomisedArray(int sizeOfArray)
		{
			int[] randomIntArray = new int[sizeOfArray];
			var rand = new Random();
			for (int i = 0; i < sizeOfArray; i++)
			{
				randomIntArray[i] = rand.Next(sizeOfArray) + 1;
			}

			return randomIntArray;
		}

		/// <summary>
		/// Creates an integer array of a given length, the array is then
		/// populated with values ranging from 1 to the given value in numerical
		/// order.
		/// </summary>
		/// <param name="sizeOfArray">Integer representing the size of the array
		/// and upper bound of values to include in the array.</param>
		/// <returns>An integer array populated with numbers in order lowest to
		/// highest.</returns>
		public static int[] FillOrderedArray(int sizeOfArray)
		{
			int[] orderedArray = new int[sizeOfArray];
			for (int i = 0; i < sizeOfArray; i++)
			{
				orderedArray[i] = i + 1;
			}

			return orderedArray;
		}

		/// <summary>
		/// Creates an integer array of a given length, the array is then
		/// populated with values ranging from 1 to the given value in reverse
		/// numerical order.
		/// </summary>
		/// <param name="sizeOfArray">Integer representing the size of the array
		/// and upper bound of values to include in the array.</param>
		/// <returns>An integer array populated with numbers in order highest to
		/// lowest.</returns>
		public static int[] FillReverseOrderedArray(int sizeOfArray)
		{
			int[] reversedArray = new int[sizeOfArray];
			int value = sizeOfArray;
			for (int i = 0; i < sizeOfArray; i++)
			{
				reversedArray[i] = value;
				value--;
			}

			return reversedArray;
		}

		/// <summary>
		/// Given an array, make a copy of the array and its values.
		/// </summary>
		/// <param name="arrayToCopy">An integer array to be copied.</param>
		/// <returns>A new integer array containing the same values as the one
		/// provided to the method.</returns>
		public static int[] CopyFullArray(int[] arrayToCopy)
		{
			if (arrayToCopy == null)
			{
				return Array.Empty<int>();
			}

			int[] array = new int[arrayToCopy.Length];
			Array.Copy(arrayToCopy, array, arrayToCopy.Length);
			return array;
		}
	}
}
