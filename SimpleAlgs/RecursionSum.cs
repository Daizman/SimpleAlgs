namespace SimpleAlgs
{
	public static class RecursionSum
	{
		public static int Sum(List<int> list)
		{
			if (!list.Any()) return 0;
			return list[0] + Sum(list.GetRange(1, list.Count - 1));
		}
	}
}
