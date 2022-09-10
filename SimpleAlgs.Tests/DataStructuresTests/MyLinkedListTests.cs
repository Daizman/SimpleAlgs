using DataStructures.MyLinkedList;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAlgs.Tests.DataStructuresTests
{
	public class MyLinkedListTests
	{
		public void MyLinkedList_EmptyInit()
		{
			MyLinkedList<int> list = new();
			list.Count.Should().Be(0);
		}
	}
}
