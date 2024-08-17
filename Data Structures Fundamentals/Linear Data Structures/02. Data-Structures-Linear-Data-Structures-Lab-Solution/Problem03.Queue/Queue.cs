namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                this.Element = element;
                this.Next = next;
            }

            public Node(T element)
            {
                this.Element = element;
            }
        }

        private Node head;

        public Queue()
        {
            this.head = null;
            this.Count = 0;
        }

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            Node current = this.head;
            while (current != null)
            {
                if (current.Element.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            // 01. Get the head value (new variable)
            // 02. Set the head to be the next element
            // 03. Decrease size
            // 04. Return old head value

            this.EnsureIfNotEmpty();
            T item = this.head.Element;
            this.head = this.head.Next;
            this.Count--;

            return item;
        }

        public void Enqueue(T item)
        {
            // 01. Create new head
            // 02. Iterate all to reach last
            // 03. Set next for the last to be the new head
            // 04. Increase size

            Node toInsert = new Node(item);
            Node current = this.head;

            if (current is null)
            {
                this.head = toInsert;
            }
            else
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = toInsert;
            }
            this.Count++;
        }

        public T Peek()
        {
            this.EnsureIfNotEmpty();

            return this.head.Element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = this.head;

            while (current != null)
            {
                yield return current.Element;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void EnsureIfNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }
        }
    }
}