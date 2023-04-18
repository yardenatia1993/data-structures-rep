using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queue;

namespace Main.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> q = new Queue<int>();

            for (int i = 0; i < 10; i++)
            {
                q.Insert(i+1);
            }
            Console.WriteLine(q);

            Console.WriteLine("The first node is removed: " + q.Remove());
            Console.WriteLine(q);

            Console.WriteLine("The first node is : " + q.Head());
            Console.WriteLine(q);

            Console.WriteLine("Number Of Nodes=" + q.NumberOfNodes());
            Console.WriteLine(q);

            Console.WriteLine("Number Of Nodes=" + NumberOfNodes(q));
            Console.WriteLine(q);

            Console.WriteLine("Number Of Nodes=" + NumberOfNodes(q,-1));
            Console.WriteLine(q);
            Console.ReadKey();
        }

        public static int NumberOfNodes<T>(Queue<T> q)
        {
            int counter = 0;
            Queue<T> temp = new Queue<T>();

            while (!q.IsEmpty())
            {
                counter++;
                temp.Insert(q.Remove());
            }

            //restore q
            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }

            return counter;
        }

        public static int NumberOfNodes<T>(Queue<T> q, T dummy)
        {
            int counter = 0;
            q.Insert(dummy);

            while (!q.Head().Equals(dummy))
            {
                counter++;
                q.Insert(q.Remove());
            }

            //Remove dummy
            q.Remove();

            return counter;
        }
        public static Queue<T> DuplicateQueue<T>(Queue<T> q)
        {
            Queue<T> temp = q;
            return temp;
        }
    }
}
