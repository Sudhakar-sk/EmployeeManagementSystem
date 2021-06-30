using EmployeeManagement.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        //===============================================================File Upload Logic===============
        //void GetFile(FileDetails model);
        //=========================================================
        void FilesUpload(FileDetails myfile);
        IEnumerable<FileDetails> Filesdashboard();
        void FileDelete(int id, string wwwRootPath);
        string FileDownload(int id, string wwwRootPath);
        //=========================================================================================
        #region FileUpload
        public void FileUpload(FileDetails filE);
        #endregion
        #region ViewFiles
        public List<FileDetails> GetFile();
        #endregion
        #region Deletefile
        public void DeleteFile(int Id);
        #endregion
       // ================================================================================
    }
}
