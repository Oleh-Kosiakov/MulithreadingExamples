using System;
using System.Threading;

namespace Volatile
{
    //Launch in debug mode, then release mode, add volatile
    class Program
    {
        private static int foo; // Disables variable L1 CPU caching. 

        public static void Main()
        {
            new Thread(() =>
            {
                Thread.Sleep(500);
                foo = 255;

            }).Start();

            while (foo != 255)
            {
            }


            Console.WriteLine("OK");
        }

    }
}
