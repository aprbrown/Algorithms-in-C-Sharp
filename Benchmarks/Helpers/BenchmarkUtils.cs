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

	internal static class BenchmarkUtils
	{
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
