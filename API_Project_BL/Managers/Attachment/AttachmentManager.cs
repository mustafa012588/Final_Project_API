//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using API_Project_BL.Dtos.Attachment;
//using API_Project_DAL;
//using API_Project_DAL.Repositories.ProjectRepo;
//using Microsoft.AspNetCore.Http;

//namespace API_Project_BL.Managers.Attachment
//{
//    public class AttachmentManager : IAttachmentManager
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IWebHostEnvironment _env;

//        public AttachmentService(IUnitOfWork unitOfWork, IWebHostEnvironment env)
//        {
//            _unitOfWork = unitOfWork;
//            _env = env;
//        }

//        public async Task<List<AttachmentReadDto>> UploadAttachmentsAsync(Guid bugId, List<IFormFile> files)
//        {
//            var attachments = new List<Attachment>();

//            foreach (var file in files)
//            {
//                var uploadsFolder = Path.Combine(_env.WebRootPath, "attachments");
//                Directory.CreateDirectory(uploadsFolder);

//                var fileName = $"{Guid.NewGuid()}_{file.FileName}";
//                var filePath = Path.Combine(uploadsFolder, fileName);

//                using (var stream = new FileStream(filePath, FileMode.Create))
//                {
//                    await file.CopyToAsync(stream);
//                }

//                attachments.Add(new Attachment
//                {
//                    FileName = file.FileName,
//                    FilePath = filePath,
//                    BugId = bugId
//                });
//            }

//            foreach (var att in attachments)
//            {
//                await _unitOfWork.AttachmentRepo.AddAsync(att);
//            }

//            await _unitOfWork.SaveChangesAsync();

//            return attachments.Select(a => new AttachmentReadDto
//            {
//                //Id = a.Id,
//                Description = a.FileName
//            }).ToList();
//        }

//        public async Task<List<FileUploadDTO>> GetAttachmentsByBugIdAsync(Guid bugId)
//        {
//            var attachments = await _unitOfWork.AttachmentRepo.FindAsync(a => a.BugId == bugId);
//            return attachments.Select(a => new FileUploadDTO
//            {
//                Id = a.Id,
//                FileName = a.FileName
//            }).ToList();
//        }

//        public async Task<bool> DeleteAttachmentAsync(Guid attachmentId)
//        {
//            var attachment = await _unitOfWork.Attachments.GetByIdAsync(attachmentId);
//            if (attachment == null) return false;

//            if (File.Exists(attachment.FilePath))
//                File.Delete(attachment.FilePath);

//            _unitOfWork.Attachments.Remove(attachment);
//            await _unitOfWork.CompleteAsync();
//            return true;
//        }
//    }
//}
