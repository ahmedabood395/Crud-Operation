using LabDay3MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace LabDay3MVC.Controllers
{
    public class employeeController : Controller
    {
        ITIContext db = new ITIContext();
        // GET: employee
        public ActionResult showemp()
        {
            List<Employee> empList = db.Employees.ToList();
            
            return View(empList);
        }
        public ActionResult add()
        {
            List<Department> deptList = db.Departments.ToList();
            ViewBag.dept = deptList;
            return View();
        }
        [HttpPost]
        public ActionResult add(Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();
            return RedirectToAction("showemp");
        }
        public ActionResult edit(int id)
        {
            Employee emp = db.Employees.Where(n => n.id == id).FirstOrDefault();
            List<Department> deptList = db.Departments.ToList();
            ViewBag.dept = deptList;
            return View(emp);
        }
        [HttpPost]
        public ActionResult edit(Employee e)
        {
            Employee emp = db.Employees.Where(n => n.id == e.id).FirstOrDefault();
           
            emp.name = e.name;
            emp.salary = e.salary;
            emp.hiredate = e.hiredate;
            emp.address = e.address;
            emp.dept_id = e.dept_id;

            db.SaveChanges();

            //db.Entry(e).State = EntityState.Modified;
            //db.SaveChanges();

            return RedirectToAction("showemp");
        }
        public ActionResult delete(Employee e)
        {
            Employee emp = db.Employees.Where(n => n.id == e.id).FirstOrDefault();
            db.Employees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("showemp");
        }
    }
}