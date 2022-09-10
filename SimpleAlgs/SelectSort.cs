namespace SimpleAlgs
{
	public static class SelectSort<T>
		where T : IComparable<T>
	{
		private static int FindIndexOfSmallestElementInList(List<T> list)
		{
			var smallestIndex = 0;
			var smallest = list[smallestIndex];
			var count = list.Count;

			for (int i = 0; i < count; i++)
			{
				if (smallest.CompareTo(list[i]) > 0)
				{
					smallest = list[i];
					smallestIndex = i;
				}
			}

			return smallestIndex;
		}

		public static List<T> Run(List<T> list)
		{
			var count = list.Count;
			List<T> answer = new();
			List<T> listCopy = new(list);

			for (int i = 0; i < count; i++)
			{
				var smallestIndex = FindIndexOfSmallestElementInList(listCopy);
				var smallest = listCopy[smallestIndex];
				answer.Add(smallest);
				listCopy.RemoveAt(smallestIndex);
			}

			return answer;
		}
	}
}
