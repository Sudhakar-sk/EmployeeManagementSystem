using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Core.IRepositories;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Entities;

namespace EmployeeManagement.Resources.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        #region Login
        public bool LoginCheck(AdminLogin admin)
        {
            var EmployeeDB = new EmployeemanagementsystemContext();
            var logindetails = EmployeeDB.admin_Login.Where(x => x.User_Name == admin.UserName && x.Password == admin.PassWord).SingleOrDefault();

            if (logindetails != null)
            {
                return true;

            }
            else
                return false;
        }
        #endregion

        #region Get Employee Details
        public IEnumerable<EmployeeDetails> GetEmployeeDetails()
        {

            IList<EmployeeDetails> studentList = new List<EmployeeDetails>();

            var EmployeeDB = new EmployeemanagementsystemContext();
            var query = from employee in EmployeeDB.Employee_Details
                        where employee.Is_Deleted == false
                        select employee;



            var employees = query.ToList();

            foreach (var employeeData in employees)
            {
                studentList.Add(new EmployeeDetails()
                {
                    EmployeeId=employeeData.Employee_Id,
                    FullName = employeeData.Full_Name,
                    UserName = employeeData.User_Name,
                    Email = employeeData.Email,
                    Department = employeeData.Department,
                    Matricule = employeeData.Matricule,
                    Address = employeeData.Address,
                    PhoneNumber = employeeData.Phone_Number,
                    Gender = employeeData.Gender

                });
            }
            return studentList;

        }
        #endregion

        #region InsertEmployeeDetails
        public void InsertEmployee(EmployeeDetails employee)
        {
            if (employee != null)
            {
                var EmployeeDB = new EmployeemanagementsystemContext();
                var dbemployee = new Employee_Details()
                {
                    Employee_Id = employee.EmployeeId,
                    Full_Name = employee.FullName,
                    User_Name = employee.UserName,
                    Email = employee.Email,
                    Department = employee.Department,
                    Matricule = employee.Matricule,
                    Address = employee.Address,
                    Phone_Number = employee.PhoneNumber,
                    Gender = employee.Gender
                };
                EmployeeDB.Employee_Details.Add(dbemployee);
                EmployeeDB.SaveChanges();
            }
        }
        #endregion

        #region Delete
        public void DeleteEmployee(int EmployeeId)
        {
            var EmployeeDb = new EmployeemanagementsystemContext();
            var employee = EmployeeDb.Employee_Details.Where(x => x.Employee_Id == EmployeeId && x.Is_Deleted == false).SingleOrDefault();
            if (employee != null)
            {
                employee.Is_Deleted = true;
                employee.Updated_Time_Stamp = DateTime.Now;
                EmployeeDb.SaveChanges();
            }
        }
        #endregion

        #region Get Employee By ID
        public EmployeeDetails GetEmployeeById(int EmployeeId)
        { 
             var EmployeeDB = new EmployeemanagementsystemContext();
             var query = from employee in EmployeeDB.Employee_Details
                    where employee.Employee_Id == EmployeeId && employee.Is_Deleted==false
                    select employee;
         var employeeData = query.SingleOrDefault();
            var model = new EmployeeDetails()
            {   EmployeeId=employeeData.Employee_Id,
                FullName = employeeData.Full_Name,
                UserName = employeeData.User_Name,
                Email = employeeData.Email,
                Department = employeeData.Department,
                Matricule = employeeData.Matricule,
                Address = employeeData.Address,
                PhoneNumber = employeeData.Phone_Number,
                Gender = employeeData.Gender
            };
            return model;
        }
        #endregion

        #region Update
        public void UpdateEmployee(EmployeeDetails employee)
        {
            if (employee != null)
            {
               
                var EmployeeDB = new EmployeemanagementsystemContext();
                var dbemployee = EmployeeDB.Employee_Details.Where(x => x.Employee_Id == employee.EmployeeId && x.Is_Deleted == false).SingleOrDefault();
                dbemployee.Employee_Id = employee.EmployeeId;
                dbemployee.Full_Name = employee.FullName;
                dbemployee.User_Name = employee.UserName;
                dbemployee.Email = employee.Email;
                dbemployee.Department = employee.Department;
                dbemployee.Matricule = employee.Matricule;
                dbemployee.Address = employee.Address;
                dbemployee.Phone_Number = employee.PhoneNumber;
                dbemployee.Gender = employee.Gender;
                dbemployee.Updated_Time_Stamp = DateTime.Now;
            
                EmployeeDB.SaveChanges();

            }
        }
        #endregion
    }
}
