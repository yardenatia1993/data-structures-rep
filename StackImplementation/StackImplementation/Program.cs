using System;
using System.Collections.Generic;

namespace StackImplementation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(args);
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine("Stack contents: " + stack.ToString());

            int poppedValue = stack.Pop();
            Console.WriteLine("Popped value: " + poppedValue);
            Console.WriteLine("Stack contents after pop: " + stack.ToString());

            int topValue = stack.Top();
            Console.WriteLine("Top value: " + topValue);

           int stackCount = stack.Count();
           Console.WriteLine("Stack count: " + stackCount);
            //TODO
/*Write a internal func to count the elemets in stack(is the method generic or not?)
 * print revarse
 */
            Console.ReadKey();
        }

        public int CountValueOccurrencesInStack(Stack<int> stack, int value)
        {
            int count = 0;
            Stack<int> tempStack = stack;

            while (tempStack.Count() > 0)
            {
                int temp = tempStack.Pop();
                if (temp == value)
                {
                    count++;
                }
            }

            return count;
        }


    }
}
