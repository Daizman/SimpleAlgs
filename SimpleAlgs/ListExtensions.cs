using System.Text;

namespace SimpleAlgs
{
	public static class ListExtensions
	{
		public static string ToReadableString<T>(this List<T> list)
		{
			StringBuilder answer = new();
			foreach (var el in list)
			{
				answer.Append($"{el}; ");
			}
			return answer.ToString();
		}
	}
}
