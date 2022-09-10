using System.Collections;

namespace DataStructures.MyLinkedList
{
	public class MyLinkedList<T> : IList<T>, IEnumerable<T>
	{
		private ListNode<T>? _first;
		private ListNode<T>? _last;
		private int _count = 0;

		public int Count => _count;

		public bool IsReadOnly => false;

		public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public MyLinkedList() { }

		public MyLinkedList(IEnumerable<T> items)
		{
			foreach (var item in items)
			{
				Add(item);
			}
		}

		public void Add(T value)
		{
			if (_first is null)
			{
				InitList(value);
			}
			else
			{
				ChangeLast(value);
			}
			_count++;
		}

		public T Pop()
		{
			if (_first is null)
			{
				throw new InvalidOperationException("List have no elements");
			}
			var firstValue = _first.Value;
			_first = _first.Next;
			return firstValue;
		}

		public IEnumerator<T> GetEnumerator()
		{
			var curElement = _first;
			while (curElement is not null)
			{
				yield return curElement.Value;
				curElement = curElement.Next;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private void InitList(T value)
		{
			ListNode<T> node = new() { Value = value, Next = null };
			_first = node;
			_last = node;
		}

		private void ChangeLast(T value)
		{
			var previousLast = _last;
			_last = new ListNode<T>
			{
				Value = value,
				Next = null
			};
			previousLast.Next = _last;
		}

		public int IndexOf(T item)
		{
			int index = 0;
			var enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Equals(item))
				{
					return index;
				}
				index++;
			}
			return -1;
		}

		public void Insert(int index, T item)
		{
			throw new NotImplementedException();
		}

		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		public void Clear()
		{
			_first = null;
			_last = null;
		}

		public bool Contains(T item)
		{
			return IndexOf(item) != -1;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public bool Remove(T item)
		{
			throw new NotImplementedException();
		}
	}
}
