using System;
using System.Linq;
using System.Threading;

namespace Join
{
    class Program
    {
        private static Thread _mainThread;

		public static void Main()
        {
            _mainThread = Thread.CurrentThread;

            var myAwesomeThread = new Thread(ReallyLongCalculations)
            {
                IsBackground = false
            };
            myAwesomeThread.Start();

            // join current executing thread to continue only after myAwesomeThreads terminates
            myAwesomeThread.Join();

            Console.WriteLine("End");
        }

        private static void ReallyLongCalculations()
        {
            _mainThread.Join();

            foreach (var _ in Enumerable.Range(0, 10))
            {
                Console.WriteLine("Test");
                // block current executing thread for specific time span
                Thread.Sleep(TimeSpan.FromMilliseconds(100));
            }
        }
	}
}
