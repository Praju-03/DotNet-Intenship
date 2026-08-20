using Job_Portal_Management_System.Models;
using Job_Portal_Management_System.Repository.Interfaces;
using Job_Portal_Management_System.Service.Interfaces;

namespace Job_Portal_Management_System.Service.Implementations
{
    public class RecruitmentStageService
        : IRecruitmentStageService
    {
        private readonly IRecruitmentStageRepository repository;

        public RecruitmentStageService(
            IRecruitmentStageRepository repository)
        {
            this.repository = repository;
        }

        public List<RecruitmentStage> GetAll()
        {
            return repository.GetAll();
        }

        public RecruitmentStage? GetById(int id)
        {
            return repository.GetById(id);
        }

        public RecruitmentStage? GetByName(string name)
        {
            return repository.GetByName(name);
        }

        public void Add(RecruitmentStage stage)
        {
            repository.Add(stage);
        }

        public void Update(RecruitmentStage stage)
        {
            repository.Update(stage);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}