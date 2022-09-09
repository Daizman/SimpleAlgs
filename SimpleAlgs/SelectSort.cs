using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAlgs
{
	public static class SelectSort
	{
		#region Sort
		public static int FindIndexOfSmallestElementInArray(double[] array)
		{
			var smallestIndex = 0;
			var arrayLength = array.Length;

			for (int i = 0; i < arrayLength; i++)
			{
				if (array[i] < array[smallestIndex])
				{
					smallestIndex = i;
				}
			}

			return smallestIndex;
		}

		public static double[] Run(double[] array)
		{
			var arrayLength = array.Length;
			var answer = new double[arrayLength];
			array.CopyTo(answer, 0);

			for (int i = 0; i < arrayLength; i++)
			{
				var smallestIndex = i;
				for (int j = i + 1; j < arrayLength; j++)
				{
					if (answer[j] < answer[smallestIndex])
					{
						smallestIndex = j;
					}
				}
				var smallest = answer[smallestIndex];
				answer[smallestIndex] = answer[i];
				answer[i] = smallest;
			}

			return answer;
		}

		/*public static void SelectSortTests()
		{
			var emptyArray = Array.Empty<double>();
			var oneElementArray = new double[] { 1 };
			Random random = new();
			var manyElementsArray = Enumerable.Range(1, 20).Select(el => (double)random.Next(-100, 100)).ToArray();

			Console.WriteLine(SelectSort(emptyArray).ToReadableString());
			Console.WriteLine(SelectSort(oneElementArray).ToReadableString());
			Console.WriteLine(SelectSort(manyElementsArray).ToReadableString());
		}*/
		#endregion

	}
}
