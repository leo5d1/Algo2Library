using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
	class Node
	{
		public Node? parentNode;

		public char value;
		public int depth;

		public List<char> connections = new List<char>();
	}

	internal class Maze
	{
		public List<char> allNodes = new List<char>();

		public List<Node> nodes = new List<Node>();

		public char startNode;
		public char endNode;

		public List<char> bestPath = new List<char>();

		public List<Node> queue = new List<Node>();

		public List<Node> visitedNodes = new List<Node>();

		public int totalDepth = 0;

		public Node FindNode(char value)
		{
			Node foundNode = new Node();

			for(int i = 0; i < nodes.Count; i++)
			{
				if (nodes[i].value == value)
				{
					foundNode = nodes[i];
				}
			}

			return foundNode;
		}


		public void AddConnections(Node node)
		{			
			visitedNodes.Add(node);

			foreach (char currentNode in node.connections)
			{
				if (visitedNodes.Contains(FindNode(currentNode))) { continue; }
				Node newNode = FindNode(currentNode);

				newNode.parentNode = node;
				newNode.depth = newNode.parentNode.depth + 1;

				queue.Add(newNode);
			}
		}
	}
}
