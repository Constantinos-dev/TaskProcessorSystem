using Microsoft.AspNetCore.Mvc;
using TaskProcessorSystem.Models;
using TaskProcessorSystem.Data;
using Microsoft.EntityFrameworkCore;
using System;

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
            try
            {
                _context.Jobs.Add(job);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetJobById), new { id = job.Id }, job);
            }
            catch (DbUpdateException dbEx)
            {
                
                return StatusCode(500, "A database error occurred while creating the job.");
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "An unexpected error occurred while creating the job.");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetJobs()
        {
            try
            {
                var jobs = await _context.Jobs.ToListAsync();
                return Ok(jobs);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "An error occurred while retrieving jobs.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetJobById(Guid id)
        {
            try
            {
                var job = await _context.Jobs.FindAsync(id);
                if (job == null)
                    return NotFound();

                return Ok(job);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "An error occurred while retrieving the job.");
            }
        }
    }
}