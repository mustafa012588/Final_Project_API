using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Project_DAL.Models
{
    public class Attachment
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        //public DateTime UploadedAt { get; set; }

        public Guid BugId { get; set; }
        public Bug Bug { get; set; }
    }
}
