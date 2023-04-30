using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Node;

namespace Stack
{
    public class Stack<T>
    {
        private Node<T> head;

        public Stack()
        {
            this.head = null;
        }
        public Stack(Stack<T> stack)
        {
            this.head=stack.head;
        }

        public bool IsEmpty()
        {
            return this.head == null;
        }

        public void Push(T x)
        {
            //Node<T> newNode = new Node<T>(x);
            //newNode.SetNext(head);
            //head = newNode;

            this.head = new Node<T>(x, head);
        }

        public T Pop()
        {
            T value = this.head.GetValue();
            this.head = this.head.GetNext();
            return value;
        }

        public T Top()
        {
            return this.head.GetValue();
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                return "[]";
            }

            string str = "[";
            Node<T> p = this.head;

            while (p.HasNext())
            {
                str = str + p.GetValue() + ",";
                p = p.GetNext();
            }

            str = str + p.GetValue() + "]";

            return str;
        }

        public int NumberOfItems()
        {
            int counter = 0;
            Node<T> temp = head;

            while(temp != null)
            {
                counter++;
                temp = temp.GetNext();
            }

            return counter;
        }
    }
}
