using Job_Portal_Management_System.Data;
using Job_Portal_Management_System.Repository;
using Job_Portal_Management_System.Repository.Implementations;
using Job_Portal_Management_System.Repository.Interfaces;
using Job_Portal_Management_System.Service;
using Job_Portal_Management_System.Service.Implementations;
using Job_Portal_Management_System.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));


// Repositories
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();
builder.Services.AddScoped<IJobApplicationRepository, JobApplicationRepository>();
builder.Services.AddScoped<IInterviewStatusRepository, InterviewStatusRepository>();
builder.Services.AddScoped<IRecruitmentStageRepository, RecruitmentStageRepository>();


// Services
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IApplicantService, ApplicantService>();
builder.Services.AddScoped<IJobApplicationService, JobApplicationService>();
builder.Services.AddScoped<IInterviewStatusService, InterviewStatusService>();
builder.Services.AddScoped<IRecruitmentStageService, RecruitmentStageService>();


// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();