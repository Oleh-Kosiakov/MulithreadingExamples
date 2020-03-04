using System;
using System.Threading;

namespace MultithreadingExamples
{
    class Program
    {
		[ThreadStatic] 
        private static string greeting = "Greetings from the current thread";

        public static void Main()
        {
            Console.WriteLine(greeting);

            greeting = "Goodbye from the main thread";

            var secondaryThread = new Thread(RunWithModification);
            secondaryThread.Start();
            secondaryThread.Join();

            Console.WriteLine(greeting);
        }

        private static void RunWithModification()
        {
            Console.WriteLine(greeting);
            greeting = "Hello from secondary thread";
            Console.WriteLine(greeting);
        }

	}
}
