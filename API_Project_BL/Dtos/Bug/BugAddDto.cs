using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Project_BL.Dtos.Bug
{
    public class BugAddDto
    {

        public Guid BugId { get; set; }
        public string Description { get; set; }
        public Guid ProjectId { get; set; }
    }

}

