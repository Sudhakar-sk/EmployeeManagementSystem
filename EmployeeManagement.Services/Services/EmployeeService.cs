using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Core.IRepositories;
using EmployeeManagement.Core.IServices;
using EmployeeManagement.Core.Models;
using Microsoft.AspNetCore.Http;

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
        //===================================================================================================
        public void FilesUpload(FileDetails files)
        {
            _IEmployeeRepository.FilesUpload(files);
        }
        public IEnumerable<FileDetails> Filesdashboard()
        {
            return  _IEmployeeRepository.Filesdashboard();
        }
        public void FileDelete(int id, string wwwRootPath)
        {
             _IEmployeeRepository.FileDelete(id, wwwRootPath);
        }
        public string FileDownload(int id, string wwwRootPath)
        {
            return  _IEmployeeRepository.FileDownload(id, wwwRootPath);
        }
        //==============================================================================

        #region FileUpload
        public void FileUpload(FileDetails filE)
        {
            _IEmployeeRepository.FileUpload(filE);
        }
        #endregion
        #region ViewFiles
        public List<FileDetails> GetFile()
        {
            return _IEmployeeRepository.GetFile();
        }
        #endregion
        #region Deletefile
        public void DeleteFile(int Id)
        {
            _IEmployeeRepository.DeleteFile(Id);
        }
        #endregion
    }
}
