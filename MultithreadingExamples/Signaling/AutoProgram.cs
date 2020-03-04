using System;
using System.Threading;

namespace Signaling
{
    public class AutoProgram
    {
        private static AutoResetEvent resetEvent = new AutoResetEvent(false); // argument is for initial state

        public static void Main(string[] args)
        {
            // queue the task
            ThreadPool.QueueUserWorkItem(ThreadProc);

            Console.WriteLine("Main thread does some work, then waits.");

            // wait until thread-pool thread will set the signal
            resetEvent.WaitOne();

            Console.WriteLine("Main thread continues.");

            ThreadPool.QueueUserWorkItem(ThreadProc);

            resetEvent.WaitOne();

            Console.WriteLine("Main thread exits.");
        }

        // this thread procedure performs the task.
        static void ThreadProc(object stateInfo)
        {
            Console.WriteLine("Hello from the thread pool.");

            // set the signal
            resetEvent.Set();
        }
    }
}