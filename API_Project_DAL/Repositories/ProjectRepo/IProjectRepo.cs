using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using API_Project_DAL.Generic;
using API_Project_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Project_DAL.Repositories.ProjectRepo
{
    public interface IProjectRepo 
    {
        public Task<List<Project>> GetAll();

        public Task<Project> GetById(Guid id);

        public void Add(Project project);
    }
}
