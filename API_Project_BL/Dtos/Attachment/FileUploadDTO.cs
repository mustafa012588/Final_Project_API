using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace API_Project_BL.Dtos.Attachment
{
    public class FileUploadDTO
    {
        public IFormFile File { get; set; }



    }
}
