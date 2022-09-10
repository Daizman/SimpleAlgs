using FluentAssertions;

namespace SimpleAlgs.Tests
{
	public class RecursionSumTests
	{
		[Fact]
		public void RecursionSum_EmptyList_ReturnsZero()
		{
			List<int> list = new();

			var result = RecursionSum.Sum(list);

			result.Should().Be(0);
		}

		[Fact]
		public void RecursionSum_OneElementList_ReturnsElementValue()
		{
			List<int> list = new() { 1 };

			var result = RecursionSum.Sum(list);

			result.Should().Be(1);
		}

		[Fact]
		public void RecursionSum_ManyElementsList_ReturnsSum()
		{
			Random random = new();
			var list = Enumerable.Range(1, 20).Select(el => random.Next(-100, 100)).ToList();
			var sum = list.Sum();

			var result = RecursionSum.Sum(list);

			result.Should().Be(sum);
		}
	}
}
