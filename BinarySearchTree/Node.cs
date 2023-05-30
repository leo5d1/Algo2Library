using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
	internal static class BinarySearchTree<T>
	{
		public static Comparer<T> comparer = Comparer<T>.Default;
		public static Node<T>? root_Node;
	}

	internal class Node<T>
	{
		public T? value;
		public int height;

		public Node<T>? parentNode;

		public Node<T>? leftNode;
		public Node<T>? rightNode;
	}


}
