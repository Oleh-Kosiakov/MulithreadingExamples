using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCancellation
{
    class Program
    {
		static void Main()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            var task = Task.Factory.StartNew(Function(token)); // provide cancellation token as an additional argument

            tokenSource.Cancel();
            task.Wait();
        }

        private static Action Function(CancellationToken ct)
        {
            return () =>
            {
                try
                {
                    Task.Delay(TimeSpan.FromSeconds(1)).Wait();
                    // check if cancellation requested
                   // ct.ThrowIfCancellationRequested(); // will throw OperationCancelledException
                }
                catch (OperationCanceledException ex)
                {

                }
            };
        }
    }
}
