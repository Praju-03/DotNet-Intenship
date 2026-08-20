using Job_Portal_Management_System.Models;

namespace Job_Portal_Management_System.Service.Interfaces
{
    public interface ICompanyService
    {
        List<Company> GetAll();

        Company? GetById(int id);

        void Add(Company company);

        void Update(Company company);

        void Delete(int id);
    }
}