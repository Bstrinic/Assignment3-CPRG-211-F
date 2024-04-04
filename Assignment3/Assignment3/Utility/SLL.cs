using System;
using System.Runtime.Serialization;

namespace Assignment3.Utility
{
    [DataContract]
    [KnownType(typeof(SLL))]
    public class SLL : ILinkedListADT
    {
        [DataContract]
        private class Node
        {
            private User value;
            [DataMember]
            public User Data { get; set; }
            [DataMember]
            public Node Next { get; set; }
            public Node(User data, Node next)
            {
                Data = data;
                Next = next;
            }

            public Node(User value)
            {
                this.value = value;
            }
        }

        [DataMember]
        private Node head;

        public SLL()
        {
            _ = head == null;
        }
        public bool IsEmpty()
        {
            return head == null;
        }

        public void Clear()
        {
            head = null;
        }
        public void AddLast(User value)
        {
            Node newNode = new Node(value);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public void AddFirst(User Value)
        {
            Node newNode = new Node(Value);
            newNode.Next = head;
            head = newNode;
        }
        public void Add(User Value, int index)
        {
            if (index < 0 || index > Count())
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            if (index == 0)
            {
                AddFirst(Value);
                return;
            }

            Node newNode = new Node(Value);
            Node current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            newNode.Next = current.Next;
            current.Next = newNode;
        }

        public void Replace(User Value, int Index)
        {
            if (Index < 0 || Index >= Count())
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            Node current = head;
            for (int i = 0; i < Index; i++)
            {
                current = current.Next;
            }
            current.Data = Value;
        }

        public void RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new CannotRemoveException("Cannot remove from empty list");
            }

            head = head.Next;
        }

        public void RemoveLast()
        {
            if (IsEmpty())
            {
                throw new CannotRemoveException("Cannot remove from an empty list");
            }

            if (head.Next == null)
            {
                head = null;
            }
            else
            {
                Node current = head;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
            }
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= Count())
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            if (index == 0)
            {
                RemoveFirst();
                return;
            }

            Node current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
        }
        public User GetValue(int index)
        {
            if (index < 0 || index >= Count())
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

        public int IndexOf(User value)
        {
            Node current = head;
            int index = 0;
            while (current != null)
            {
                if (current.Data.Equals(value))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            return -1; // Element not found

        }
        public bool Contains(User value)
        {
            return IndexOf(value) != -1;
        }
        public void Reverse()
        {
            // Initialize three pointers: prev, current, and next.
            // prev: will initially be null, it will point to the previous node after reversal.
            // current: starts at the head of the list and iterates through the list.
            // next: temporarily stores the next node to prevent losing the reference to it during reversal.
            Node prev = null;
            Node current = head;
            Node next = null;

            // Iterate through the list
            while (current != null)
            {
                // Store the next node in the list.
                next = current.Next;

                // Reverse the pointer of the current node to point to the previous node.
                current.Next = prev;

                // Move prev and current pointers one step forward in the list.
                prev = current;
                current = next;
            }

            // After the loop, 'prev' will be pointing to the last node in the original list,
            // so update 'head' to point to 'prev', effectively reversing the list.
            head = prev;
        }

        public int Count()
        {
            int count = 0;
            Node current = head;
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }
}
