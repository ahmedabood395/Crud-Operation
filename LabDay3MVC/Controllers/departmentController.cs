using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabDay3MVC.Models;


namespace LabDay3MVC.Controllers
{
    public class departmentController : Controller
    {
        // GET: department
        ITIContext db = new ITIContext();
        public ActionResult showdept()
        {
            List<Department> deptList = db.Departments.ToList();
            return View(deptList);
        }
    }
}