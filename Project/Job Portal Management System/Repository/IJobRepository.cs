using Job_Portal_Management_System.Models;

namespace Job_Portal_Management_System.Repository.Interfaces
{
    public interface IJobRepository
    {
        List<Job> GetAll();

        Job? GetById(int id);

        List<Job> GetByCompanyId(int companyId);

        void Add(Job job);

        void Update(Job job);

        void Delete(int id);
    }
}