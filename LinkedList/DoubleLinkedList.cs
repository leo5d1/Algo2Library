using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;
using System.Globalization;
using System.Xml.Serialization;

namespace LinkList
{
	public class DoubleLinkedList : iLinkedList
	{
		public int amount = 0;

		public void Add<T>(T value)
		{
			int currentIndex = 0;

			if(DoubleLinkedList<T>.head_Node == null)
			{
				DoubleLinkedNode<T> newHeadNode = new DoubleLinkedNode<T>();
				newHeadNode.value = value;
				newHeadNode.index = currentIndex;
				DoubleLinkedList<T>.head_Node = newHeadNode;
				DoubleLinkedList<T>.tail_Node = newHeadNode;

				currentIndex++;
			}
			else
			{
				DoubleLinkedNode<T> newNode = new DoubleLinkedNode<T>();
				newNode.value = value;
				newNode.index = currentIndex;
				newNode.prev_Node = DoubleLinkedList<T>.head_Node;

				DoubleLinkedList<T>.head_Node.next_Node = newNode;

				DoubleLinkedList<T>.head_Node = newNode;
			}

			amount++;
		}

		public void Clear<T>()
		{
			bool cleared = false;

			while(!cleared)
			{
				DoubleLinkedNode<T> nextToDelete = DoubleLinkedList<T>.head_Node.prev_Node;
				DoubleLinkedList<T>.head_Node = null;
				amount--;

				if (nextToDelete != null)
				{
					DoubleLinkedList<T>.head_Node = nextToDelete;
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
			DoubleLinkedNode<T> currentNode = DoubleLinkedList<T>.head_Node;

			while (!found)
			{
				if(currentNode.index == index)
				{
					found = true;
				}
				else
				{
					currentNode = currentNode.prev_Node;
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
			DoubleLinkedNode<T> newNode = new DoubleLinkedNode<T>();
			newNode.value = value;
			newNode.index = index;

			// finds the node currently at the index
			bool found = false;
			DoubleLinkedNode<T> currentNode = DoubleLinkedList<T>.head_Node;
			while (!found)
			{
				if (currentNode.index == index)
				{
					found = true;
				}
				else
				{
					currentNode = currentNode.prev_Node;
				}
			}

			// loops through the List and updates the indexes
			currentNode.prev_Node.next_Node = newNode;
			newNode.next_Node = currentNode;

			bool indexUpdated = false;
			DoubleLinkedNode<T> nodeToBeUpdated = currentNode;
			while (!indexUpdated)
			{
				nodeToBeUpdated.index++;

				if(nodeToBeUpdated.next_Node == null)
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
			DoubleLinkedNode<T> nodeToBeUpdated = DoubleLinkedList<T>.head_Node;
			if (nodeToBeUpdated != null)
			{
				DoubleLinkedList<T>.tail_Node = null;
				amount--;
			}
			else
			{
				indexUpdated = true;
			}

			while (!indexUpdated)
			{
				nodeToBeUpdated.index--;

				if (nodeToBeUpdated.prev_Node == null)
				{
					DoubleLinkedList<T>.tail_Node = nodeToBeUpdated;
					indexUpdated = true;
				}
				else
				{
					nodeToBeUpdated = nodeToBeUpdated.prev_Node;
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
			DoubleLinkedNode<T> currentNode = DoubleLinkedList<T>.head_Node;

			while (!found)
			{
				if (currentNode.index == index)
				{
					found = true;
				}
				else
				{
					currentNode = currentNode.prev_Node;
				}
			}

			int indexToStopAt = currentNode.index;
			currentNode = null;

			// loops through the List and updates the indexes
			bool indexUpdated = false;
			DoubleLinkedNode<T> nodeToBeUpdated = DoubleLinkedList<T>.head_Node;
			while (!indexUpdated)
			{
				nodeToBeUpdated.index--;

				if (nodeToBeUpdated.prev_Node == null || nodeToBeUpdated.index < indexToStopAt)
				{
					indexUpdated = true;
				}
				else
				{
					nodeToBeUpdated = nodeToBeUpdated.prev_Node;
				}
			}
		}

		public T RemoveLast<T>()
		{
			amount--;

			DoubleLinkedNode<T> newHeadNode = DoubleLinkedList<T>.head_Node.prev_Node;
			DoubleLinkedList<T>.head_Node = null;
			DoubleLinkedList<T>.head_Node = newHeadNode;

			return DoubleLinkedList<T>.head_Node.value;
		}

		public int Search<T>(T value)
		{
			bool found = false;
			DoubleLinkedNode<T> currentNode = DoubleLinkedList<T>.head_Node;

			while (!found)
			{
				if (EqualityComparer<T>.Default.Equals(currentNode.value, value))
				{
					found = true;
					return currentNode.index;
				}
				else
				{
					currentNode = currentNode.prev_Node;
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
			
			DoubleLinkedNode<T> currentNode = DoubleLinkedList<T>.tail_Node;

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
