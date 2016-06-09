using Reddit;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Listener
{
    public class RedditListener : IListener
    {
        private CommentsRepository _repository;
        private OhShitWaddupDetector _ohShitWaddupDetector;

        public RedditListener(CommentsRepository repository)
        {
            _repository = repository;
            _ohShitWaddupDetector = new OhShitWaddupDetector();
        }

        public async Task StartAsync()
        {
            var comments = await _repository.Get();

            foreach (var comment in comments)
            {
                if (_ohShitWaddupDetector.IsWorthyOhShitWaddup(comment.Body))
                    Console.WriteLine($"[{comment.Body}] by [{comment.Author}]");
            }

            Console.WriteLine("Comments analyzed.");
        }

        public Task StopAsync()
        {
            throw new NotImplementedException();
        }
    }
}
