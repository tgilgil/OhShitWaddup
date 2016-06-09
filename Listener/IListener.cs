using System.Threading.Tasks;

namespace Listener
{
    public interface IListener
    {
        Task Start();
        Task Stop();
    }
}
