namespace Algorithms.Sorting
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;
	using Algorithms.Helpers;

	public static class TreeSorter
	{
		private static int index = 0;

		public static void TreeSort<T>(this IList<T> list)
			where T : IComparable<T>
		{
			if (list == null || list.Count < 2) return;

			if (list[0].CompareTo(list[list.Count / 2]) > 0)
				list.Swap(0, list.Count / 2);

			if (list[list.Count / 2].CompareTo(list[list.Count - 1]) > 0)
				list.Swap(list.Count / 2, list.Count - 1);

			if (list[0].CompareTo(list[list.Count / 2]) < 0)
				list.Swap(0, list.Count / 2);

			Node<T> treeRoot = new Node<T>() { Value = list[0] };

			for (int i = 1; i < list.Count; i++)
			{
				var currentNode = treeRoot;
				var newNode = new Node<T>() { Value = list[i] };

				while (true)
				{
					if (newNode.Value.CompareTo(currentNode.Value) <= 0)
					{
						if (currentNode.Left == null)
						{
							newNode.Parent = currentNode;
							currentNode.Left = newNode;
							break;
						}

						currentNode = currentNode.Left;
					}
					else
					{
						if (currentNode.Right == null)
						{
							newNode.Parent = currentNode;
							currentNode.Right = newNode;
							break;
						}

						currentNode = currentNode.Right;
					}
				}
			}

			TraverseAndAddToArray(treeRoot, list);
			index = 0;
		}

		private static void TraverseAndAddToArray<T>(
			Node<T> currentNode, IList<T> list)
			where T : IComparable<T>
		{
			if (currentNode == null) return;
			TraverseAndAddToArray(currentNode.Left, list);
			list[index] = currentNode.Value;
			index++;
			TraverseAndAddToArray(currentNode.Right, list);
		}

		private class Node<T> : IComparable<Node<T>>
			where T : IComparable<T>
		{
			public Node()
			{
				this.Value = default(T);
				this.Parent = null;
				this.Left = null;
				this.Right = null;
			}

			public T Value { get; set; }

			public Node<T> Parent { get;  set; }

			public Node<T> Left { get;  set; }

			public Node<T> Right { get;  set; }

			public int CompareTo([AllowNull] Node<T> other)
			{
				if (other == null) return -1;
				return this.Value.CompareTo(other.Value);
			}
		}
	}
}
