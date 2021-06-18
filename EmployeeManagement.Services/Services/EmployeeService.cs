using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Core.IRepositories;
using EmployeeManagement.Core.IServices;
using EmployeeManagement.Core.Models;

namespace EmployeeManagement.Services.Services
{
    public class EmployeeService:IEmployeeService
    {
        #region Declaration
        readonly IEmployeeRepository _IEmployeeRepository;
        #endregion

        #region Constructor Injection
        public EmployeeService(IEmployeeRepository employeeRepositories)
        {
            _IEmployeeRepository = employeeRepositories;
        }
        #endregion

        #region Login
        public bool LoginCheck(AdminLogin admin)
        {
            return _IEmployeeRepository.LoginCheck(admin);
        }
        #endregion

        #region Get Employee Details
       
            public IEnumerable<EmployeeDetails> GetEmployeeDetails()
            {
                return _IEmployeeRepository.GetEmployeeDetails();
            }

        #endregion
        #region Insert
        public void InsertEmployee(EmployeeDetails employee)
        {
            _IEmployeeRepository.InsertEmployee(employee);
        }
        #endregion
        #region Delete
        public void DeleteEmployee(int EmployeeId)
        {
            _IEmployeeRepository.DeleteEmployee(EmployeeId);
        }
        #endregion
        #region GetEmployeeByID 
        public EmployeeDetails GetEmployeeById(int EmployeeId)
        {
            return _IEmployeeRepository.GetEmployeeById(EmployeeId);
        }
        #endregion
        #region Update
        public void UpdateEmployee(EmployeeDetails employee)
        {
            _IEmployeeRepository.UpdateEmployee(employee);
        }
        #endregion


    }
}
