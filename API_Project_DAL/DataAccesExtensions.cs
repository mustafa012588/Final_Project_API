using API_Project_DAL.Context;
//using API_Project_DAL.Generic;
//using API_Project_DAL.Repositories.AttachmentRepo;
using API_Project_DAL.Repositories.BugRepo;
using API_Project_DAL.Repositories.ProjectRepo;
using BugProject.DL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API_Project_DAL
{
    public static class DataAccesExtensions
    {
        public static void AddDataAccesServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("default");
            services.AddDbContext<BugsContext>(options =>
            options
                .UseSqlServer(connectionString));
            services.AddScoped<IBugRepo, BugRepository>();
            services.AddScoped<IProjectRepo, ProjectRepository>();
            //services.AddScoped<IAttachmentRepo, AttachmentRepo>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepository<>));


        }
    }
}
