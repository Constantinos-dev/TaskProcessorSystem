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
    }
}
