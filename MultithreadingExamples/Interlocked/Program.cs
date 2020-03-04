using System;
using System.Threading;

namespace Interlocked
{
    class Program
    {
        public static int result = 0;

        public static void Main()
        {
            var threadA = new Thread(ThreadA);
            var threadB = new Thread(ThreadB);

            threadA.Start();
            threadB.Start();

            threadA.Join();
            threadB.Join();

            Console.WriteLine(result);
        }

        private static void ThreadA()
        {
            for (int i = 1; i <= 100000; i++)
            {
                System.Threading.Interlocked.Increment(ref result);
               //result++;
            }
        }

        private static void ThreadB()
        {
            for (int i = 1; i <= 100000; i++)
            {
                System.Threading.Interlocked.Increment(ref result);
                //result++;
            }
        }
    }
}
