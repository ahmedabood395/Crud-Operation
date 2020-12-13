using LabDay3MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabDay3MVC.Controllers
{
    public class projectController : Controller
    {
        ITIContext db = new ITIContext();
        // GET: project
        public ActionResult showpro()
        {
            List<Project> proList = db.Projects.ToList();

            return View(proList);
        }
        public ActionResult add()
        {
            List<Department> deptList = db.Departments.ToList();
            ViewBag.dept = deptList;
            return View();
        }
        [HttpPost]
        public ActionResult add(Project p)
        {
            db.Projects.Add(p);
            db.SaveChanges();
            return RedirectToAction("showpro");
        }
        public ActionResult edit(int id)
        {
            Project pro = db.Projects.Where(n => n.id == id).FirstOrDefault();
            List<Department> deptList = db.Departments.ToList();
            ViewBag.dept = deptList;
            return View(pro);
        }
        [HttpPost]
        public ActionResult edit(Project p)
        {
            //Employee emp = db.Employees.Where(n=>n.id==e.id).FirstOrDefault();
            //emp.name = e.name;
            //emp.salary = e.salary;
            //emp.hiredate = e.hiredate;
            //emp.address = e.address;
            //emp.dept_id = e.dept_id;

            //db.SaveChanges();

            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("showpro");
        }
        public ActionResult delete(Project p)
        {
            Project pro = db.Projects.Where(n => n.id == p.id).FirstOrDefault();
            db.Projects.Remove(pro);
            db.SaveChanges();
            return RedirectToAction("showpro");
        }
    }
}