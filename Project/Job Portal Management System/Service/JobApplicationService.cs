using Job_Portal_Management_System.Models;
using Job_Portal_Management_System.Repository.Interfaces;
using Job_Portal_Management_System.Service.Interfaces;

namespace Job_Portal_Management_System.Service.Implementations
{
    public class JobApplicationService
        : IJobApplicationService
    {
        private readonly IJobApplicationRepository repository;

        public JobApplicationService(
            IJobApplicationRepository repository)
        {
            this.repository = repository;
        }

        public List<JobApplication> GetAll()
        {
            return repository.GetAll();
        }

        public JobApplication? GetById(int id)
        {
            return repository.GetById(id);
        }

        public List<JobApplication> GetByApplicantId(
            int applicantId)
        {
            return repository.GetByApplicantId(
                applicantId);
        }

        public List<JobApplication> GetByJobId(
            int jobId)
        {
            return repository.GetByJobId(jobId);
        }

        public void Apply(JobApplication application)
        {
            bool alreadyApplied =
                repository.HasApplied(
                    application.ApplicantId,
                    application.JobId);

            if (alreadyApplied)
            {
                throw new Exception(
                    "Applicant has already applied for this job."
                );
            }

            repository.Add(application);
        }

        public void Update(JobApplication application)
        {
            repository.Update(application);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}
