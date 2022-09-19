namespace DataStructures.MyDictionaryTree
{
	public class MyDictionaryTree<T>
	{
		private readonly Dictionary<string, Dictionary<string, T>> _tree = new();

		public MyDictionaryTree(List<string> nodes)
		{
			foreach (var node in nodes)
			{
				InitNodeIfNotExists(node);
			}
		}

		public MyDictionaryTree(List<TreeEdge<T>> edges)
		{
			foreach (var edge in edges)
			{
				AddEdge(edge);
			}
		}

		public MyDictionaryTree(Dictionary<string, Dictionary<string, T>> tree)
		{
			foreach (var node in tree)
			{
				foreach (var nodeEnd in node.Value)
				{
					AddEdge(new()
					{
						Start = node.Key,
						End = nodeEnd.Key,
						Cost = nodeEnd.Value
					});
				}
			}
		}

		public List<string> Nodes => _tree.Select(kv => kv.Key).ToList();

		public void AddEdge(TreeEdge<T> edge)
		{
			InitNodeIfNotExists(edge.Start);
			InitNodeIfNotExists(edge.End);
			_tree[edge.Start][edge.End] = edge.Cost;
		}

		private void InitNodeIfNotExists(string node)
		{
			if (!NodeExists(node))
			{
				_tree[node] = new();
			}
		}

		public bool NodeExists(string node)
		{
			return _tree.ContainsKey(node);
		}

		public void EditEdgeCost(TreeEdge<T> edge)
		{
			CheckNodesExists(edge.Start, edge.End);
			_tree[edge.Start][edge.End] = edge.Cost;
		}

		private void CheckNodesExists(string start, string end)
		{
			if (!NodeExists(start) || !NodeExists(end))
			{
				throw new ArgumentException("One of node in edge doesn't exists");
			}
		}

		public void DeleteEdge(string start, string end)
		{
			CheckNodesExists(start, end);
			_tree[start].Remove(end);
		}

		public void AddNode(string nodeName)
		{
			InitNodeIfNotExists(nodeName);
		}

		public void DeleteNode(string nodeName)
		{
			_tree.Remove(nodeName);
		}

		public bool PathExists(string start, string end)
		{
			Queue<string> nodes = new();
			HashSet<string> passed = new();
			nodes.Enqueue(start);
			nodes = AddChildrensInQueueForAlgs(GetNodeChildren(start), nodes);

			while (nodes.Any())
			{
				var node = nodes.Dequeue();
				if (passed.Contains(node))
				{
					continue;
				}
				if (node == end)
				{
					return true;
				}
				nodes = AddChildrensInQueueForAlgs(GetNodeChildren(node), nodes);
				passed.Add(node);
			}
			return false;
		}

		private Queue<string> AddChildrensInQueueForAlgs(List<string> children, Queue<string> nodes)
		{
			Queue<string> newNodes = new(nodes);
			foreach (var child in children)
			{
				newNodes.Enqueue(child);
			}
			return newNodes;
		}

		public List<string> GetNodeChildren(string nodeName)
		{
			return _tree[nodeName].Select(kv => kv.Key).ToList();
		}

		public Dictionary<string, T> GetNodeChildrenWithCosts(string nodeName)
		{
			return _tree[nodeName];
		}

		public Dictionary<string, T> this[string nodeName] => GetNodeChildrenWithCosts(nodeName); 
	}
}
