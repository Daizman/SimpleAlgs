using DataStructures.MyGraph;

namespace SimpleAlgs
{
	public static class BFSearch
	{
		public static bool Run<T>(MyGraphNode<T> root, Func<T, bool> check)
		{
			Queue<MyGraphNode<T>> nodes = new();
			HashSet<int> searched = new();
			nodes.Enqueue(root);
			AddChildrensInQueue(root, nodes);

			while (nodes.Any())
			{
				var node = nodes.Dequeue();
				var nodeHash = node.Value.GetHashCode();
				if (!searched.Contains(nodeHash))
				{
					if (check(node.Value))
					{
						return true;
					}
					AddChildrensInQueue(node, nodes);
					searched.Add(nodeHash);
				}
			}

			return false;
		}

		private static void AddChildrensInQueue<T>(MyGraphNode<T> root, Queue<MyGraphNode<T>> nodes)
		{
			foreach (var node in root.Children)
			{
				nodes.Enqueue(node);
			}
		}

		public static bool Run<T>(Dictionary<T, List<T>> graph, T root, Func<T, bool> check)
		{
			Queue<T> nodes = new();
			HashSet<int> searched = new();
			nodes.Enqueue(root);
			AddChildrensInQueue(graph[root], nodes);

			while (nodes.Any())
			{
				var node = nodes.Dequeue();
				var nodeHash = node.GetHashCode();
				if (!searched.Contains(nodeHash))
				{
					if (check(node))
					{
						return true;
					}
					AddChildrensInQueue(graph[node], nodes);
					searched.Add(nodeHash);
				}
			}

			return false;
		}

		private static void AddChildrensInQueue<T>(List<T> root, Queue<T> nodes)
		{
			foreach (var node in root)
			{
				nodes.Enqueue(node);
			}
		}
	}
}
