using PracticeADO_crud.Data_Access_Layer;
using PracticeADO_crud.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeADO_crud.Controllers
{
    public class HomeController : Controller
    {
        db context = new db();
        public ActionResult Index()
        {
            //DataSet ds = context.showAllEmployees();
            //ViewBag.emp = ds.Tables[0];
            List<Employee> employees = context.showAllEmployees1();


            return View(employees);
        }

        public ActionResult AddRecord()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRecord(FormCollection data)
        {
            Employee model = new Employee();
            model.emp_name = data["name"];
            model.emp_city=data["city"];
            model.emp_department = data["department"];
            model.emp_pincode = data["pin"];
            context.AddEmp(model);

            TempData["msg"] = "Record Has been Saved successfuly!";
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult EditEmployee(int id)
        {
            DataSet ds = context.ShowEmp_ByID(id);
            ViewBag.emp = ds.Tables[0];
            return View();
        }

        [HttpPost]
        public ActionResult EditEmployee(int id,FormCollection data)
        {
            Employee model = new Employee();
            model.emp_id = id;
            model.emp_name = data["name"];
            model.emp_city = data["city"];
            model.emp_department = data["department"];
            model.emp_pincode = data["pin"];
            context.UpdateEmp(model);

            TempData["msg"] = "Record Has been Updated successfuly!";
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int id)
        {
            context.Delete_emp(id);

            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}