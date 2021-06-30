using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Core.Models
{
   public class AdminLogin
    {
        public int LoginId { get; set; }
        [Required(ErrorMessage = "Please enter Username")]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string PassWord{ get; set; }
}
}
