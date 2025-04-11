
using API_Project_DAL.Context;
//using API_Project_DAL.Repositories.AttachmentRepo;
using API_Project_DAL.Repositories.BugRepo;
using API_Project_DAL.Repositories.ProjectRepo;

namespace API_Project_DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly BugsContext _context;


    public IBugRepo BugRepo { get; }

    public IProjectRepo ProjectRepo { get; }

    //public IAttachmentRepo AttachmentRepo { get; }

    public UnitOfWork(
        IBugRepo bugRepo,
        IProjectRepo projectRepo,
        //IAttachmentRepo attachmentRepo,
        BugsContext context)
    {
        BugRepo = bugRepo;
        ProjectRepo = projectRepo;
        //AttachmentRepo = attachmentRepo;
        _context = context;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
