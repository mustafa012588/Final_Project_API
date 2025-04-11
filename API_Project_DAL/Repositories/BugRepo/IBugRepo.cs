using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
//using API_Project_DAL.Generic;
using API_Project_DAL.Models;

namespace API_Project_DAL.Repositories.BugRepo
{
    public interface IBugRepo 
    {
        public Task<List<Bug>> GetAll();

        public Task<Bug> GetById(Guid id);

        public void Add(Bug bug);

        Task<ApplicationUser?> GetUserByIdAsync(Guid userId);
        Task<bool> AssignUserAsync(Guid bugId, Guid userId);
        Task<bool> UnassignUserAsync(Guid bugId, Guid userId);

    }
}
