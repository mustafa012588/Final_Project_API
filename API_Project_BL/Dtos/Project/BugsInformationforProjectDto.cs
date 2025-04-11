using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Project_BL.Dtos.Project
{
    public class BugsInformationforProjectDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
