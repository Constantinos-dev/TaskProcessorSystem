using System;

namespace TaskProcessorSystem.Models
{
    public enum JobStatus
    {
        Pending,
        Running,
        Completed,
        Failed
    }

    public class Job
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Unique identifier
        public string Type { get; set; } // Type of job
        public string PayloadJson { get; set; }          // Task data in JSON
        public JobStatus Status { get; set; } = JobStatus.Pending;
        public int RetryCount { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
