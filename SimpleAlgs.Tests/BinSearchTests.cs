using FluentAssertions;

namespace SimpleAlgs.Tests
{
	public class BinSearchTests
	{
		[Fact]
		public void BinSearch_WithEmptyList_ReturnsNull()
		{
			List<int> list = new();
			var index = BinSearch.Run(list, 1);
			index.Should().BeNull();
		}

		[Fact]
		public void BinSearch_WithOneElementListAndExistedElement_ReturnsIndex()
		{
			List<int> list = new() { 1 };
			var index = BinSearch.Run(list, 1);
			index.Should().Be(0);
		}

		[Fact]
		public void BinSearch_WithOneElementListAndUnexistedElementLeft_ReturnsNull()
		{
			List<int> list = new() { 1 };
			var index = BinSearch.Run(list, -5);
			index.Should().BeNull();
		}

		[Fact]
		public void BinSearch_WithOneElementListAndUnexistedElementRight_ReturnsNull()
		{
			List<int> list = new() { 1 };
			var index = BinSearch.Run(list, 5);
			index.Should().BeNull();
		}

		[Fact]
		public void BinSearch_WithManyElementsListAndExistedElementLeft_ReturnsIndex()
		{
			List<int> list = Enumerable.Range(1, 100).Select(el => el).ToList();
			var index = BinSearch.Run(list, 13);
			index.Should().Be(12);
		}

		[Fact]
		public void BinSearch_WithManyElementsListAndExistedElementRight_ReturnsIndex()
		{
			List<int> list = Enumerable.Range(1, 100).Select(el => el).ToList();
			var index = BinSearch.Run(list, 58);
			index.Should().Be(57);
		}

		[Fact]
		public void BinSearch_WithManyElementsListAndExistedElementLeftGround_ReturnsIndex()
		{
			List<int> list = Enumerable.Range(1, 100).Select(el => el).ToList();
			var index = BinSearch.Run(list, 100);
			index.Should().Be(99);
		}

		[Fact]
		public void BinSearch_WithManyElementsListAndExistedElementRightGround_ReturnsIndex()
		{
			List<int> list = Enumerable.Range(1, 100).Select(el => el).ToList();
			var index = BinSearch.Run(list, 1);
			index.Should().Be(0);
		}

		[Fact]
		public void BinSearch_WithManyElementsListAndUnexistedElementLeft_ReturnsNull()
		{
			List<int> list = Enumerable.Range(1, 100).Select(el => el).ToList();
			var index = BinSearch.Run(list, -1000);
			index.Should().BeNull();
		}

		[Fact]
		public void BinSearch_WithManyElementsListAndUnexistedElementRight_ReturnsNull()
		{
			List<int> list = Enumerable.Range(1, 100).Select(el => el).ToList();
			var index = BinSearch.Run(list, 1000);
			index.Should().BeNull();
		}
	}
}