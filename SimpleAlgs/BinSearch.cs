namespace SimpleAlgs
{
	public static class BinSearch
	{
		public static int? Run<T>(IList<T> array, T elToFind) 
			where T : IComparable<T>
		{
			var left = 0;
			var right = array.Count - 1;
			int index;
			while (left <= right)
			{
				index = (left + right) / 2;
				if (array[index].CompareTo(elToFind) == 0)
					return index;
				if (array[index].CompareTo(elToFind) > 0)
				{
					right = index - 1;
				}
				else
				{
					left = index + 1;
				}
			}

			return null;
		}
	}
}
