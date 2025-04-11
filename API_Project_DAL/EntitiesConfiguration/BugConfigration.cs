using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Project_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Project_DAL.EntitiesConfiguration
{
    public class BugConfigration : IEntityTypeConfiguration<Bug>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Bug> builder)
        {
            builder.HasOne(b => b.Project)
                            .WithMany(p => p.Bugs)
                            .HasForeignKey(b => b.ProjectId)
                            .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(b => b.Assignees)
                  .WithMany(u => u.AssignedBugs)
                  .UsingEntity(j =>
                      j.ToTable("BugAssignees") // Join table
                  );

            builder.HasMany(b => b.Attachments)
                .WithOne(a => a.Bug)
                .HasForeignKey(a => a.BugId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
