using Job_Portal_Management_System.Models;
using System.Runtime.InteropServices;

namespace Job_Portal_Management_System.Repository
{
    public interface ICompanyRepository
    {
        List<Company> GetAll();
        Company ? GetById(int Id);
        void Add(Company company);
        void Update(Company company);
        void Delete(int Id );
    }
}
