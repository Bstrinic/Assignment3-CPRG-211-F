
using System;
using System.Runtime.Serialization;

namespace Assignment3 // Namespace of the project
{
    [Serializable, KnownType(typeof(User))] // Serialize the User class
    public class SLL : ILinkedListADT // Singly Linked List
    {
        public Node Head { get; set; } // Head of the list
        public Node Tail { get; set; } // Tail of the list
        private int _count = 0; // Number of elements in the list

        public SLL()
        {
            this.Head = null;
            this.Tail = null;
            this._count = 0;
        }

        public void Add(User value, int index) // Add a value at a specific index
        {
            if (index < 0 || index > _count)    // Check if the index is valid
            {
                throw new ArgumentOutOfRangeException(nameof(index)); // Check if the index is valid
            }

            Node newNode = new Node();
            newNode.Value = value;

            if (_count == 0)  // List is empty
            {
                Head = newNode;
                Tail = newNode;
            }
            else if (index == 0)  // Add at the beginning
            {
                newNode.Next = Head;
                Head = newNode;
            }
            else if (index == _count)  // Add at the end
            {
                Tail.Next = newNode; 
                Tail = newNode;
            }
            else  // Add in the middle
            {
                Node node = Head; // Find the node before the index
                for (int i = 0; i < index - 1; i++) // Traverse the list
                {
                    node = node.Next; // Move to the next node
                }
                newNode.Next = node.Next; 
                node.Next = newNode; // Insert the new node
            }

            _count++; // Increment the count
        }

        public void AddFirst(User value) // Add at the beginning
        {
            Add(value, 0); // Add at the beginning
        }

        public void AddLast(User value); // Add at the end
        {
            Add(value, _count); // Add at the end
        }

        public void Clear() // Remove all elements
        {
            Head = null;
            Tail = null;
            _count = 0; // Reset the count
        }

        public bool Contains(User value) // Check if the list contains a value
        {
            Node node = Head;
            while (node != null)
            {
                if (node.Value.Id == value.Id) // Check if the value is in the list
                {
                    return true; // Return true if the value is in the list
                }
                node = node.Next; // Move to the next node
            }
            return false; // Return false if the value is not in the list
        }

        public int Count() // Return the number of elements in the list
        {
            return _count;
        }

        public User GetValue(int index) // Get the value at a specific index
        {
            if (index < 0 || index >= _count) // Check if the index is valid
            {
                throw new ArgumentOutOfRangeException(nameof(index)); // Check if the index is valid
            }

            Node node = Head;
            for (int i = 0; i < index; i++) // Traverse the list
            {
                node = node.Next;
            }
            return node.Value; // Return the value at the index
        }

        public int IndexOf(User value) // Get the index of a value
        {
            Node node = Head;
            int index = 0;
            while (node != null)
            {
                if (node.Value.Equals(value)) // Check if the value is in the list
                {
                    return index; // Return the index of the value
                }
                node = node.Next; // Move to the next node
                index++;
            }
            return -1;
        }

        public bool IsEmpty() // Check if the list is empty
        {
            return _count == 0; // Check if the list is empty
        }

        public void Remove(int index) // Remove an element at a specific index
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index)); // Check if the index is valid
            }

            if (_count == 1)  // Only one element in the list
            {
                Head = null; // Remove the element
                Tail = null; // Remove the element
            }
            else if (index == 0)  // Remove the first element
            {
                Head = Head.Next;
            }
            else if (index == _count - 1)  // Remove the last element
            {
                Node node = Head;
                for (int i = 0; i < index - 1; i++) 
                {
                    node = node.Next;
                }
                node.Next = null;
                Tail = node;
            }
            else  // Remove from the middle
            {
                Node node = Head;
                for (int i = 0; i < index - 1; i++)
                {
                    node = node.Next;
                }
                node.Next = node.Next.Next;
            }

            _count--;
        }

        public void RemoveFirst() // Remove the first element
        {
            Remove(0); // Remove the first element
        }

        public void RemoveLast() // Remove the last element
        {
            Remove(_count - 1); // Remove the last element
        }

        public void Replace(User value, int index) // Replace an element at a specific index
        { 
            if (index < 0 || index >= _count) // Check if the index is valid
            {
                throw new ArgumentOutOfRangeException(nameof(index)); // Check if the index is valid
            }

            Node node = Head;
            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            node.Value = value;
        }

        public void Reverse() // Reverse the list
        {
            if (_count <= 1)
            {
                return; // Nothing to reverse
            } 

            Node prev = null; // Initialize the previous node
            Node current = Head; // Start from the Head
            Node next = null;// Initialize the next node

            while (current != null) // Traverse the list
            {
                next = current.Next; // Save the next node
                current.Next = prev; // Reverse the current node
                prev = current; // Move to the next node
                current = next; // Move to the next node
            }

            Head = prev; // Update the Head
        }
    }
}
