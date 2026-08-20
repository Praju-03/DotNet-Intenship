using Job_Portal_Management_System.Data;
using Job_Portal_Management_System.Models;
using Job_Portal_Management_System.Repository.Interfaces;

namespace Job_Portal_Management_System.Repository.Implementations
{
    public class RecruitmentStageRepository
        : IRecruitmentStageRepository
    {
        private readonly AppDbContext context;

        public RecruitmentStageRepository(
            AppDbContext context)
        {
            this.context = context;
        }

        // Get all recruitment stages
        public List<RecruitmentStage> GetAll()
        {
            return context.RecruitmentStages
                .OrderBy(s => s.StageOrder)
                .ToList();
        }

        // Get stage by ID
        public RecruitmentStage? GetById(int id)
        {
            return context.RecruitmentStages
                .FirstOrDefault(
                    s => s.RecruitmentStageId == id
                );
        }

        // Get stage by name
        public RecruitmentStage?
            GetByName(string name)
        {
            return context.RecruitmentStages
                .FirstOrDefault(
                    s => s.StageName == name
                );
        }

        // Add stage
        public void Add(
            RecruitmentStage stage)
        {
            context.RecruitmentStages.Add(stage);

            context.SaveChanges();
        }

        // Update stage
        public void Update(
            RecruitmentStage stage)
        {
            context.RecruitmentStages.Update(stage);

            context.SaveChanges();
        }

        // Delete stage
        public void Delete(int id)
        {
            var stage =
                context.RecruitmentStages.Find(id);

            if (stage != null)
            {
                context.RecruitmentStages.Remove(stage);

                context.SaveChanges();
            }
        }
    }
}