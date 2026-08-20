using Job_Portal_Management_System.Data;
using Job_Portal_Management_System.Models;
using Job_Portal_Management_System.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Job_Portal_Management_System.Repository.Implementations
{
    public class JobApplicationRepository
        : IJobApplicationRepository
    {
        private readonly AppDbContext context;

        public JobApplicationRepository(
            AppDbContext context)
        {
            this.context = context;
        }

        // Get all applications
        public List<JobApplication> GetAll()
        {
            return context.JobApplications
                .Include(a => a.Applicant)
                .Include(a => a.Jobs)
                .ToList();
        }

        // Get application by ID
        public JobApplication? GetById(int id)
        {
            return context.JobApplications
                .Include(a => a.Applicant)
                .Include(a => a.Jobs)
                .FirstOrDefault(
                    a => a.ApplicationId == id
                );
        }

        // Get applications of an applicant
        public List<JobApplication> GetByApplicantId(
            int applicantId)
        {
            return context.JobApplications
                .Include(a => a.Jobs)
                .Where(
                    a => a.ApplicantId == applicantId
                )
                .ToList();
        }

        // Get applications for a job
        public List<JobApplication> GetByJobId(
            int jobId)
        {
            return context.JobApplications
                .Include(a => a.Applicant)
                .Where(
                    a => a.JobId == jobId
                )
                .ToList();
        }

        // Check duplicate application
        public bool HasApplied(
            int applicantId,
            int jobId)
        {
            return context.JobApplications.Any(
                a => a.ApplicantId == applicantId
                && a.JobId == jobId
            );
        }

        // Add application
        public void Add(
            JobApplication application)
        {
            context.JobApplications.Add(application);

            context.SaveChanges();
        }

        // Update application
        public void Update(
            JobApplication application)
        {
            context.JobApplications.Update(application);

            context.SaveChanges();
        }

        // Delete application
        public void Delete(int id)
        {
            var application =
                context.JobApplications.Find(id);

            if (application != null)
            {
                context.JobApplications.Remove(
                    application
                );

                context.SaveChanges();
            }
        }
    }
}