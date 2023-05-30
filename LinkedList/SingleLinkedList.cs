using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkList
{
	public class SingleLinkedList : iLinkedList
	{
		public int amount = 0;

		public void Add<T>(T value)
		{
			int currentIndex = 0;

			if (SingleLinkedList<T>.head_Node == null)
			{
				SingleLinkedNode<T> newHeadNode = new SingleLinkedNode<T>();
				newHeadNode.value = value;
				newHeadNode.index = currentIndex;
				SingleLinkedList<T>.head_Node = newHeadNode;
				SingleLinkedList<T>.tail_Node = newHeadNode;

				currentIndex++;
			}
			else
			{
				SingleLinkedNode<T> newNode = new SingleLinkedNode<T>();
				newNode.value = value;
				newNode.index = currentIndex;

				SingleLinkedList<T>.head_Node.next_Node = newNode;

				SingleLinkedList<T>.head_Node = newNode;
			}

			amount++;
		}

		public void Clear<T>()
		{
			bool cleared = false;

			while (!cleared)
			{
				SingleLinkedNode<T> nextToDelete = SingleLinkedList<T>.tail_Node.next_Node;
				SingleLinkedList<T>.tail_Node = null;
				amount--;

				if (nextToDelete != null)
				{
					SingleLinkedList<T>.tail_Node = nextToDelete;
				}
				else
				{
					cleared = true;
				}
			}
		}

		public int Count()
		{
			return amount;
		}

		public T Get<T>(int index)
		{
			if (index < 0 || index >= Count())
			{
				throw new IndexOutOfRangeException();
			}

			bool found = false;
			SingleLinkedNode<T> currentNode = SingleLinkedList<T>.tail_Node;

			while (!found)
			{
				if (currentNode.index == index)
				{
					found = true;
				}
				else
				{
					currentNode = currentNode.next_Node;
				}
			}
			return currentNode.value;
		}

		public void Insert<T>(T value, int index)
		{
			if (index < 0 || index >= Count())
			{
				throw new IndexOutOfRangeException();
			}

			amount++;

			// new node to be inserted
			SingleLinkedNode<T> newNode = new SingleLinkedNode<T>();
			newNode.value = value;
			newNode.index = index;

			// finds the node currently at the index
			bool found = false;
			SingleLinkedNode<T>? currentNode = SingleLinkedList<T>.tail_Node;
			SingleLinkedNode<T>? prevNode = SingleLinkedList<T>.tail_Node;
			while (!found)
			{
				if (currentNode?.index == index)
				{
					found = true;
				}
				else
				{
					prevNode = currentNode;
					currentNode = currentNode?.next_Node;
				}
			}

			// loops through the List and updates the indexes
			prevNode.next_Node = newNode;
			newNode.next_Node = currentNode;

			bool indexUpdated = false;
			SingleLinkedNode<T>? nodeToBeUpdated = currentNode;
			while (!indexUpdated)
			{
				nodeToBeUpdated.index++;

				if (nodeToBeUpdated.next_Node == null)
				{
					indexUpdated = true;
				}
				else
				{
					nodeToBeUpdated = nodeToBeUpdated.next_Node;
				}
			}

		}

		public void Remove<T>()
		{
			// loops through the List and updates the indexes
			bool indexUpdated = false;
			SingleLinkedNode<T> nodeToBeUpdated = SingleLinkedList<T>.tail_Node.next_Node;
			if (nodeToBeUpdated != null)
			{
				SingleLinkedList<T>.tail_Node = null;
				amount--;
			}
			else
			{
				indexUpdated = true;
			}

			while (!indexUpdated)
			{
				nodeToBeUpdated.index--;

				if (nodeToBeUpdated.next_Node == null)
				{
					SingleLinkedList<T>.tail_Node = nodeToBeUpdated;
					indexUpdated = true;
				}
				else
				{
					nodeToBeUpdated = nodeToBeUpdated.next_Node;
				}
			}
		}

		public void RemoveAt<T>(int index)
		{
			if (index < 0 || index >= Count())
			{
				throw new IndexOutOfRangeException();
			}

			amount--;

			bool found = false;
			SingleLinkedNode<T> currentNode = SingleLinkedList<T>.tail_Node;

			while (!found)
			{
				if (currentNode.index == index)
				{
					found = true;
				}
				else
				{
					currentNode = currentNode.next_Node;
				}
			}

			int indexToStopAt = currentNode.index;
			currentNode = null;

			// loops through the List and updates the indexes
			bool indexUpdated = false;
			SingleLinkedNode<T> nodeToBeUpdated = SingleLinkedList<T>.tail_Node;
			while (!indexUpdated)
			{
				nodeToBeUpdated.index--;

				if (nodeToBeUpdated.next_Node == null || nodeToBeUpdated.index < indexToStopAt)
				{
					indexUpdated = true;
				}
				else
				{
					nodeToBeUpdated = nodeToBeUpdated.next_Node;
				}
			}
		}

		public T RemoveLast<T>()
		{
			amount--;

			SingleLinkedNode<T> newHeadNode = SingleLinkedList<T>.tail_Node;

			if (newHeadNode.index != Count())
			{
				newHeadNode = newHeadNode.next_Node;
			}

			SingleLinkedList<T>.head_Node = null;
			SingleLinkedList<T>.head_Node = newHeadNode;

			return SingleLinkedList<T>.head_Node.value;
		}

		public int Search<T>(T value)
		{
			bool found = false;
			SingleLinkedNode<T> currentNode = SingleLinkedList<T>.tail_Node;

			while (!found)
			{
				if (EqualityComparer<T>.Default.Equals(currentNode.value, value))
				{
					found = true;
					return currentNode.index;
				}
				else
				{
					currentNode = currentNode.next_Node;
				}

				if (currentNode == null)
				{
					return -1;
				}
			}

			return -1;
		}

		string iLinkedList.ToString<T>()
		{
			string returnString = "";

			SingleLinkedNode<T> currentNode = SingleLinkedList<T>.tail_Node;

			bool finished = false;
			while (!finished)
			{
				if (currentNode == null)
				{
					return returnString;
				}

				if (currentNode.index != Count())
				{
					returnString += currentNode.value + ", ";
					currentNode = currentNode.next_Node;
				}
				else
				{
					returnString += currentNode.value;
					finished = true;
				}
			}

			return returnString;
		}
	}
}
