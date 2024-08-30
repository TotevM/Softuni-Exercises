namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public Node Next { get; set; }
            public Node Previous { get; set; }
            public T Value { get; set; }

            public Node(T value)
            {
                this.Value = value;
            }
        }

        private Node head;
        private Node tail;

        public DoublyLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node toInsert = new Node(item);

            if (this.head == null)
            {
                this.head = this.tail = toInsert;
            }
            else
            {
                this.head.Previous = toInsert;
                toInsert.Next = this.head;
                this.head = toInsert;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            Node toInsert = new Node(item);

            if (this.head == null)
            {
                this.head = this.tail = toInsert;
            }
            else
            {
                toInsert.Previous = this.tail;
                this.tail.Next = toInsert;
                this.tail = toInsert;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            this.CheckIfListIsNotEmpty();

            return this.head.Value;
        }

        public T GetLast()
        {
            this.CheckIfListIsNotEmpty();

            return this.tail.Value;
        }

        public T RemoveFirst()
        {
            this.CheckIfListIsNotEmpty();

            Node current = this.head;

            if (this.head.Next == null)
            {
                this.head = this.tail = null;
            }
            else
            {
                Node newHead = this.head.Next;
                newHead.Previous = null;
                this.head = newHead;
            }

            this.Count--;
            return current.Value;
        }

        public T RemoveLast()
        {
            this.CheckIfListIsNotEmpty();

            Node current = this.tail;
            if (current.Previous == null)
            {
                this.head = this.tail = null;
            }
            else
            {
                Node newTail = this.tail.Previous;
                newTail.Next = null;
                this.tail = newTail;
            }

            this.Count--;
            return current.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = this.head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void CheckIfListIsNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Doubly Linked List should not be empty!");
            }
        }
    }
}