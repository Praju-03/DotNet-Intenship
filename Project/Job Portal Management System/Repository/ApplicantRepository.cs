using Job_Portal_Management_System.Data;
using Job_Portal_Management_System.Models;
using Job_Portal_Management_System.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Job_Portal_Management_System.Repository.Implementations
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly AppDbContext context;

        public ApplicantRepository(AppDbContext context)
        {
            this.context = context;
        }

        // Get all applicants
        public List<Applicant> GetAll()
        {
            return context.Applicants
                .Include(a => a.Applications)
                .ToList();
        }

        // Get applicant by ID
        public Applicant? GetById(int id)
        {
            return context.Applicants
                .Include(a => a.Applications)
                .FirstOrDefault(a => a.ApplicantId == id);
        }

        // Get applicant by email
        public Applicant? GetByEmail(string email)
        {
            return context.Applicants
                .FirstOrDefault(a => a.Email == email);
        }

        // Add applicant
        public void Add(Applicant applicant)
        {
            context.Applicants.Add(applicant);

            context.SaveChanges();
        }

        // Update applicant
        public void Update(Applicant applicant)
        {
            context.Applicants.Update(applicant);

            context.SaveChanges();
        }

        // Delete applicant
        public void Delete(int id)
        {
            var applicant = context.Applicants.Find(id);

            if (applicant != null)
            {
                context.Applicants.Remove(applicant);

                context.SaveChanges();
            }
        }
    }
}