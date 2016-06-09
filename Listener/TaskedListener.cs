using System;
using System.Threading;
using System.Threading.Tasks;

namespace Listener
{
    public class TaskedListener : IListener
    {
        private IListener _internalListener;
        private Action<Exception> _log;

        public TaskedListener(IListener listener, Action<Exception> log)
        {
            _internalListener = listener;
            _log = log;
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
            catch (Exception e)
            {
                _log(e);
            }
            finally
            {
                await StopAllAsync();
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
