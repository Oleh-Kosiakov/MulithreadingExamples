using System;
using System.Threading.Tasks;

namespace RunTaskConsole
{
    class Program
    {
		static void SayHello()
        {
            Console.WriteLine($"Hello from task #{Task.CurrentId}");
        }

        static void Main()
        {
            // use task constructor and then run the task manually
            var manualTask = new Task(SayHello);
            manualTask.Start();

            // instantiate and run in one step
            var selfstartedTask = Task.Run(SayHello);

            // instantiate and run in one step
            var factoryTask = Task.Factory.StartNew(SayHello);

            Console.ReadKey();
        }

	}
}
