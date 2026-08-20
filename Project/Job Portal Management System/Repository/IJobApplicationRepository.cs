using Job_Portal_Management_System.Models;

namespace Job_Portal_Management_System.Repository.Interfaces
{
    public interface IJobApplicationRepository
    {
        List<JobApplication> GetAll();

        JobApplication? GetById(int id);

        List<JobApplication> GetByApplicantId(int applicantId);

        List<JobApplication> GetByJobId(int jobId);

        bool HasApplied(int applicantId, int jobId);

        void Add(JobApplication application);

        void Update(JobApplication application);

        void Delete(int id);
    }
}