using Job_Portal_Management_System.Models;
using Job_Portal_Management_System.Repository;
using Job_Portal_Management_System.Service.Interfaces;

namespace Job_Portal_Management_System.Service
{

        public class CompanyService : ICompanyService
        {
            private readonly ICompanyRepository repository;

            public CompanyService(ICompanyRepository repository)
            {
                this.repository = repository;
            }

            public List<Company> GetAll()
            {
                return repository.GetAll();
            }

            public Company? GetById(int id)
            {
                return repository.GetById(id);
            }

            public void Add(Company company)
            {
                repository.Add(company);
            }

            public void Update(Company company)
            {
                repository.Update(company);
            }

            public void Delete(int id)
            {
                repository.Delete(id);
            }
        }
    }
