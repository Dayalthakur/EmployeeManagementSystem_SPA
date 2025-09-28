using Microsoft.AspNetCore.Mvc;
using SPA_ASP.NETMVC.Models;
using System.Linq;

namespace SPA_ASP.NETMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmpDbContext _dbcontext;

        public HomeController(EmpDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        // Load Index view
        public IActionResult Index()
        {
            return View();
        }

        // Get all employees
        public ActionResult GetAllEmployees()
        {
            var emp = _dbcontext.Employees.ToList();
            return Json(new { data = emp });
        }

        // Add employee
        [HttpPost]
        public ActionResult AddEmployee(Employee emp)
        {
            _dbcontext.Employees.Add(emp);
            _dbcontext.SaveChanges();
            return Json(new { success = true, message = "Record Added Successfully" });
        }

        // Get one employee by id (for edit form)
        public ActionResult EditForm(int id)
        {
            var emp = _dbcontext.Employees.FirstOrDefault(e => e.EmpId == id);
            if (emp == null)
            {
                return Json(new { success = false, message = "Employee not found" });
            }
            return Json(emp);
        }

        // Update employee
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            _dbcontext.Employees.Update(emp);
            _dbcontext.SaveChanges();
            return Json(new { success = true, message = "Record Updated Successfully" });
        }

        // Delete employee
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var emp = _dbcontext.Employees.FirstOrDefault(e => e.EmpId == id);
            if (emp == null)
            {
                return Json(new { success = false, message = "Employee not found" });
            }

            _dbcontext.Employees.Remove(emp);
            _dbcontext.SaveChanges();
            return Json(new { success = true, message = "Record Deleted Successfully" });
        }
    }
}
