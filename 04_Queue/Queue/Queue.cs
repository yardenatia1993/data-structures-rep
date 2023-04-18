using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedList;

namespace Queue
{
    internal class Queue<T>
    {
        private Node<T> first;
        private Node<T> last;

        public Queue()
        {
            this.first = this.last = null;
        }

        public bool IsEmpty()
        {
            return this.first == null;
        }

        public void Insert(T x)
        {
            Node<T> node = new Node<T>(x);

            if (IsEmpty())
            {
                first = node;
            }
            else
            {
                last.SetNext(node);
            }
            last = node;
        }

        public T Remove()
        {
            T x = first.GetValue();
            first = first.GetNext();

            if (first == null)
            {
                last = null;
            }

            return x;
        }

        public T Head()
        {
            return first.GetValue();
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                return "[]";
            }

            string str = "[";
            Node<T> temp = first;
            while (temp != null)
            {
                str += temp.GetValue() + ",";
                temp = temp.GetNext();
            }
            //str = str.Substring(0, str.Length - 1) + "]";
            str += "\b]";

            return str;
        }

        public int NumberOfNodes()
        {
            Node<T> temp = first;
            int counter = 0;

            while (temp != null)
            {
                counter++;
                temp = temp.GetNext();
            }

            return counter;
        }
    }
}
