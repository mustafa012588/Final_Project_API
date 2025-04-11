using API_Project_BL.Managers.Account;
using API_Project_BL.Managers.Attachment;
//using API_Project_BL.Managers.Bug;
using API_Project_BL.Managers.Project;
using BugProject.BL;
using Microsoft.Extensions.DependencyInjection;

namespace API_Project_BL
{
    public static class BusinessExtensions
    {
        public static void AddBusinessServices(
        this IServiceCollection services)
        {
            services.AddScoped<IBugManger, BugManger>();
            services.AddScoped<IProjectManager, ProjectManger>();
            services.AddScoped<IAccountManager, AccountManager>();
            //services.AddScoped<IAttachmentManager, AttachmentManager>();
        }
    }
}
