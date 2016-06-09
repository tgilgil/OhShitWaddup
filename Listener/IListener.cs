using System.Threading;
using System.Threading.Tasks;

namespace Listener
{
    public interface IListener
    {
        Task Start(CancellationToken cancellationToken);
        Task Stop();
    }
}
