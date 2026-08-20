using Job_Portal_Management_System.Models;

namespace Job_Portal_Management_System.Service.Interfaces
{
    public interface IInterviewStatusService
    {
        List<InterviewStatus> GetAll();

        InterviewStatus? GetById(int id);

        InterviewStatus? GetByApplicationId(
            int applicationId);

        void Add(InterviewStatus interview);

        void Update(InterviewStatus interview);

        void Delete(int id);
    }
}