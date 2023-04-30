using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Node;

namespace Queue
{
    public class Queue<T>
    {
        private Node<T> first;
        private Node<T> last;

        public Queue()
        {
            this.first = this.last = null;
        }
        public Queue(Queue<T> dup)
        {
            this.first=dup.first; 
            this.last=dup.last;
        }

        public bool IsEmpty()
        {
            return this.first == null;
        }

        public void Insert(T x)
        {
            Node<T> newNode = new Node<T>(x);

            if (this.first == null)
            {
                first = newNode;
                //last = newNode;
            }
            else
            {
                last.SetNext(newNode);
                //last = newNode;
            }
            last = newNode;
        }

        public T Remove()
        {
            Node<T> temp = first;
            first = first.GetNext();
            temp.SetNext(null);

            if (first == null)
                last = null;

            return temp.GetValue();
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
            Node<T> ptr = first;

            while (ptr.HasNext())
            {
                str += ptr.GetValue() + ",";
                ptr = ptr.GetNext();
            }
            str += ptr.GetValue() + "]";

            return str;
        }

        public int NumberOfItems()
        {
            int counter = 0;
            Node<T> temp = first;

            while(temp != null)
            {
                counter++;
                temp = temp.GetNext();
            }

            return counter;
        }
    }
}
