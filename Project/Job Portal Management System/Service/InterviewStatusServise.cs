using Job_Portal_Management_System.Models;
using Job_Portal_Management_System.Repository.Interfaces;
using Job_Portal_Management_System.Service.Interfaces;

namespace Job_Portal_Management_System.Service.Implementations
{
    public class InterviewStatusService
        : IInterviewStatusService
    {
        private readonly IInterviewStatusRepository repository;

        public InterviewStatusService(
            IInterviewStatusRepository repository)
        {
            this.repository = repository;
        }

        public List<InterviewStatus> GetAll()
        {
            return repository.GetAll();
        }

        public InterviewStatus? GetById(int id)
        {
            return repository.GetById(id);
        }

        public InterviewStatus?
            GetByApplicationId(int applicationId)
        {
            return repository.GetByApplicationId(
                applicationId);
        }

        public void Add(InterviewStatus interview)
        {
            repository.Add(interview);
        }

        public void Update(InterviewStatus interview)
        {
            repository.Update(interview);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}