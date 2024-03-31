using System;
using System.Security.Permissions;

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
		Assert.AreEqual(1, linkedlist.First.Value); // Checking to see if the item was added to the beginning 
	}

	[Test]
	public void AppendItem()
	{
		linkedlist.AddLast(1);
		Assert.AreEqual(1, linkedlist.Last.Value); // Checking to see if the item was added to the end
	}

	// To check if the item is added to a specific index in the list
	[Test]
	public void InsertItemAtIndex()
	{
		linkedlist.AddFirst(1);
		linkedlist.AddAfter(linkedlist.First, 2);
		Assert.AreEqual(2, linkedlist.Last.Value);
	}

	[Test]
	public void ReplaceItem()
	{
		linkedlist.AddFirst(1);
		var node = linkedlist.Find(1);
		// Adds a new item after the existing node
		linkedlist.AddAfter(node, 2);
		//Removes original node
		linkedlist.Remove(node); 
		// Used to verify that the first number was replaced
		Assert.AreEqual(2, linkedlist.First.Value);
	}

}
