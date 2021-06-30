using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.Models
{
   public class EmployeeDetails
    {
        [Key]
        public int EmployeeId{ get; set; }

        [Required]
      
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter name")]
       
        public string UserName { get; set; }
      
        [Required(ErrorMessage = "Please enter email address")]

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string Matricule { get; set; }

        [Required]
        public string Address { get; set; }

        public long PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Select Gender")]
        public string Gender { get; set; }
    }
}
