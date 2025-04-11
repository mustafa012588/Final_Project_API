using API_Project_BL.Comman;
using API_Project_BL.Dtos.Attachment;
using API_Project_BL.Dtos.Bug;
using BugProject.DL;

namespace BugProject.BL
{
    public interface IBugManger
    {
        public Task<List<BugReadDTO>> GetAllAsync();
        public Task<BugReadDTO?> GetByIdAsync(Guid id);
        public Task<GeneralResult> AddAsync(BugAddDto bug);

        public Task<List<AttachmentReadDTO>> GetAttachment(Guid id);
        public Task<GeneralResult> AddAtatchment(Guid bugId, AttachmentReadDTO attachment);

        public Task<GeneralResult> DeleteAttachment(Guid bugId, Guid attId);
        public Task<GeneralResult> AssignUserAsync(Guid bugId, Guid userId);
        public Task<GeneralResult> UnassignUserAsync(Guid bugId, Guid userId);


    }
}