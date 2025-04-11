﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Project_DAL.Models
{
    public class Bug
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Guid ProjectId { get; set; }

        public Project Project { get; set; }

        public ICollection<ApplicationUser> Assignees { get; set; } = new List<ApplicationUser>();
        public ICollection<Attachment> Attachments { get; set; } = new HashSet<Attachment>();
    }
}
