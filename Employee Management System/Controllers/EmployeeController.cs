using EmployeeManagement.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Services.Services;
using EmployeeManagement.Core.IServices;
using System.Data;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Employee_Management_System.Controllers
{
    public class EmployeeController : Controller
    {
        #region Declaration
        private   readonly IEmployeeService _IEmployeeService;
        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;
        #endregion

        #region Constructor
        [Obsolete]
        public EmployeeController(IEmployeeService employeeService, IHostingEnvironment hostingEnvironment)
        {
            _IEmployeeService = employeeService;
            this.hostingEnvironment = hostingEnvironment;
        }
        #endregion


        #region Login

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login1(AdminLogin adminLogin)
        {
            var admin = _IEmployeeService.LoginCheck(adminLogin);
            if (admin == true)
            {
                HttpContext.Session.SetString("username",adminLogin.UserName);
                TempData["LoginAlert"] = "Login Successfully ";
                return RedirectToAction("EmployeeDashboard");
            }
            else
            {
                TempData["LoginAlert"] = "Enter Valid Login";
                return View("Login");
            }

        }
        #endregion

        #region Logout
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                HttpContext.Session.Remove("username");
                TempData["LogoutAlert"] = "Logout Successfully ";
            }
            return RedirectToAction("Login");
        }
    #endregion

        #region Employee List
    public ActionResult EmployeeDashboard()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                var EmployeeList = _IEmployeeService.GetEmployeeDetails();
                ViewBag.count = EmployeeList.Count();
                return View(EmployeeList);
            }
            return RedirectToAction("Login");
        }
        #endregion

        #region AddEmployee
        public IActionResult AddEmployee()
        {
            if (HttpContext.Session.GetString("username") != null)
               {
                return View("CreateEdit", new EmployeeDetails());
               }
            return RedirectToAction("Login");
        }
        #endregion
        #region Edit
        public IActionResult Edit(int id)
        {
                if (HttpContext.Session.GetString("username") != null)
                 {
                    EmployeeDetails model = _IEmployeeService.GetEmployeeById(id);
                    return View("CreateEdit", model);
                 }
                return RedirectToAction("Login");
            }
            #endregion
        #region View
            public IActionResult View(int id)
              {
                    if (HttpContext.Session.GetString("username") != null)
                    {
                        EmployeeDetails model = _IEmployeeService.GetEmployeeById(id);
                        return View(model);

                    }
                    return RedirectToAction("Login");
               }
                #endregion

        #region AddEdit
        [HttpPost]
        public IActionResult CreateEdit(EmployeeDetails employee)
        {
           if (HttpContext.Session.GetString("username") != null)
           {
              if (employee.EmployeeId == 0)
                {

                _IEmployeeService.InsertEmployee(employee);

                 }
              else
                 {
                _IEmployeeService.UpdateEmployee(employee);
                 }

              return RedirectToAction("EmployeeDashboard");

           }
            return RedirectToAction("Login");
        }
        #endregion

        #region delete
     public ActionResult Delete(int id)
     { 
        
        if (HttpContext.Session.GetString("username") != null)
        {
           if (id != 0)
            {
                _IEmployeeService.DeleteEmployee(id);
            }
            return RedirectToAction("EmployeeDashboard");
        }
         return RedirectToAction("Login");
     }
        #endregion


        #region MyRegion
        //public ActionResult FileUpload()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult FileUpload(IFormFile files)
        //{
        //    _IEmployeeService.GetFile(files);
        //    return View();
        //}
        #endregion


        #region MyRegion
        //public async Task<IActionResult> UploadFile(IFormFile file)
        //{
        //    if (file == null || file.Length == 0)
        //        return Content("file not selected");

        //    var path = Path.Combine(
        //                Directory.GetCurrentDirectory(), "wwwroot",
        //                file.GetFilename());

        //    using (var stream = new FileStream(path, FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }

        //    return RedirectToAction("Files");
        //}
        #endregion

        //#region MyRegion
        //public ActionResult FileUpload()
        //{
        //    return View();
        //}

        //[Obsolete]
        //public ActionResult FileUploads(FileDetails model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string UniqueFileName = null;
        //        if (model.Photo != null)
        //        {
        //            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
        //            UniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
        //            string filePath = Path.Combine(uploadsFolder, UniqueFileName);
        //            model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                   
        //        }
        //        model.PhotoPath = UniqueFileName;

        //        _IEmployeeService.GetFile(model);
        //    }
          
              
            
        //    return RedirectToAction("FileDetails");
        //}
        //#endregion
        //public ActionResult FileDetails()
        //{
        //    var list=_IEmployeeService.GetFileDetails();
        //    return View(list);
        //}
    }
}
