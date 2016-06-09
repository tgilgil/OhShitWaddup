using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reddit
{
    public interface ICommentsRepository
    {
        /// <summary>
        /// Get all comments from /r/all
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Comment>> Get();

        /// <summary>
        /// Post a reply
        /// </summary>
        /// <param name="comment"></param>
        void Post(Reply reply);
    }
}
