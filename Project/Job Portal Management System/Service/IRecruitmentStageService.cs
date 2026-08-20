using Job_Portal_Management_System.Models;

namespace Job_Portal_Management_System.Service.Interfaces
{
    public interface IRecruitmentStageService
    {
        List<RecruitmentStage> GetAll();

        RecruitmentStage? GetById(int id);

        RecruitmentStage? GetByName(string name);

        void Add(RecruitmentStage stage);

        void Update(RecruitmentStage stage);

        void Delete(int id);
    }
}