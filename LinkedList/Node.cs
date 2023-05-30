using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkList
{
	internal static class DoubleLinkedList<T>
	{
		public static DoubleLinkedNode<T>? head_Node;
		public static DoubleLinkedNode<T>? tail_Node;
	}

	internal static class SingleLinkedList<T>
	{
		public static SingleLinkedNode<T>? head_Node;
		public static SingleLinkedNode<T>? tail_Node;
	}


	internal class DoubleLinkedNode<T>
	{
		public T? value;
		public int index;

		public DoubleLinkedNode<T>? next_Node;
		public DoubleLinkedNode<T>? prev_Node;
	}

	internal class SingleLinkedNode<T>
	{
		public T? value;
		public int index;

		public SingleLinkedNode<T>? next_Node;
	}
}
