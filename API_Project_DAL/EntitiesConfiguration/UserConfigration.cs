﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Project_DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Project_DAL.EntitiesConfiguration
{
    internal class UserConfigration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasMany(u => u.AssignedBugs)
                              .WithMany(b => b.Assignees)
                              .UsingEntity(j => j.ToTable("BugAssignees"));
        }
    }
}
