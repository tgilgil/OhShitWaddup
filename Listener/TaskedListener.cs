using System;
using System.Threading;
using System.Threading.Tasks;

namespace Listener
{
    public class TaskedListener : IListener
    {
        private IListener _internalListener;

        public TaskedListener(IListener listener)
        {
            _internalListener = listener;
        }

        public async Task Start(CancellationToken cancellationToken)
        {
           try
            {
                do
                {
                    await _internalListener.Start(cancellationToken);
                    Thread.Sleep(5000);
                } while (!cancellationToken.CanBeCanceled);
            }
            catch
            {
                StopAll();
                //throw exception;
            }
        }

        public Task Stop()
        {
            throw new NotImplementedException();
        }

        private void StopAll()
        {
            throw new NotImplementedException("This stops everything pending.");
        }
    }
}
