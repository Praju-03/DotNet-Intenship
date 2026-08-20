using Job_Portal_Management_System.Models;

namespace Job_Portal_Management_System.Service.Interfaces
{
    public interface IJobApplicationService
    {
        List<JobApplication> GetAll();

        JobApplication? GetById(int id);

        List<JobApplication> GetByApplicantId(int applicantId);

        List<JobApplication> GetByJobId(int jobId);

        void Apply(JobApplication application);

        void Update(JobApplication application);

        void Delete(int id);
    }
}