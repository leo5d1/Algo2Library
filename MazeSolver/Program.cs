namespace MazeSolver
{
	internal class Program
	{

		static void Main(string[] args)
		{
			Maze maze = new Maze();
			int lineNum = 1;

			Console.WriteLine("Submit Maze File Path: ");
			var filePath = Console.ReadLine();

			if (filePath != null)
			{
				FileStream file = new FileStream(filePath, FileMode.Open);
				StreamReader sr = new StreamReader(file);

				while(true)
				{
					string data = sr.ReadLine();

					if (data != null)
					{
						if (lineNum == 1)
						{
							maze.allNodes = data.ToList<char>();
							maze.allNodes.RemoveAll(x => x == ',');

							lineNum++;
						}
						else if (lineNum == 2)
						{
							var line = data.ToList<char>();
							line.RemoveAll(x => x == ',');

							maze.startNode = line[0];
							maze.endNode = line[1];

							Console.WriteLine("Start Node: " + maze.startNode);
							Console.WriteLine("End Node: " + maze.endNode);

							lineNum++;
						}
						else
						{
							var line = data.ToList<char>();
							line.RemoveAll(x => x == ',');

							Node newNode = new Node();
							newNode.value = line[0];

							for (int i = 1; i < line.Count; i++)
							{
								newNode.connections.Add(line[i]);
							}

							if (newNode.value == maze.startNode)
							{
								newNode.parentNode = null;
							}

							maze.nodes.Add(newNode);
						}

					}
					else
					{
						break;
					}


				}
				

			}

			// Solve the maze
			maze.FindNode(maze.startNode).depth = 1;
			maze.queue.Add(maze.FindNode(maze.startNode));
			maze.bestPath.Add(maze.startNode);

			Node currentNode = maze.queue[0];

			

			bool pathFound = false;
			while(!pathFound)
			{
				for(int i = 0; i < maze.allNodes.Count; i++)
				{
					if (maze.queue.Count == 1 && !maze.bestPath.Contains(maze.queue[0].value))
					{
						maze.bestPath.Add(maze.queue[0].value);

						if (maze.bestPath[maze.bestPath.Count - 1] == maze.endNode)
						{
							maze.bestPath.Insert(maze.bestPath.Count - 1, maze.FindNode(maze.bestPath[maze.bestPath.Count-1]).parentNode.value);
						}
					}					

					maze.AddConnections(maze.queue[0]);
					maze.totalDepth++;					

					if (maze.bestPath[maze.bestPath.Count - 1] == maze.endNode)
					{
						pathFound = true;
					}
					else
					{
						maze.queue.Remove(currentNode);
						currentNode = maze.queue[0];
					}

					foreach (char node in currentNode.connections)
					{
						Node node1 = maze.FindNode(node);
						if (node1.connections.Count == 0)
						{
							maze.queue.Remove(node1);
						}

						if (node1.connections.Count == 1 && node1.parentNode != null)
						{
							maze.queue.Remove(node1);
						}
					}
				}
			}

			Console.WriteLine("The Best Path: ");
			foreach(char c in maze.bestPath)
			{
				Console.Write(c + ", ");
			}

		}
	}
}