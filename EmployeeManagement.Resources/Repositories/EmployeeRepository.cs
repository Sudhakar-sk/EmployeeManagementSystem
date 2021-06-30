using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EmployeeManagement.Core.IRepositories;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Web.Helpers;

namespace EmployeeManagement.Resources.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IHostingEnvironment hostingEnvironment;
        public EmployeeRepository(IHostingEnvironment hostingEnvironment)
        {          
            this.hostingEnvironment = hostingEnvironment;
        }
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
            {
                return false;
            }
        }
        #endregion

        #region Get Employee Details
        public IEnumerable<EmployeeDetails> GetEmployeeDetails()
        {

            IList<EmployeeDetails> employeeList = new List<EmployeeDetails>();

            var EmployeeDB = new EmployeemanagementsystemContext();
            employeeList = (from employee in EmployeeDB.Employee_Details
                        where employee.Is_Deleted == false
                        select new EmployeeDetails
                        {
                            EmployeeId = employee.Employee_Id,
                            FullName = employee.Full_Name,
                            UserName = employee.User_Name,
                            Email = employee.Email,
                            Department = employee.Department,
                            Matricule = employee.Matricule,
                            Address = employee.Address,
                            PhoneNumber = employee.Phone_Number,
                            Gender = employee.Gender
                        }).ToList();
            return employeeList;

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

        //  =========================================================================================================

        #region FileUpload
        //public void Index(FileDetails model)
        //{
        //    // Initialization.  
        //    string fileContent = string.Empty;
        //    string fileContentType = string.Empty;


        //    // Converting to bytes.  
        //    byte[] uploadedFile = new byte[model.FileAttach.ContentType.Length];
        //    model.FileAttach.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

        //    // Initialization.  
        //    fileContent = Convert.ToBase64String(uploadedFile);
        //    fileContentType = model.FileAttach.ContentType;

        //    // Saving info.  
        //    this.databaseManager.sp_insert_file(model.FileAttach.FileName, fileContentType, fileContent);


        //    // Settings.  
        //    model.ImgLst = this.databaseManager.sp_get_all_files().Select(p => new ImgObj
        //    {
        //        FileId = p.file_id,
        //        FileName = p.file_name,
        //        FileContentType = p.file_ext
        //    }).ToList();
        //}


        //        // Info  
        //        return model;
        //    }

    #region MyRegion
    //public byte[] ConvertToBytes(IFormFile image)
    //{
    //    using (var memoryStream = new MemoryStream())
    //    {
    //        image.OpenReadStream().CopyTo(memoryStream);
    //       return memoryStream.ToArray();
    //   }
    //}

    //public ActionResult Upload(IFormFile file)
    //{
    //    byte[] buffer = new byte[file.Length];
    //    var resultInBytes = ConvertToBytes(file);
    //    Array.Copy(resultInBytes, buffer, resultInBytes.Length);

    //    return buffer;

    //}
    #endregion
    #endregion


    #region MyRegion
    //public void GetFile(IFormFile files)
    //{
    //    if (files != null)
    //    {
    //        using var EmployeeEntities = new EmployeemanagementsystemContext();
    //        //Getting FileName
    //        var fileName = Path.GetFileName(files.Name);
    //        //Getting file Extension
    //        var fileExtension = Path.GetExtension(fileName);
    //        // concatenating  FileName + FileExtension
    //        var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);
    //        var objfiles = new file_Details()
    //        {
    //            File_Name = newFileName,
    //            File_Extension = fileExtension,
    //            Created_Time_Stamp = DateTime.Now
    //        };
    //        using (var target = new MemoryStream())
    //        {
    //            files.CopyTo(target);
    //            objfiles.File_Content = target.ToArray();
    //        }
    //        EmployeeEntities.file_Details.Add(objfiles);
    //        EmployeeEntities.SaveChanges();
    //    }
    //}
    #endregion

    #region MyRegion 
    //public void GetFile(FileDetails model)
    //    {
    //        if (model != null)
    //        {
    //            var EmployeeEntities = new EmployeemanagementsystemContext();

    //            var input = (model.Photo).ToString();
    //            byte[] array = Encoding.ASCII.GetBytes(input);

    //            file_Details newFiles = new ()
    //            {
    //                File_Name = model.PhotoPath,
    //                File_Content=array
    //            };
              
    //            EmployeeEntities.file_Details.Add(newFiles);
    //            EmployeeEntities.SaveChangesAsync();
              
    //        }
       
    //    }
        #endregion

        #region list
        //public IEnumerable<FileDetails> GetFileDetails()
        //{
        //    IList<FileDetails> fileList = new List<FileDetails>();
        //    // Initialization.  
            

        //    var EmployeeDB = new EmployeemanagementsystemContext();
        //   fileList = (from file in EmployeeDB.file_Details
        //                    where file.Is_Deleted == false
        //                    select new FileDetails
        //                    {
        //                        FileId = file.File_Id,
        //                        FileName = file.File_Name,
        //                        FileContent = file.File_Content

        //                    }).ToList();
            //fileList = (from file in EmployeeDB.file_Details
            //                where file.Is_Deleted == false
            //                select new FileDetails
            //                {
            //                    FileId = file.File_Id,
            //                    FileName = file.File_Name,
            //                    FileContent = file.File_Content,
            //                }).ToList()


          //  return fileList;


            //// Settings.  
            //model.ImgLst = this.databaseManager.sp_get_all_files().Select(p => new ImgObj
            //    {
            //        FileId = p.file_id,
            //        FileName = p.file_name,
            //        FileContentType = p.file_ext
            //    }).ToList();
            //}
           

            //// Info.  
            //return (model);
       // }

        #endregion

        //public void DownloadFile(int fileId)
        //{
        //    // Model binding.  
        //    FileDetails model = new FileDetails();

        //        model.FileContent = null;
        //        model.ImgLst = new List<FileDetails>();


        //    var EmployeeDB = new EmployeemanagementsystemContext();
        //    // Loading dile info.  
        //    var fileInfo = EmployeeDB.file_Details.Where(x=>x.File_Id==fileId).First();
        //    {
        //        // Info.  
        //        model.FileContent = fileInfo.File_Content;
        //        byte[] byteContent = Encoding.Default.GetByte(model.FileContent);

        //        return this.GetDownloadFile(model.FileContent, fileInfo.File_Name);
        //    }



        //}
        //private FileDetails GetDownloadFile(string fileContent, string fileContentType)
        //{
        //    // Initialization.  
        //    FileDetails file = null;


        //        // Get file.  
        //        byte[] byteContent = Convert.FromBase64String(fileContent);
        //        file = this.File(byteContent, fileContentType);
        //    }

        //    // info.  
        //    return file;
        //}


        #region File Logic
        #region Filesupload
        public  void FilesUpload(FileDetails myfile)
        {
            var DbFiles = new EmployeemanagementsystemContext();
           
            //type conversion
            string stringfiles = (myfile.File).ToString();
            byte[] fileasbyte = Encoding.ASCII.GetBytes(stringfiles);
            file_Details manage = new file_Details();
            manage.File_Name = myfile.FileNames;
            manage.File_Content = fileasbyte;
            DbFiles.file_Details.Add(manage);
            DbFiles.SaveChanges();
        }
        #endregion
        #region Dashboard
        public IEnumerable<FileDetails> Filesdashboard()
        {
            IList<FileDetails> fileList = new List<FileDetails>();
            using (var EmployeeDB = new EmployeemanagementsystemContext())
            {
                fileList = (from file in EmployeeDB.file_Details
                           where file.Is_Deleted == false
                           select new FileDetails
                           {
                               FileId = file.File_Id,
                               FileNames = file.File_Name,
                           }).ToList();
              
            }
            return fileList;
        }
        #endregion
        public async void FileDelete(int id, string wwwRootPath)
        {
            using (var _context = new EmployeemanagementsystemContext())
            {
                var imageModel = await _context.file_Details.FindAsync(id);
                //delete image from wwwroot/image
                var imagePath = Path.Combine(wwwRootPath, "image", imageModel.File_Name);
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                    //delete the record
                    imageModel.Is_Deleted = true;
                    await _context.SaveChangesAsync();
                }
            }
        }
        public string FileDownload(int id, string wwwRootPath)
        {
            using (var _context = new EmployeemanagementsystemContext())
            {
                var downloadimage = _context.file_Details.Where(a => a.File_Id == id).SingleOrDefault();
                var image = downloadimage.File_Name;
                //var filepath = Path.Combine(wwwRootPath,"Image", image);
                return image;
            }
        }


        #endregion

        //============================================================================
        #region FileUpload
        public void FileUpload(FileDetails filEs)
        {
            if (filEs.File != null)
            {
                file_Details uploadFile = new file_Details();
                using (var entity = new EmployeemanagementsystemContext())
                {
                    uploadFile.File_Name = filEs.FileNames;
                    uploadFile.File_Content = filEs.UploadFile;
                    uploadFile.File_Extension = filEs.Extension;
                    entity.file_Details.Add(uploadFile);
                    entity.SaveChanges();
                }
            }
        }
        #endregion
        #region ViewFiles
        public List<FileDetails> GetFile()
        {
            List<FileDetails> fileDetails = new List<FileDetails>();
            using (var entity = new EmployeemanagementsystemContext())
            {
                fileDetails = (from file in entity.file_Details
                               where file.Is_Deleted == false
                               select new FileDetails
                               {
                                   FileId = file.File_Id,
                                   FileNames = file.File_Name,
                                   UploadFile = file.File_Content
                               }).ToList();
            }
            return fileDetails;
        }
        #endregion
        #region Deletefile
        public void DeleteFile(int Id)
        {
            if (Id != 0)
            {
                using (var EmployeeDb = new EmployeemanagementsystemContext())
                {
                    var FileData = EmployeeDb.file_Details.Where(x => x.File_Id == Id && x.Is_Deleted == false).SingleOrDefault();
                    if (FileData != null)
                    {
                        FileData.Is_Deleted = true;
                        FileData.Updated_Time_Stamp = DateTime.Now;
                        EmployeeDb.SaveChanges();
                    }
                }
            }
        }
        #endregion
    }


}
      
    
