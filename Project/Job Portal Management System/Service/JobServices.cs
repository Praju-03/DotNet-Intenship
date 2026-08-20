using Job_Portal_Management_System.Models;
using Job_Portal_Management_System.Repository.Interfaces;
using Job_Portal_Management_System.Service.Interfaces;

namespace Job_Portal_Management_System.Service.Implementations
{
    public class JobService : IJobService
    {
        private readonly IJobRepository repository;

        public JobService(IJobRepository repository)
        {
            this.repository = repository;
        }

        public List<Job> GetAll()
        {
            return repository.GetAll();
        }

        public Job? GetById(int id)
        {
            return repository.GetById(id);
        }

        public List<Job> GetByCompanyId(int companyId)
        {
            return repository.GetByCompanyId(companyId);
        }

        public void Add(Job job)
        {
            repository.Add(job);
        }

        public void Update(Job job)
        {
            repository.Update(job);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

    }
}