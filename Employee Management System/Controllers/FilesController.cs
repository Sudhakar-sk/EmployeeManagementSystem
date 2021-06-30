using EmployeeManagement.Core.IServices;
using EmployeeManagement.Core.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management_System.Controllers
{
    public class FilesController : Controller
    {
        #region MyRegion
        private readonly IEmployeeService _IEmployeeService;

        #endregion


        [Obsolete]
        private readonly IHostingEnvironment _hostEnvironment;

        [Obsolete]
        public FilesController(IEmployeeService employeeService, IHostingEnvironment hostEnvironment)
        {
            _IEmployeeService = employeeService;
            _hostEnvironment = hostEnvironment;
        }

        // =================================
        #region MyRegion
        //public ActionResult FileUpload()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult FilesUpload(FileDetails myfiles)
        //{
        //    string wwwRootPath = _hostEnvironment.WebRootPath;
        //    string fileName = Path.GetFileNameWithoutExtension(myfiles.File.FileName);
        //    string extension = Path.GetExtension(myfiles.File.FileName);
        //    myfiles.FileNames = fileName + DateTime.Now.ToString("yyyy") + extension;
        //    string path = Path.Combine(wwwRootPath + "/Image/", fileName);
        //    using (var fileStream = new FileStream(path, FileMode.Create))
        //    {
        //        myfiles.File.CopyToAsync(fileStream);
        //    }
        //    _IEmployeeService.FilesUpload(myfiles);
        //    return RedirectToAction("Filesdashboard");
        //}

        //public ActionResult Filesdashboard()
        //{
        //    var fileslist = _IEmployeeService.Filesdashboard();
        //    return View(fileslist);
        //}

        //public ActionResult FileDelete(int id)
        //{
        //    string wwwRootPath = _hostEnvironment.WebRootPath;
        //    _IEmployeeService.FileDelete(id, wwwRootPath);
        //    return RedirectToAction("Filesdashboard");
        //}

        //public ActionResult FileDownload(int id)
        //{
        //    string wwwRootPath = _hostEnvironment.WebRootPath;
        //    var downloadtask = _IEmployeeService.FileDownload(id, wwwRootPath);
        //    string store = "~/Image/" + downloadtask;
        //    return File(store, "Image/jpg");
        //}
        #endregion

        //=================================================================================

        #region File Upload
        public IActionResult FileUpload()
        {
            return View();
        }
        public IActionResult Upload(FileDetails Files)
        {
            var imageFile = HttpContext.Request.Form.Files;
            if (imageFile.Count() > 0)
            {
                byte[] img = null;
                using (var fileStream = imageFile[0].OpenReadStream())
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        fileStream.CopyTo(ms);
                        img = ms.ToArray();
                    }
                }
                Files.UploadFile = img;
            }
            string fileName = Path.GetFileNameWithoutExtension(Files.File.FileName);
            string extension = Path.GetExtension(Files.File.FileName);
            Files.FileNames = fileName + extension;
            Files.Extension = extension;
            _IEmployeeService.FileUpload(Files);
            return RedirectToAction("viewFile");
        }
        #endregion

        #region ViewFiles
        public IActionResult ViewFile()
        {
            var file = _IEmployeeService.GetFile();
            return View(file);
        }
        #endregion
        #region DeleteFile
        public IActionResult DeleteFile(int Id)
        {
            _IEmployeeService.DeleteFile(Id);
            return RedirectToAction("viewFile");
        }
        #endregion
    }
}
    

