using Job_Portal_Management_System.Data;
using Job_Portal_Management_System.Models;
using Job_Portal_Management_System.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Job_Portal_Management_System.Repository.Implementations
{
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext context;

        public JobRepository(AppDbContext context)
        {
            this.context = context;
        }

        // Get all jobs
        public List<Job> GetAll()
        {
            return context.Jobs
                .Include(j => j.Company)
                .ToList();
        }

        // Get job by ID
        public Job? GetById(int id)
        {
            return context.Jobs
                .Include(j => j.Company)
                .FirstOrDefault(j => j.JobId == id);
        }

        // Get jobs by company
        public List<Job> GetByCompanyId(int companyId)
        {
            return context.Jobs
                .Where(j => j.CompanyId == companyId)
                .ToList();
        }

        // Add job
        public void Add(Job job)
        {
            context.Jobs.Add(job);

            context.SaveChanges();
        }

        // Update job
        public void Update(Job job)
        {
            context.Jobs.Update(job);

            context.SaveChanges();
        }

        // Delete job
        public void Delete(int id)
        {
            var job = context.Jobs.Find(id);

            if (job != null)
            {
                context.Jobs.Remove(job);

                context.SaveChanges();
            }
        }
    }
}