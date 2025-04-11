using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using API_Project_DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_Project_DAL.EntitiesConfiguration
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<Models.Attachment>
    {
     

        public void Configure(EntityTypeBuilder<Models.Attachment> builder)
        {
            builder.HasOne(a => a.Bug).WithMany(b=>b.Attachments).HasForeignKey(a=>a.BugId);
            
        }
    }
}
