using System.Collections.Concurrent;

namespace PhoneService.Api.Services
{
    public class SemaphoreService
    {
        private readonly SemaphoreSlim _semaphore;
        private ConcurrentBag<Task> _tasks;
        private ConcurrentDictionary<Guid, object> _taskResult;

        private int semaphoreCount;

        public SemaphoreService()
        {
            _semaphore = new SemaphoreSlim(0, 10);
            _tasks = new ConcurrentBag<Task>();
            _taskResult = new ConcurrentDictionary<Guid, object>();
        }

        public void AddTask(Task task) 
        { 
            _tasks.Add(task);
        }

        public object? GetTaskResult(Guid traceId) 
        {
            var result = new object();
            var timeStartSerch = DateTime.UtcNow;
            var timeLimit = TimeSpan.FromSeconds(5);

            while(!_taskResult.TryGetValue(traceId, out var resultTask) || DateTime.UtcNow - timeStartSerch < timeLimit)
            {
                result = resultTask;
            }

            return result;
        }
    }
}
