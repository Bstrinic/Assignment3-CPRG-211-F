using System;

/// <summary>
/// Summary description for Class1
/// </summary>
[TestFixture]
public class LinkedListTests
{
	private LinkedList<int> linkedlist;

	[SetUp]
	public void SetUp()
	{
		// Used to initialize the LinkedList before each test case
		linkedlist = new LinkedList<int>();
	}

	[Test]
	public void ListIsEmpty()
	{
		// Using Assert to check if the list is empty
		Assert.IsEmpty(linkedlist);
	}

	[Test]
	public void PrependItem()
	{
		linkedlist.AddFirst(1);
		Assert.AreEqual(1, linkedlist.First.Value);
	}


}
