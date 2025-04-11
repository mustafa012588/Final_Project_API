//using API_Project_DAL.Repositories.AttachmentRepo;
using API_Project_DAL.Repositories.BugRepo;
using API_Project_DAL.Repositories.ProjectRepo;

namespace API_Project_DAL;

public interface IUnitOfWork
{
    public IBugRepo BugRepo { get; }
    public IProjectRepo ProjectRepo { get; }
    //public IAttachmentRepo AttachmentRepo { get; }

    Task<int> SaveChangesAsync();
}
