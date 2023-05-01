using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinNode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinNode<int> n1 = new BinNode<int>(10);
            BinNode<int> n3 = new BinNode<int>(30);
            BinNode<int> n2 = new BinNode<int>(n1,20,n3);
            n1.SetRight(n2);
            n3.SetLeft(n2);

            BinNode<int> head = n1;
            Console.WriteLine(head);

            Print(head);

            PrintRec(head);
            Console.WriteLine();

            PrintRecRightToLeft(head);
            Console.WriteLine();

            BinNode<int> middle = ReturnMiddle(head);
            Console.WriteLine(middle);

            BinNode<char> c1 = new BinNode<char>('K');
            BinNode<char> c2 = new BinNode<char>('A');
            BinNode<char> c3 = new BinNode<char>('Y');
            BinNode<char> c4 = new BinNode<char>('Y');
            BinNode<char> c5 = new BinNode<char>('A');
            BinNode<char> c6 = new BinNode<char>('K');
            c1.SetRight(c2);
            c2.SetLeft(c1);
            c2.SetRight(c3);
            c3.SetLeft(c2);
            c3.SetRight(c4);
            c4.SetLeft(c3);
            c4.SetRight(c5);
            c5.SetLeft(c4);
            c5.SetRight(c6);
            c6.SetLeft(c5);
            BinNode<char> listOfChars = c1;
            Console.WriteLine(IsPalyndrome(listOfChars));
        }

        public static void Print<T>(BinNode<T> head)
        {
            while (head != null)
            {
                Console.Write(head.GetValue() + " ");
                head = head.GetRight();
            }
            Console.WriteLine();
        }

        public static void PrintRec<T>(BinNode<T> head)
        {
            if (head == null)
                return;

            Console.Write(head.GetValue() + " ");
            PrintRec(head.GetRight());
        }

        public static void PrintRecRightToLeft<T>(BinNode<T> head)
        {
            if (head == null)
                return;

            PrintRecRightToLeft(head.GetRight());
            Console.Write(head.GetValue() + " ");
        }

        public static BinNode<T> ReturnMiddle<T>(BinNode<T> head)
        {
            BinNode<T> start = head;
            BinNode<T> end = head;

            while (end.HasRight())
            {
                end = end.GetRight();
            }

            while (start != end)
            {
                start = start.GetRight();
                end = end.GetLeft();
            }

            return start;
        }

        public static bool IsPalyndrome(BinNode<char> head)
        {
            BinNode<char> start = head;
            BinNode<char> end = head;

            while (end.HasRight())
            {
                end = end.GetRight();
            }

            while (start != null && end != null)
            {
                if (!start.GetValue().Equals(end.GetValue()))
                    return false;

                start = start.GetRight();
                end = end.GetLeft();

                //for list with odd objects return when start==end
                if (start == end)
                {
                    return true;
                }
                //for list with even objects return when start.GetRight()==end
                else if (start.GetRight() == end)
                {
                    return start.GetValue().Equals(end.GetValue());
                }
            }

            return true;
        }
    }
}
