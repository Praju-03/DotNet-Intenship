using Job_Portal_Management_System.Models;

namespace Job_Portal_Management_System.Service.Interfaces
{
    public interface IApplicantService
    {
        List<Applicant> GetAll();

        Applicant? GetById(int id);

        Applicant? GetByEmail(string email);

        void Add(Applicant applicant);

        void Update(Applicant applicant);

        void Delete(int id);
    }
}