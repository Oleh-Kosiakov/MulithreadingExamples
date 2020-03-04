using System;
using System.Threading;

namespace Lock
{
    class Program
    {
		static int number = 0;

        static object locker = new object();

        public static void Main()
        {
            var thread1 = new Thread(() => AddSafely(5));
            var thread2 = new Thread(() => AddSafely(10));

            thread1.Start();
            thread2.Start();
        }

        public static void AddSafely(int value)
        {
            lock (locker)
            {
                Add(value);
            }
        }

        public static void Add(int value)
        {
            var temp = number;

            // simulate some waiting process
            Thread.Sleep(TimeSpan.FromMilliseconds(1));

            number = temp + value;

            Console.WriteLine($"added {value} to {temp}, got {number}");
        }

    }
}
