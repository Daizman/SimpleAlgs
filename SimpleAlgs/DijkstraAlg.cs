using DataStructures.MyDictionaryTree;

namespace SimpleAlgs
{
	public static class DijkstraAlg
	{
		public static double FindPathLowestCost(MyDictionaryTree<double> graph, string start, string end)
		{
			Dictionary<string, double> costs = new();
			Dictionary<string, string> parents = new();
			HashSet<string> passed = new();
			PrepareStructuresForAlg(graph, costs, parents, passed, start);
			FindLowestCosts(graph, costs, parents, passed);
			return costs[end];
		}

		public static List<string> FindLowestCostPath(MyDictionaryTree<double> graph, string start, string end)
		{
			Dictionary<string, double> costs = new();
			Dictionary<string, string> parents = new();
			HashSet<string> passed = new();
			PrepareStructuresForAlg(graph, costs, parents, passed, start);
			FindLowestCosts(graph, costs, parents, passed);
			return RestorePath(parents, start, end);
		}

		private static void PrepareStructuresForAlg(MyDictionaryTree<double> graph, Dictionary<string, double> costs, Dictionary<string, string> parents, HashSet<string> passed, string start)
		{
			passed.Add(start);
			foreach (var key in graph.Nodes)
			{
				costs[key] = double.MaxValue;
				parents[key] = string.Empty;
			}
			foreach (var startToNodeCost in graph[start])
			{
				costs[startToNodeCost.Key] = startToNodeCost.Value;
				parents[startToNodeCost.Key] = start;
			}
		}

		private static void FindLowestCosts(MyDictionaryTree<double> graph, Dictionary<string, double> costs, Dictionary<string, string> parents, HashSet<string> passed)
		{
			var node = FindLowestCostNode(costs, passed);
			while (node != string.Empty)
			{
				var cost = costs[node];
				var children = graph[node];
				foreach (var child in children)
				{
					var newCost = cost + children[child.Key];
					if (costs[child.Key] > newCost)
					{
						costs[child.Key] = newCost;
						parents[child.Key] = node;
					}
				}
				passed.Add(node);
				node = FindLowestCostNode(costs, passed);
			}
		}

		private static List<string> RestorePath(Dictionary<string, string> parents, string start, string end)
		{
			var node = end;
			var answer = new List<string>() { node };
			while (node != start)
			{
				node = parents[node];
				answer.Add(node);
			}
			answer.Reverse();
			return answer;
		}

		private static string FindLowestCostNode(Dictionary<string, double> costs, HashSet<string> passed)
		{
			var min = double.MaxValue;
			var answer = string.Empty;
			foreach (var cost in costs)
			{
				if(passed.Contains(cost.Key))
				{
					continue;
				}
				if(cost.Value < min)
				{
					min = cost.Value;
					answer = cost.Key;
				}
			}
			return answer;
		}
	}
}
