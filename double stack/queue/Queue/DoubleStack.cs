using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stack;

namespace Queue
{
    class DoubleStack<T>
    {
        public Stack<int> firstStack { get; set; }
        public Stack<int> secStack { get; set; }
        Random random = new Random();
        public DoubleStack(int randomNumbers, int from, int to)
        {
            firstStack = new Stack<int>();
            secStack = new Stack<int>();
            int randomN = 0;
            int randomStackLocation = 1;
            for (int i = 0; i < randomNumbers; i++)
            {
                randomN = random.Next(from, to);
                randomStackLocation = random.Next(1, 3);
                if (randomStackLocation == 1)
                {
                    firstStack.Push(randomN);
                }
                else
                {
                    secStack.Push(randomN);
                }


            }
        }
        public int NumElements(int stackID)
        {
            //1 for first 2 for sec
            return stackID == 1 ? firstStack.NumberOfItems() : secStack.NumberOfItems();
        }
        public void Move(int stackID)
        {
            if (stackID == 1)
            {
                firstStack.Push(secStack.Pop());
            }
            else
            {
                secStack.Push(firstStack.Pop());
            }

        }
        public void MoveMin(int num)
        {
            Stack<int> source;
            Stack<int> target;
            Stack<int> temp = new Stack<int>();

            if (num == 1)
            {
                source = firstStack;
                target = secStack;
            }
            else
            {
                source = secStack;
                target = firstStack;
            }

            int minValue = source.Top();
            while (source.NumberOfItems() > 0)
            {
                int value = source.Pop();
                if (value < minValue)
                {
                    minValue = value;
                }
                temp.Push(value);
            }

            bool minMoved = false;
            while (temp.NumberOfItems() > 0)
            {
                int value = temp.Pop();
                if (!minMoved && value == minValue)
                {
                    target.Push(value);
                    minMoved = true;
                }
                else
                {
                    source.Push(value);
                }
            }
        }
    }
}
