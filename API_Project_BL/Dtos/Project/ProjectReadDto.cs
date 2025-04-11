using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Project_BL.Dtos.Bug;
using BugProject.BL;

namespace API_Project_BL.Dtos.Project
{
    public class ProjectReadDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<BugReadDTO> Bugs { get; set; }
    }
}
