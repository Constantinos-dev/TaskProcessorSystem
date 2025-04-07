using Microsoft.EntityFrameworkCore;
using TaskProcessorSystem.Models;

namespace TaskProcessorSystem.Data
{
    public class JobDbContext : DbContext
    {
        public JobDbContext(DbContextOptions<JobDbContext> options) : base(options) { }

        public DbSet<Job> Jobs { get; set; }
    }
}