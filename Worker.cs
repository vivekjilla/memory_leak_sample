namespace MemoryLeakSample
{
    public class Worker
    {
        private readonly CancellationTokenSource _globalCancellationTokenSource = new();

        public void DoWork(bool useDispose = false)
        {
            // Create a new token that combines the internal and external tokens.
            var internalToken = new CancellationTokenSource().Token;

            var cts = CancellationTokenSource.CreateLinkedTokenSource(internalToken, _globalCancellationTokenSource.Token);
            if (useDispose)
            {
                cts.Dispose();
            }
        }
    }
}