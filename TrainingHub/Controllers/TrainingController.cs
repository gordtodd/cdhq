using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingHub.Models;
using TrainingHub.ViewModels;

namespace TrainingHub.Controllers
{
    public class TrainingController : Controller
    {
        // GET: Training
        public ActionResult Test()
        {
            var employee = new Employee
            {
                Id = 2,
                BusinessUnitId = 1,
            };
            var viewModel = new EmployeeCoursesViewModel
            {
                Employee = employee

            };

            return View("Test",viewModel);
        }
    }
}