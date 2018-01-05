using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingHub.Models;
using TrainingHub.ViewModels;


namespace TrainingHub.Controllers
{
    public class EmployeeController : Controller
    {


        private ApplicationDbContext _context;

        public EmployeeController()
        {
          _context = new ApplicationDbContext();  

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Employees
        public ActionResult Index()
        {

            var employees = _context.Employees.ToList();
            var viewModel = new EmployeesViewModel
            {
                Employees = employees
            };

            return View(viewModel);

            //return RedirectToAction("Index", "Home", new {page = 1, xx = 2});
        }
        
        public ActionResult Save(EmployeeCoursesViewModel viewModel)
        {

            return RedirectToAction("Index", "Employee");
        }


        public ActionResult Edit(int id)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.Id == id);

            var trainingRecords = _context.TrainingRecords.Include(t => t.Course).Include(t => t.Employee)
                .Where(t => t.Employee.Id == id).ToList();

            var viewModel = new EmployeeCoursesViewModel
            {
                Employee = employee,
                TrainingRecords = trainingRecords
            };
            
      
            return View("EmployeeTraining",viewModel);
        }
    }
}