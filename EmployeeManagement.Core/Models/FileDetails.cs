using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace EmployeeManagement.Core.Models
{
   public class FileDetails
    {

        [Key]
        public int FileId { get; set; }
        //[Required(ErrorMessage = "Filename required")]
        //[StringLength(40)]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use albhabets only")]
        public string FileNames { get; set; }
        //[Required(ErrorMessage = "Please select file.")]
        //[RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.tif|.png|.jpg|.gif)$", ErrorMessage = "Only Image files allowed.")]
        public IFormFile File{ get; set; }

        public byte[] UploadFile { get; set; }

        public string Extension { get; set; }

    }
}
