using System;
using System.Threading;

namespace Lock
{
    public class BadProgram
    {
		static int number = 0;

        //void Main()
        //{
        //    var thread1 = new Thread(() => Add(5));
        //    var thread2 = new Thread(() => Add(10));

        //    thread1.Start();
        //    thread2.Start();
        //}

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