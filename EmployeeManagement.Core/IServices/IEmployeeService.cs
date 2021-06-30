using EmployeeManagement.Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core.IServices
{
  public interface IEmployeeService
    {
        bool LoginCheck(AdminLogin admin);
        IEnumerable<EmployeeDetails> GetEmployeeDetails();
        void InsertEmployee(EmployeeDetails employee);
        void DeleteEmployee(int EmployeeId);
        EmployeeDetails GetEmployeeById(int EmployeeId);
        void UpdateEmployee(EmployeeDetails employee);
        //public IEnumerable<FileDetails> GetFileDetails();
        //public void GetFile(FileDetails files);

        //  ==========================================
       void FilesUpload(FileDetails files);

        IEnumerable<FileDetails> Filesdashboard();

      void FileDelete(int id, string wwwRootPath);
        
        string FileDownload(int id, string wwwRootPath);
        //====================================================
        #region FileUpload
        public void FileUpload(FileDetails filE);
        #endregion
        #region ViewFiles
        public List<FileDetails> GetFile();
        #endregion
        #region Deletefile
        public void DeleteFile(int Id);
        #endregion

    }
}
