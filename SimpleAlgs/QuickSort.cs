namespace SimpleAlgs
{
	public static class QuickSort
	{
		public static List<T> Run<T>(List<T> list)
			where T : IComparable<T>
		{
			if (list.Count < 2)
				return list;
			
			var pivot = list[0];
			var less = list.Skip(1).Where(el => el.CompareTo(pivot) <= 0).ToList();
			var greater = list.Skip(1).Where(el => el.CompareTo(pivot) > 0).ToList();

			return Run(less).Concat(new List<T>() { pivot }).Concat(Run(greater)).ToList();
		}
	}
}
