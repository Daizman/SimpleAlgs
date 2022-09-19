namespace DataStructures.MyGraph
{
	public class MyGraphNode<T>
	{
		public T Value { get; set; }

		public List<MyGraphNode<T>> Children { get; set; } = new();
	}
}
