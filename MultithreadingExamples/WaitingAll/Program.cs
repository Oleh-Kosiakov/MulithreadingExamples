using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WaitingAll
{
    class Program
    {
		static int messageIndex = 0;
        static string GetGreeting()
        {
            System.Threading.Interlocked.Increment(ref messageIndex);

            return $"Hello #{messageIndex}";
        }

        static void Main()
        {
            // get 10 greeting tasks
            var tasks = 
                new List<int>
                    {
                        0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20
                    }
                .Select(_ => Task.Factory.StartNew(GetGreeting, TaskCreationOptions.PreferFairness)).ToList();

            // wait until tasks complete
            Task.WhenAll(tasks).Wait();

            foreach (var task in tasks)
            {
                Console.WriteLine(task.Result);
            }
        }
	}
}
