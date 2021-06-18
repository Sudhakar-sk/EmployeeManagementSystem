using EmployeeManagement.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Services.Services;
using EmployeeManagement.Core.IServices;
using System.Data;

namespace Employee_Management_System.Controllers
{
    public class EmployeeController : Controller
    {
        readonly IEmployeeService _IEmployeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _IEmployeeService = employeeService;
        }



        #region Login

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AdminLogin adminLogin)
        {
          var admin= _IEmployeeService.LoginCheck(adminLogin);
            if (admin == true)
            {
                TempData["LoginAlert"] = "Login Successfully ";
                return RedirectToAction("EmployeeDashboard");
            }
            else
            {
                ViewBag.Login = "Enter Valid Login";
            }
            return View();
        }
        #endregion

        #region Employee List
        public ActionResult EmployeeDashboard()
        {
            var EmployeeList= _IEmployeeService.GetEmployeeDetails();
            ViewBag.count=EmployeeList.Count();
            return View(EmployeeList);
        }
        #endregion

        #region AddEmployee
        public IActionResult AddEmployee()
        {
            return View("CreateEdit", new EmployeeDetails());
        }
        #endregion
        #region Edit
        public IActionResult Edit(int id)
        {
            EmployeeDetails model = _IEmployeeService.GetEmployeeById(id);
            return View("CreateEdit", model);
        }
        #endregion
        #region Edit
        public IActionResult View(int id)
        {
            EmployeeDetails model = _IEmployeeService.GetEmployeeById(id);
            return View( model);

        }
        #endregion

        #region AddEdit
        [HttpPost]
        public IActionResult CreateEdit(EmployeeDetails employee)
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
        #endregion

        #region delete
        public ActionResult Delete(int id)
        {
            if (id != 0)
            {
               
                _IEmployeeService.DeleteEmployee(id);
            }
            return RedirectToAction("EmployeeDashboard");
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }
    }
}
