using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Queue;
using Stack;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
/*            Queue<int> q = new Queue<int>();

            for (int i = 0; i < 10; i++)
            {
                q.Insert(i + 1);
            }

            Console.WriteLine(q);
            Console.WriteLine("q.IsEmpty()=" + q.IsEmpty());

            Console.WriteLine("q.Remove()=" + q.Remove());
            Console.WriteLine(q);

            Console.WriteLine("q.Head()=" + q.Head());
            Console.WriteLine(q);

            Console.WriteLine("q.NumberOfItems()=" + q.NumberOfItems());

            Console.WriteLine("NumberOfItems(q)=" + NumberOfItems(q));
            Console.WriteLine(q);

            Console.WriteLine("NumberOfItems<int>(q, -1)=" + NumberOfItems<int>(q, -1));
            Console.WriteLine(q);

            Console.WriteLine("IsExist(q, 1)=" + IsExist(q, 1));//false
            Console.WriteLine("IsExist(q, 2)=" + IsExist(q, 2));//true

            Console.WriteLine("*****************DuplicateQueue*****************");
            Queue<int> newQueue = DuplicateQueue(q);
            Console.WriteLine("q=" + q);
            Console.WriteLine("newQueue=" + newQueue);

            Console.WriteLine("*****************IsAscOrderQueue*****************");
            Console.WriteLine("q=" + q);
            Console.WriteLine("IsAscOrderQueue(q)=" + IsAscOrderQueue(q));

            Console.WriteLine("*****************SumOfQueue*****************");
            Console.WriteLine(SumOfQueue(q));
            Console.WriteLine(q);

            Console.WriteLine("*****************ReverseQueueRec*****************");
            ReverseQueueRec(q);
            Console.WriteLine(q);

            Console.WriteLine("*****************ReverseQueueUsingStack*****************");
            ReverseQueueUsingStack(q);
            Console.WriteLine(q);

            Console.WriteLine("*****************ReverseQueueUsing2Queues*****************");
            ReverseQueueUsing2Queues(ref q);
            Console.WriteLine(q);*/
            Stack<int> st = new Stack<int>();
            st.Push(2);
            st.Push(3);
            st.Push(4);
            st.Push(6);
            st.Push(1);
            st.Push(5);
            //Console.WriteLine(DoubleStack<int>.MinVal(st));
            Console.WriteLine(IsUniqStack(st));
            Console.WriteLine(IsUniqStackOrderd(st));
            DoubleStack<int> db=new DoubleStack<int>(12,1,16);
            Console.WriteLine(db.firstStack.ToString());
            Console.WriteLine(db.secStack.ToString());
            Console.WriteLine(db.NumElements(1));
            Console.WriteLine(db.NumElements(2));
            db.Move(1);
            Console.WriteLine($"first stack :{db.firstStack.ToString()},sec stack:{db.secStack.ToString()}");
            Console.ReadKey();
        }
        public static bool IsUniqStack(Stack<int> stack)
        {
            if (stack.IsEmpty())
            {
                return true;
            }
            Stack<int> tempA = new Stack<int>(stack);
            Stack<int> tempB = new Stack<int>(stack);
            int current = 0;
            while (!tempA.IsEmpty())
            {

                current = tempA.Pop();
                tempB.Pop();
                while (!tempB.IsEmpty())
                {
                    if (tempB.Pop() == current)
                    {
                        return false;
                    }
                }
                tempB = new Stack<int>(tempA);
            }
            return true;
        }
        public static bool IsUniqStackOrderd(Stack<int> stack)
        {
            if (stack.IsEmpty())
            {
                return true;
            }
            Stack<int> temp = new Stack<int>(stack);
            int current = temp.Pop();
            while (!temp.IsEmpty())
            {


                if (current == temp.Top())
                {
                    return false;
                }
                current = temp.Pop();

            }
            return true;
        }
        public static void SortDoubleStack<T>(DoubleStack<T> ds)
        {
            for (int i = 1; i <= 2; i++)
            {
                while (ds.NumElements(i) > 0)
                {
                    ds.MoveMin(i);
                }
            }
        }
        public static Queue<int> GetDuplicateElements(Queue<int> inputQueue)
        {
            Queue<int> tempQueue = new Queue<int>(inputQueue);
            Queue<int> resultQueue = new Queue<int>();

            while (inputQueue.NumberOfItems() > 0)
            {
                int currentValue = inputQueue.Remove();
                bool isDuplicate = false;
                bool alreadyAdded = false;

                int tempQueueSize = tempQueue.NumberOfItems();
                for (int i = 0; i < tempQueueSize; i++)
                {
                    int value = tempQueue.Remove();
                    if (value == currentValue)
                    {
                        if (isDuplicate)
                        {
                            alreadyAdded = true;
                        }
                        isDuplicate = true;
                    }
                    tempQueue.Insert(value);
                }

                if (isDuplicate && !alreadyAdded)
                {
                    resultQueue.Insert(currentValue);
                }

                tempQueue.Insert(currentValue);
            }

            return resultQueue;
        }
        public static int NumberOfItems<T>(Queue<T> q)
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

        public static int NumberOfItems<T>(Queue<T> q, T dummy)
        {
            int counter = 0;
            q.Insert(dummy);

            while (!q.Head().Equals(dummy))
            {
                counter++;
                q.Insert(q.Remove());
            }
            q.Remove();

            return counter;
        }

        public static bool IsExist<T>(Queue<T> q, T x)
        {
            Queue<T> temp = new Queue<T>();
            bool found = false;

            while (!q.IsEmpty())
            {
                if (q.Head().Equals(x))
                {
                    found = true;
                }

                temp.Insert(q.Remove());
            }

            //restore queue
            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }

            return found;
        }

        public static Stack<T> DuplicateStack<T>(Stack<T> stack)
        {
            Stack<T> s1 = new Stack<T>();
            Stack<T> s2 = new Stack<T>();

            while (!stack.IsEmpty())
            {
                s1.Push(stack.Pop());
            }

            while (!s1.IsEmpty())
            {
                stack.Push(s1.Top());
                s2.Push(s1.Pop());
            }

            return s2;
        }

        public static Queue<T> DuplicateQueue<T>(Queue<T> q)
        {
            Queue<T> q1 = new Queue<T>();
            Queue<T> q2 = new Queue<T>();

            while (!q.IsEmpty())
            {
                q1.Insert(q.Remove());
            }

            while (!q1.IsEmpty())
            {
                q.Insert(q1.Head());
                q2.Insert(q1.Remove());
            }

            return q2;
        }

        public static bool IsAscOrderQueue(Queue<int> q)
        {
            Queue<int> temp = DuplicateQueue(q);

            int first = temp.Remove();

            while (!temp.IsEmpty())
            {
                int second = temp.Remove();
                if (second < first)
                {
                    return false;
                }
                first = second;
            }

            return true;
        }

        public static int SumOfQueue(Queue<int> q)
        {
            Queue<int> temp = new Queue<int>();
            int sum = 0;

            while (!q.IsEmpty())
            {
                sum += q.Head();

                temp.Insert(q.Remove());
            }

            //restore queue
            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }

            return sum;
        }

        public static void ReverseQueueRec<T>(Queue<T> q)
        {
            if (q.IsEmpty())
            {
                return;
            }

            T x = q.Remove();
            ReverseQueueRec(q);
            q.Insert(x);
        }

        public static void ReverseQueueUsingStack<T>(Queue<T> q)
        {
            Stack<T> stack = new Stack<T>();

            while (!q.IsEmpty())
            {
                stack.Push(q.Remove());
            }

            while (!stack.IsEmpty())
            {
                q.Insert(stack.Pop());
            }
        }

        public static void ReverseQueueUsing2Queues<T>(ref Queue<T> q)
        {
            Queue<T> q1 = new Queue<T>();
            Queue<T> q2 = new Queue<T>();

            while (!q.IsEmpty())
            {
                while (!q1.IsEmpty())
                {
                    q2.Insert(q1.Remove());
                }

                q1.Insert(q.Remove());

                while (!q2.IsEmpty())
                {
                    q1.Insert(q2.Remove());
                }
            }

            q = q1;
        }
    }
}