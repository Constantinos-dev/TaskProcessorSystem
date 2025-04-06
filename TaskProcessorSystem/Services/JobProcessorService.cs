using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using TaskProcessorSystem.Data;
using TaskProcessorSystem.Models;

namespace TaskProcessorSystem.Services
{
    public class JobProcessorService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public JobProcessorService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<JobDbContext>();

                var job = await db.Jobs
                    .Where(j => j.Status == JobStatus.Pending && j.RetryCount < 3)
                    .OrderBy(j => j.CreatedAt)
                    .FirstOrDefaultAsync(stoppingToken);

                if (job != null)
                {
                    job.Status = JobStatus.Running;
                    await db.SaveChangesAsync();

                    try
                    {
                        await Task.Delay(2000); // Simulate execution

                        job.Status = JobStatus.Completed;
                        job.CompletedAt = DateTime.UtcNow;
                    }
                    catch (Exception ex)
                    {
                        job.RetryCount++;
                        job.Status = job.RetryCount >= 3 ? JobStatus.Failed : JobStatus.Pending;
                        job.ErrorMessage = ex.Message;
                    }

                    await db.SaveChangesAsync();
                }

                await Task.Delay(1000); // Wait before next polling
            }
        }
    }
}
