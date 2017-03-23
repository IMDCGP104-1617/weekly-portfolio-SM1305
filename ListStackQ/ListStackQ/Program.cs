using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListStackQ
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Tests for List 
            List<int> list = new List<int>();

            list.InsertBeginning(10);

            list.InsertAfter(99, 10);

            list.RemoveBeginning();

            list.RemoveAfter(11);

            Console.WriteLine(list.Count);
            #endregion

            #region Tests for Stack
            Stack<int> stack = new Stack<int>();
            stack.Push(35);
            stack.Push(28);
            stack.Push(21);
            stack.Push(14);
            stack.Push(7);
            while (!stack.IsEmpty())
            {
                int output;
                stack.Pop(out output);
                Console.WriteLine(output);
            }
            #endregion

            #region Tests for Queue
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(11);
            queue.Enqueue(22);
            queue.Enqueue(33);
            queue.Enqueue(44);

            while (!queue.IsEmpty())
            {
                int output;
                queue.Dequeue(out output);
                Console.WriteLine(output);
            }
            #endregion
        }
    }
}