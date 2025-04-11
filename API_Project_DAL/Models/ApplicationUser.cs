using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace API_Project_DAL.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ICollection<Bug> AssignedBugs { get; set; } = new List<Bug>();

    }
}
