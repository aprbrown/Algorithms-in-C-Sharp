namespace Algorithms.Sorting
{
	public static class TreeSorter
	{
		private static int index = 0;

		public static void TreeSort(this int[] array)
		{
			if (array == null || array.Length < 2) return;

			Node treeRoot = new Node() { Value = array[0] };

			for (int i = 1; i < array.Length; i++)
			{
				var currentNode = treeRoot;
				var newNode = new Node() { Value = array[i] };

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

			TraverseAndAddToArray(treeRoot, array);
			index = 0;
		}

		private static void TraverseAndAddToArray(Node currentNode, int[] array)
		{
			if (currentNode == null) return;
			TraverseAndAddToArray(currentNode.Left, array);
			array[index] = currentNode.Value;
			index++;
			TraverseAndAddToArray(currentNode.Right, array);
		}

		private class Node
		{
			public Node()
			{
				this.Value = default(int);
				this.Parent = null;
				this.Left = null;
				this.Right = null;
			}

			public int Value { get; set; }

			public Node Parent { get;  set; }

			public Node Left { get;  set; }

			public Node Right { get;  set; }
		}
	}
}
