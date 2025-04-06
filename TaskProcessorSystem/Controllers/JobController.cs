using Microsoft.AspNetCore.Mvc;
using TaskProcessorSystem.Models;
using TaskProcessorSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace TaskProcessorSystem.Controllers
{
    [ApiController]
    [Route("jobs")]
    public class JobController : ControllerBase
    {
        private readonly JobDbContext _context;

        public JobController(JobDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Job>> CreateJob(Job job)
        {
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetJobById), new { id = job.Id }, job);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetJobs()
        {
            return await _context.Jobs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetJobById(Guid id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null) return NotFound();
            return job;
        }
    }
}