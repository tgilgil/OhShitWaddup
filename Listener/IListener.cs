using System.Threading;
using System.Threading.Tasks;

namespace Listener
{
    public interface IListener
    {
        Task StartAsync();
        Task StopAsync();
    }
}
