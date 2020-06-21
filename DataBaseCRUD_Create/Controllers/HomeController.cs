using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyDataBase.Model;
using MyDataBase.DB.DataBaseOP;

namespace DataBaseCRUD_Create.Controllers
{
    public class HomeController : Controller
    {  
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Employee emp)
        {
            if (ModelState.IsValid)
            {
                EmployeeOP employeeOP = new EmployeeOP();
                int id=employeeOP.AddEmployee(emp);
                if (id > 0)
                {
                    ViewBag.Success = "Data Added Successfully :)";
                    ViewBag.Value = 1;
                }
                else
                    ViewBag.Success = "Data Addition Failed :)";
            }
            return View("Index");
        }

        public ActionResult ShowAllRecords()
        {
            EmployeeOP employeeOP = new EmployeeOP();
            var list = employeeOP.GetAllData();

            return View(list);
        }

        public ActionResult Details(int id)
        {
            EmployeeOP employeeOP = new EmployeeOP();
            var result = employeeOP.GetEmployeeDetails(id);

            return View(result);
        }

        public ActionResult Edit(int id)
        {
            EmployeeOP employeeOP = new EmployeeOP();
            var result = employeeOP.GetEmployeeDetails(id);

            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            EmployeeOP employeeOP = new EmployeeOP();
            employeeOP.UpdateRecord(employee);

            return RedirectToAction("ShowAllRecords");
        }

        public ActionResult Delete(int id)
        {
            EmployeeOP employeeOP = new EmployeeOP();
            employeeOP.DeleteRecord(id);

            return RedirectToAction("ShowAllRecords");
        }
    }
}