using Job_Portal_Management_System.Data;
using Job_Portal_Management_System.Models;
using Job_Portal_Management_System.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Job_Portal_Management_System.Repository.Implementations
{
    public class InterviewStatusRepository
        : IInterviewStatusRepository
    {
        private readonly AppDbContext context;

        public InterviewStatusRepository(
            AppDbContext context)
        {
            this.context = context;
        }

        // Get all interviews
        public List<InterviewStatus> GetAll()
        {
            return context.Interviews
                .Include(i => i.Application)
                .ToList();
        }

        // Get interview by ID
        public InterviewStatus? GetById(int id)
        {
            return context.Interviews
                .Include(i => i.Application)
                .FirstOrDefault(
                    i => i.InterviewId == id
                );
        }

        // Get interview by application
        public InterviewStatus?
            GetByApplicationId(int applicationId)
        {
            return context.Interviews
                .Include(i => i.Application)
                .FirstOrDefault(
                    i => i.ApplicationId == applicationId
                );
        }

        // Add interview
        public void Add(InterviewStatus interview)
        {
            context.Interviews.Add(interview);

            context.SaveChanges();
        }

        // Update interview
        public void Update(
            InterviewStatus interview)
        {
            context.Interviews.Update(interview);

            context.SaveChanges();
        }

        // Delete interview
        public void Delete(int id)
        {
            var interview =
                context.Interviews.Find(id);

            if (interview != null)
            {
                context.Interviews.Remove(interview);

                context.SaveChanges();
            }
        }
    }
}