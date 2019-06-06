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
            List<SelectListItem> empPosList = new List<SelectListItem>(); 
            ModelState.Clear();
            foreach(EmpPosition empPos in empDbHandle.GetEmployeePositions())
            {
                empPosList.Add(new SelectListItem { Text = empPos.title , Value = Convert.ToString(empPos.posID) });                
            }
            ViewBag.EmployeePositions = empDbHandle.GetEmployeePositions();
            ViewBag.OfficeLocations = empDbHandle.GetOfficeLocations();
            return View(empDbHandle.GetAllEmployeeData());
        }

        public ActionResult AddEmployee(Employee emp)
        {
            EmpDBHandle empDbHandle = new EmpDBHandle();
            ViewBag.EmployeePositions = empDbHandle.GetEmployeePositions();
            ViewBag.OfficeLocations = empDbHandle.GetOfficeLocations();
            if(ModelState.IsValid && (emp.empID != null))
            {
                empDbHandle.AddEmployee(emp);
                return Redirect("Index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeDetails(Employee employee)
        {
            EmpDBHandle empDbHandle = new EmpDBHandle();
            empDbHandle.UpdateEmployeeDetails(employee);
            return Redirect("/Home/Index");
        }

        public ActionResult EmployeeDetails(string id)
        {
            EmpDBHandle empDbHandle = new EmpDBHandle();
            Employee emp = new Employee();
            emp = empDbHandle.GetEmployeeDataByID(id);
            ViewBag.EmployeePositions = empDbHandle.GetEmployeePositions();
            ViewBag.OfficeLocations = empDbHandle.GetOfficeLocations();
            return View(emp);
        }

        public ActionResult DeleteEmployee(string empID)
        {
            try
            {
                EmpDBHandle empDbHandle = new EmpDBHandle();
                empDbHandle.DeleteEmployee(empID);
                return Redirect("Index");
            }
            catch
            {
                return Redirect("Index");
            }
        }
    }
}