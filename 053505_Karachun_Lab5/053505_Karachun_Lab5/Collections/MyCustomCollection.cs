using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _053505_Karachun_Lab5.Interfaces;
using _053505_Karachun_Lab5.Entities;

namespace _053505_Karachun_Lab5.Collections
{
    public class Node<T>
    {
        public Node(T item)
        {
            Item = item;
        }
        public T Item { get; set; }
        public Node<T> Next { get; set; }
    }
    public class MyCustomCollection<T> : ICustomCollection<T> 
    {
        public Node<T> head;
        public Node<T> tail;
        public Node<T> current;
        public int count = 0;
        private int position;
        public int Position
        {
            get { return position; }
            set { position = value; }
        }
        public Node<T> this[int index]
        {
            get
            {
                if (index >= Count)
                {
                    Console.WriteLine("WrongIndex");
                }

                Reset();
                for (int i = 0; i < index; i++)
                {
                    Next();
                }
                return current;
            }
            set
            {
                if (index >= Count)
                {
                    Console.WriteLine("WrongIndex");
                }

                Reset();
                for (int i = 0; i < index; i++)
                {
                    Next();
                }

                current = value;
            }
        }
        public void Add(T item)
        {
            Node<T> node = new(item);

            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
            }
            tail = node;

            count++;
            current = tail;
        }
        public void Reset()
        {
            current = head;
        }
        public void Next()
        {
            if (current.Next != null)
            {
                current = current.Next;
            }
        }
        public T Current()
        {
            return current.Item;
        }
        public void Remove(T item)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Item.Equals(item))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        head = head.Next;

                        if (head == null)
                        {
                            tail = null;
                        }
                    }
                    count--;
                }
                previous = current;
                current = current.Next;
            }
        }
        public T RemoveCurrent()
        {
            Node<T> current = head;
            Node<T> previous = null;

            for (int i = 0; i < position; i++)
            {
                previous = current;
                current = current.Next;
            }

            if (position == 0)
            {
                head = head.Next;

                if (head == null)
                {
                    tail = null;
                }
            }
            else if (position == count - 1)
            {
                previous.Next = current.Next;
                tail = previous;
            }
            else
            {
                previous.Next = current.Next;
            }

            return current.Item;
        }
        public int Count { get { return count; } }
    }
}
