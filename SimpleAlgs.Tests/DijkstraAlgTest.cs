using DataStructures.MyDictionaryTree;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAlgs.Tests
{
	public class DijkstraAlgTest
	{
		[Fact]
		public void DijkstraAlg_SimpleTestCost_ReturnsCorrectAnswer()
		{
			MyDictionaryTree<double> tree = new(new Dictionary<string, Dictionary<string, double>>()
			{
				{
					"start",
					new Dictionary<string, double>()
					{
						{ "a", 6 },
						{ "b", 2 }
					}
				},
				{
					"a",
					new Dictionary<string, double>()
					{
						{ "fin", 1 }
					}
				},
				{
					"b",
					new Dictionary<string, double>()
					{
						{ "a", 3 },
						{ "fin", 5 }
					}
				},
				{
					"fin",
					new Dictionary<string, double>()
				}
			});

			var answer = DijkstraAlg.FindPathLowestCost(tree, "start", "fin");

			answer.Should().BeApproximately(6, 0.001);
		}

		[Fact]
		public void DijkstraAlg_SimpleTestPath_ReturnsCorrectAnswer()
		{
			MyDictionaryTree<double> tree = new(new Dictionary<string, Dictionary<string, double>>()
			{
				{
					"start",
					new Dictionary<string, double>()
					{
						{ "a", 6 },
						{ "b", 2 }
					}
				},
				{
					"a",
					new Dictionary<string, double>()
					{
						{ "fin", 1 }
					}
				},
				{
					"b",
					new Dictionary<string, double>()
					{
						{ "a", 3 },
						{ "fin", 5 }
					}
				},
				{
					"fin",
					new Dictionary<string, double>()
				}
			});

			var answer = DijkstraAlg.FindLowestCostPath(tree, "start", "fin");

			answer.Should().BeEquivalentTo(new string[]
			{
				"start",
				"b",
				"a",
				"fin"
			});
		}
	}
}
