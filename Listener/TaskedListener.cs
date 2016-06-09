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

        public async Task StartAsync()
        {
           try
            {
                do
                {
                    await _internalListener.StartAsync();
                    Thread.Sleep(5000);
                } while (true);
            }
            catch
            {
                StopAllAsync();
                //throw exception;
            }
        }

        public Task StopAsync()
        {
            throw new NotImplementedException();
        }

        private Task StopAllAsync()
        {
            throw new NotImplementedException("This stops everything pending.");
        }
    }
}
