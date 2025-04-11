using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Project_DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API_Project_DAL.Context
{
    public class BugsContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {

        public DbSet<Project> Projects { get; set; }
        public DbSet<Bug> Bugs { get; set; }
        //public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public BugsContext(DbContextOptions<BugsContext> options):base(options) { }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BugsContext).Assembly);
           // modelBuilder.Entity<BugAssignee>()
           //.HasKey(x => new { x.BugId, x.UserId });

           // modelBuilder.Entity<BugAssignee>()
           //     .HasOne(x => x.User)
           //     .WithMany(u => u.AssignedBugs)
           //     .HasForeignKey(x => x.UserId);

           // modelBuilder.Entity<BugAssignee>()
           //     .HasOne(x => x.Bug)
           //     .WithMany(b => b.Assignees)
           //     .HasForeignKey(x => x.BugId);
        }
    }
}
