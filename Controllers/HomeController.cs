using Assignment_Rapidd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_Rapidd.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EmpDBHandle empDbHandle = new EmpDBHandle();
            ModelState.Clear();
            return View(empDbHandle.GetAllEmployeeData());
        }

        public ActionResult AddEmployee()
        {
            EmpDBHandle empDbHandle = new EmpDBHandle();
            ModelState.Clear();
            return View();
        }

        public ActionResult EmployeeDetails()
        {
            EmpDBHandle empDbHandle = new EmpDBHandle();
            ModelState.Clear();
            return View();
        }
    }
}