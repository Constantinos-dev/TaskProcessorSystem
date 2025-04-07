using TaskProcessorSystem.Data;
using TaskProcessorSystem.Models;
using TaskProcessorSystem.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class JobProcessorTests
{
    private readonly JobDbContext _context;

    public JobProcessorTests()
    {
        var options = new DbContextOptionsBuilder<JobDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
        _context = new JobDbContext(options);
    }

    [Fact]
    public async Task ProcessPendingJobs_ShouldMarkJobCompleted_WhenSuccessful()
    {
        // Arrange
        var job = new Job
        {
            Id = Guid.NewGuid(),
            Type = "Test",
            PayloadJson = "{}",
            Status = JobStatus.Pending,
            CreatedAt = DateTime.UtcNow
        };
        _context.Jobs.Add(job);
        await _context.SaveChangesAsync();

        var processor = new JobProcessorService(null /* Add mock dependencies if required */);

        // Act
        await processor.ExecuteAsync(CancellationToken.None); // Adjust for your implementation

        // Assert
        var updatedJob = await _context.Jobs.FindAsync(job.Id);
        Assert.Equal(JobStatus.Completed, updatedJob.Status);
    }
}
