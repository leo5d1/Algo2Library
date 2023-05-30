using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
	internal class BinarySearchTree : iBST
	{
		int amount = 0;
		int currentHeight = 1;

		public void Add<T>(T value)
		{
			if(BinarySearchTree<T>.root_Node == null)
			{
				Node<T> newNode = new Node<T>();
				newNode.value = value;
				newNode.height = currentHeight;

				amount++;
				currentHeight++;

				BinarySearchTree<T>.root_Node = newNode;
			}
			else
			{
				Node<T> currentNode = BinarySearchTree<T>.root_Node;

				if(BinarySearchTree<T>.comparer.Compare(currentNode.value, value) > 0)
				{
					
					bool placed = false;
					while (!placed)
					{
						if (currentNode.rightNode == null)
						{
							amount++;
							Node<T> newNode = new Node<T>();
							newNode.value = value;
							newNode.height = currentHeight;

							currentHeight++;

							placed = true;

							currentNode.rightNode = newNode;
						}
						else
						{
							currentNode = currentNode.rightNode;
						}
					}
				}
				else
				{
					bool placed = false;
					while (!placed)
					{
						if (currentNode.leftNode == null)
						{
							amount++;
							Node<T> newNode = new Node<T>();
							newNode.value = value;

							placed = true;

							currentNode.leftNode = newNode;
						}
						else
						{
							currentNode = currentNode.leftNode;
						}
					}
				}
			}
		}

		public void Clear<T>()
		{
			BinarySearchTree<T>.root_Node = null;
			amount = 0;
		}

		public bool Contains<T>(T value)
		{
			bool found = false;
			Node<T> currentNode = BinarySearchTree<T>.root_Node;
			while (!found)
			{

				if (currentNode == null)
				{
					return false;
				}

				if (BinarySearchTree<T>.comparer.Compare(currentNode.value, value) == 0)
				{
					return true;
				}
				else if (BinarySearchTree<T>.comparer.Compare(currentNode.value, value) > 0)
				{
					currentNode = currentNode.rightNode;
				}
				else
				{
					currentNode = currentNode.leftNode;
				}
			}

			return false;
		}

		public int Count()
		{
			return amount;
		}

		public int Height<T>()
		{if(BinarySearchTree<T>.root_Node == null)
			{
				return 0;
			}
			else if (BinarySearchTree<T>.root_Node.leftNode == null && BinarySearchTree<T>.root_Node.rightNode == null)
			{
				return 1;
			}

			int height = 1;

			Node<T> currentNode = BinarySearchTree<T>.root_Node;
			bool maxHeight = false;
			while (!maxHeight)
			{
				if (currentNode.rightNode != null) 
				{
					height++;
					currentNode = currentNode.rightNode;
				}
				else if (currentNode.leftNode != null)
				{
					height++;
					currentNode = currentNode.leftNode;
				}
			}
			return height;
		}

		public string InOrder<T>()
		{
			string returnString = "";

			Node<T> currentNode = BinarySearchTree<T>.root_Node;
			Node<T> prevNode = new Node<T>();

			bool finished = false;
			while (!finished)
			{
				if (currentNode == null || prevNode == null)
				{
					return returnString;
				}

				if (currentNode.leftNode == null && currentNode.rightNode == null)
				{
					returnString += currentNode.value + ", ";
					currentNode = prevNode;
				}
				else if (currentNode.leftNode != null)
				{
					prevNode = currentNode;
					currentNode = currentNode.leftNode;
				}
				else
				{
					returnString += currentNode.value;
					finished = true;
				}
			}

			return returnString;
		}

		public string PostOrder<T>()
		{
			string returnString = "";

			Node<T> currentNode = BinarySearchTree<T>.root_Node;
			Node<T> prevNode = new Node<T>();

			bool finished = false;
			while (!finished)
			{
				if (currentNode == null || prevNode == null)
				{
					return returnString;
				}

				returnString += currentNode.value + ", ";

				if (currentNode.leftNode != null)
				{
					prevNode = currentNode;
					currentNode = currentNode.leftNode;
				}
				else if ( currentNode.rightNode != null)
				{
					prevNode = currentNode;
					currentNode = currentNode.rightNode;
				}
				else if ( currentNode.leftNode == null && currentNode.rightNode == null)
				{
					currentNode = prevNode;
				}
			}

			return returnString;
		}

		public string PreOrder<T>()
		{
			string returnString = "";

			Node<T> currentNode = BinarySearchTree<T>.root_Node;
			Node<T> prevNode = new Node<T>();

			bool finished = false;
			while (!finished)
			{
				if (currentNode == null || prevNode == null)
				{
					return returnString;
				}

				returnString += currentNode.value + ", ";

				if (currentNode.leftNode != null)
				{
					prevNode = currentNode;
					currentNode = currentNode.leftNode;
				}
				else if (currentNode.rightNode != null)
				{
					prevNode = currentNode;
					currentNode = currentNode.rightNode;
				}
				else if (currentNode.leftNode == null && currentNode.rightNode == null)
				{
					currentNode = prevNode;
				}
			}

			return returnString;
		}

		public void Remove<T>(T value)
		{
			bool found = false;
			Node<T> currentNode = BinarySearchTree<T>.root_Node;
			while (!found)
			{
				if (BinarySearchTree<T>.comparer.Compare(currentNode.value, value) == 0)
				{
					Node<T> tempNode = currentNode.rightNode;
					tempNode.leftNode = currentNode.leftNode;
					currentNode = null;
					currentNode = tempNode;
					amount--;
				}
				else if (BinarySearchTree<T>.comparer.Compare(currentNode.value, value) > 0)
				{
					currentNode = currentNode.rightNode;
				}
				else
				{
					currentNode = currentNode.leftNode;
				}
			}			
		}

		public T[] ToArray<T>()
		{
			T[] array = new T[Count()];

			Node<T> currentNode = BinarySearchTree<T>.root_Node;
			Node<T> prevNode = new Node<T>();

			bool finished = false;
			while (!finished)
			{
				if (currentNode == null)
				{
					return array;
				}

				if (currentNode.leftNode == null && currentNode.rightNode == null)
				{
					array[1] = currentNode.value;
					currentNode = prevNode;
				}
				else if (currentNode.leftNode != null)
				{
					prevNode = currentNode;
					currentNode = currentNode.leftNode;
				}
				else
				{
					array[1] = currentNode.value;
					finished = true;
				}
			}

			return array;
		}

		public void LeftRotation<T>(Node<T> NodeToRotate)
		{
			NodeToRotate.parentNode.parentNode = NodeToRotate;

			NodeToRotate.leftNode = NodeToRotate.parentNode;
			NodeToRotate.rightNode = NodeToRotate.parentNode.leftNode;

		}

		public void RightRotation<T>(Node<T> NodeToRotate)
		{
			NodeToRotate.parentNode.parentNode = NodeToRotate;

			NodeToRotate.rightNode = NodeToRotate.parentNode;
			NodeToRotate.leftNode = NodeToRotate.parentNode.leftNode;

		}
	}
}
