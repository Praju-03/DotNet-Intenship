using Job_Portal_Management_System.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Job_Portal_Management_System.Data
{
    public class AppDbContext
        : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(
            DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Applicant> Applicants { get; set; }

        public DbSet<JobApplication> JobApplications { get; set; }

        public DbSet<InterviewStatus> Interviews { get; set; }

        public DbSet<RecruitmentStage> RecruitmentStages
        {
            get;
            set;
        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Job>()
                .HasOne(j => j.Company)
                .WithMany(c => c.Jobs)
                .HasForeignKey(j => j.CompanyId);

            modelBuilder.Entity<JobApplication>()
                .HasOne(a => a.Jobs)
                .WithMany(j => j.Applications)
                .HasForeignKey(a => a.JobId);

            modelBuilder.Entity<JobApplication>()
                .HasOne(a => a.Applicant)
                .WithMany(a => a.Applications)
                .HasForeignKey(a => a.ApplicantId);

            modelBuilder.Entity<JobApplication>()
                .HasOne(a => a.RecruitmentStage)
                .WithMany(r => r.Applications)
                .HasForeignKey(a => a.RecruitmentStageId);

            modelBuilder.Entity<InterviewStatus>()
                .HasOne(i => i.Application)
                .WithOne(a => a.InterviewStatus)
                .HasForeignKey<InterviewStatus>(
                    i => i.ApplicationId);
        }
    }
}