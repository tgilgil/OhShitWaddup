using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reddit
{
    public interface ICommentsRepository
    {
        Task<IEnumerable<Comment>> Get();
        void Post(Reply reply);
    }
}
