using Reddit;
using System;
using System.Diagnostics;
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
            Stopwatch s = Stopwatch.StartNew();

            var comments = await _repository.Get();

            Parallel.ForEach(comments, (comment) =>
            {
                if (_ohShitWaddupDetector.IsWorthyOhShitWaddup(comment.Body))
                    Console.WriteLine($"[{comment.Body}] by [{comment.Author}]");
            });

            s.Stop();

            Console.WriteLine($"Comments analyzed ({s.ElapsedMilliseconds} ms).");
        }

        public Task StopAsync()
        {
            throw new NotImplementedException();
        }
    }
}
