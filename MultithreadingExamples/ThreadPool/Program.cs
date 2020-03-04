using System;
using System.Threading;

namespace ThreadPool
{
    class Program
    {
		static void Main(string[] args)
        {
            // queue the task
            System.Threading.ThreadPool.QueueUserWorkItem(ThreadProc);

            Console.WriteLine("Main thread does some work, then sleeps.");

            // block current thread to be sure that thread poll thread will complete the execution
            Thread.Sleep(TimeSpan.FromMilliseconds(1000));

            Console.WriteLine("Main thread exits.");
        }

        // this thread procedure performs the task
        static void ThreadProc(object stateInfo)
        {
            Console.WriteLine("Hello from the thread pool.");
        }

	}
}
