using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Project_BL.Comman;
using API_Project_BL.Dtos.Project;

namespace API_Project_BL.Managers.Project
{
    public interface IProjectManager
    {
        public Task<List<ProjectReadDTO>> GetAllAsync();
        public Task<ProjectReadDTO?> GetByIdAsync(Guid id);
        public Task<GeneralResult> AddAsync(ProjectAddDto item);
    }
}
