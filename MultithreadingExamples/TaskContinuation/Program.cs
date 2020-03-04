using System;
using System.Threading.Tasks;

namespace TaskContinuation
{
    class Program
    {
		static void Main()
        {
            // continue current task with another task
            // continuation will execute only if task has been successfully completed 
            var task = Task.Run(() =>
                {
                    throw new Exception();

                    Console.Write("Do..");
                })
                .ContinueWith(
                    _ => Console.WriteLine(".. or DIE!"),
                    TaskContinuationOptions.OnlyOnFaulted);

            task.Wait();
        }

	}
}
