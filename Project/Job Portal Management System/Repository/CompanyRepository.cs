using Job_Portal_Management_System.Data;
using Job_Portal_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Job_Portal_Management_System.Repository.Implementations
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext context;

        public CompanyRepository(AppDbContext context)
        {
            this.context = context;
        }

        // Get all companies
        public List<Company> GetAll()
        {
            return context.Companies
                .Include(c => c.Jobs)
                .ToList();
        }

        // Get company by ID
        public Company? GetById(int id)
        {
            return context.Companies
                .Include(c => c.Jobs)
                .FirstOrDefault(c => c.CompanyId == id);
        }

        // Add company
        public void Add(Company company)
        {
            context.Companies.Add(company);
            context.SaveChanges();
        }

        // Update company
        public void Update(Company company)
        {
            context.Companies.Update(company);
            context.SaveChanges();
        }

        // Delete company
        public void Delete(int id)
        {
            var company = context.Companies.Find(id);

            if (company != null)
            {
                context.Companies.Remove(company);
                context.SaveChanges();
            }
        }
    }
}