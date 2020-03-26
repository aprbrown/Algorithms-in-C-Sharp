namespace Algorithms.Sorting
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;

	public static class TreeSorter
	{
		private static int index = 0;

		public static void TreeSort<T>(this IList<T> List)
			where T : IComparable<T>
		{
			if (List == null || List.Count < 2) return;

			Node<T> treeRoot = new Node<T>() { Value = List[0] };

			for (int i = 1; i < List.Count; i++)
			{
				var currentNode = treeRoot;
				var newNode = new Node<T>() { Value = List[i] };

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

			TraverseAndAddToArray(treeRoot, List);
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
