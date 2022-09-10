using FluentAssertions;

namespace SimpleAlgs.Tests
{
	public class SelectSortTests
	{
		[Fact]
		public void SelectSort_WithEmptyList_ReturnsEmptyList()
		{
			List<int> list = new();

			var sorted = SelectSort<int>.Run(list);

			list.Should().BeEmpty();
			sorted.Should().BeEmpty();
		}

		[Fact]
		public void SelectSort_WithOneElementList_ReturnsOneElementList()
		{
			List<int> list = new() { 1 };

			var sorted = SelectSort<int>.Run(list);

			list.Should().HaveCount(1);
			list[0].Should().Be(1);
			sorted.Should().HaveCount(1);
			sorted[0].Should().Be(1);
			sorted.Should().BeEquivalentTo(list);
		}

		[Fact]
		public void SelectSort_WithManyElementsList_ReturnsSortedList()
		{
			Random random = new();
			var list = Enumerable.Range(1, 20).Select(el => random.Next(-100, 100)).ToList();
			var compareList = list.OrderBy(el => el).ToList();

			var sorted = SelectSort<int>.Run(list);

			sorted.Should().HaveCount(list.Count);
			sorted.Should().BeEquivalentTo(compareList);
		}
	}
}
