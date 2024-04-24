using System;
using Assignment3.Utility;
using NUnit.Framework;


namespace Assignment3.Tests;

[TestFixture]
public class LinkedListTests
{
    // Using polymorphism to create a global linked list variable
    private SLL linkedList;

    [SetUp]
    public void SetUp()
    {
        // Used to initialize the LinkedList before each test case
        linkedList = new SLL();
    }

    [TearDown]
    public void TearDown()
    {
        // Executes after each test method
        linkedList.Clear();
    }

    [Test]
    public void ListIsEmpty()
    {
        // Using .IsEmpty to check if the list is empty
        Assert.IsTrue(linkedList.IsEmpty());
    }

    [Test]
    public void PrependItem()
    {
        // Adding a user
        var user = new User(2, "John Doe", "Doe@gmail.com", "1234");
        linkedList.AddFirst(user);
        Assert.That(linkedList.GetValue(0), Is.EqualTo(user), "Item should be first on the list");
    }

    [Test]
    public void AppendItem()
    {
        // Adding a user
        var user = new User(2, "John Doe", "Doe@gmail.com", "1234");
        linkedList.AddLast(user);
        Assert.That(linkedList.GetValue(linkedList.Count() - 1), Is.EqualTo(user), "Item should be last in the list");
    }

    // To check if the item is added to a specific index in the list
    [Test]
    public void InsertItemAtIndex()
    {
        // Adding users
        var newUser1 = new User(3, "Christiano Ronaldo", "CR7@gmail.com", "CR7-1234");
        var newUser2 = new User(4, "Lionel Messi", "LM10@gmail.com", "LM10-1234");
        linkedList.AddFirst(newUser1);
        linkedList.Add(newUser2, 1); // Inserting newUser2 at the first index
        Assert.That(linkedList.GetValue(1), Is.EqualTo(newUser2), "Inserted item is at index 1");
    }

    [Test]
    public void ReplaceItem()
    {
        // Adding users
        var newUser1 = new User(5, "Earling Haaland", "EH9@gmail,com", "EH9-1234");
        var newUser2 = new User(6, "Phil Foden", "Fodes@gmail.com", "PH47-1234");
        linkedList.AddFirst(newUser1);
        linkedList.Replace(newUser2, 0);
        Assert.That(linkedList.GetValue(0), Is.EqualTo(newUser2), "Replaced item should be at index 0");
    }

    [Test]
    public void DeleteItemFromBeginning()
    {
        // Adding a user
        var user = new User(7, "Dennis Berkamp", "Berkamp@gmail.com", "DB10-1234");
        linkedList.AddFirst(user);
        linkedList.RemoveFirst();
        Assert.IsTrue(linkedList.IsEmpty(), "List should be empty after removing the first item");
    }

    [Test]
    public void DeleteItemFromEnd()
    {
        // Adding a user
        var user = new User(8, "Jude Bellingham", "Bellinggoal@gmail.com", "JB-1234");
        linkedList.AddLast(user);
        linkedList.RemoveLast();
        Assert.IsTrue(linkedList.IsEmpty(), "Removing an item from the end should make the list empty");
    }

    [Test]
    public void DeleteFromMiddle()
    {
        // Adding users
        var newUser1 = new User(9, "Karim Benzima", "Benz@gmail.com", "1234");
        var newUser2 = new User(10, "Sergio Ramos", "Sergio@gmail,com", "1234");
        var newUser3 = new User(11, "Garath Bale", "PaceDemon@gmail.com", "1234");
        linkedList.AddFirst(newUser1);
        linkedList.AddLast(newUser3);
        linkedList.Add(newUser2, 1); // Inserting at index 1
        linkedList.Remove(1);
        Assert.That(linkedList.GetValue(1), Is.EqualTo(newUser3), "Middle item is removed");
    }

    [Test]
    public void FindAndRetrieveItem()
    {
        // Adding a user
        var user = new User(12, "Ruud Gullit", "Ruud@gmail.com", "1234");
        linkedList.AddFirst(user);
        var foundUser = linkedList.GetValue(linkedList.IndexOf(user));
        Assert.That(foundUser, Is.EqualTo(user), "Finding the item we are looking for");
    }
}
