using Job_Portal_Management_System.Models;
using Job_Portal_Management_System.Repository.Interfaces;
using Job_Portal_Management_System.Service.Interfaces;

namespace Job_Portal_Management_System.Service.Implementations
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository repository;

        public ApplicantService(IApplicantRepository repository)
        {
            this.repository = repository;
        }

        public List<Applicant> GetAll()
        {
            return repository.GetAll();
        }

        public Applicant? GetById(int id)
        {
            return repository.GetById(id);
        }

        public Applicant? GetByEmail(string email)
        {
            return repository.GetByEmail(email);
        }

        public void Add(Applicant applicant)
        {
            repository.Add(applicant);
        }

        public void Update(Applicant applicant)
        {
            repository.Update(applicant);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}