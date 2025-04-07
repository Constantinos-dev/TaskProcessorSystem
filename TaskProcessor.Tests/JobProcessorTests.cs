using TaskProcessorSystem.Data;
using TaskProcessorSystem.Models;
using TaskProcessorSystem.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class JobProcessorService
{
    private readonly JobDbContext _context;

    public JobProcessorService(JobDbContext context)
    {
        _context = context;
    }

    public async Task ProcessPendingJobsAsync(CancellationToken cancellationToken)
    {
        try
        {            
            var pendingJobs = _context.Jobs.Where(j => j.Status == JobStatus.Pending).ToList();

            foreach (var job in pendingJobs)
            {                
                job.Status = JobStatus.Completed;
                job.CompletedAt = DateTime.UtcNow;
            }
                        
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {            
            Console.WriteLine($"Error processing jobs: {ex.Message}");
            throw;
        }
    }
}
