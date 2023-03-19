using System;
using System.Collections.Generic;
using System.Text;

namespace StackImplementation
{
    public class Stack<T>
    {
        private Node<T> head;

        public Stack()
        {
            head = null;
        }


        public bool IsEmpty()
        {
            return head == null;
        }

        public void Push(T x)
        {
            Node<T> newNode = new Node<T>(x);
            newNode.Next = head;
            head = newNode;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot pop an empty stack.");
            }
            T data = head.Data;
            head = head.Next;
            return data;
        }

        public T Top()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot get top element of an empty stack.");
            }
            return head.Data;
        }
        public int Count()
        {
            int count = 0;
            Node<T> current = head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("[");
            Node<T> current = head;
            while (current != null)
            {
                sb.Append(current.Data);
                current = current.Next;
                if (current != null)
                {
                    sb.Append(",");
                }
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}
