using EmployeeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmployeeManagement.Core.IRepositories
{
   public interface IEmployeeRepository
    {
        bool LoginCheck(AdminLogin admin);
        IEnumerable<EmployeeDetails> GetEmployeeDetails();
        void InsertEmployee(EmployeeDetails employee);
        void DeleteEmployee(int EmployeeId);
        EmployeeDetails GetEmployeeById(int EmployeeId);
        void UpdateEmployee(EmployeeDetails employee);


    }
}
