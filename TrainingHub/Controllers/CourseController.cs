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
    public class CourseController : Controller
    {
        private ApplicationDbContext _context;

        public CourseController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Courses
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Save(NewCourseViewModel viewModel)
        {

            var course = viewModel.Course;

            // if the course is zero add a new 
            if (viewModel.Course.Id == 0)
                course = _context.Courses.Add(viewModel.Course);
            else
            {
                // map the Course object
                var tmpCourse = _context.Courses.Single(c => c.Id == course.Id);
                tmpCourse.Name = course.Name;
                tmpCourse.Description = course.Description;
                tmpCourse.SupervisorTraining = course.SupervisorTraining;
                tmpCourse.ValidNoOfDays = tmpCourse.ValidNoOfDays;
                tmpCourse.WarnNoOfDayBeforeExpire = course.WarnNoOfDayBeforeExpire;
                
                // delete the course target groups 
                _context.CourseTargetGroups.RemoveRange(_context.CourseTargetGroups.Where(c => c.CourseId == course.Id));

            }

           
            // add the new course target groups
            if (viewModel.CourseTargetGroups != null)
            {
                foreach (var id in viewModel.CourseTargetGroups)
                {
                    var courseTarget = new CourseTargetGroup
                    {
                        CourseId = course.Id,
                        TargetGroupId = id
                    };

                    _context.CourseTargetGroups.Add(courseTarget);
                }
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Course");
        }

        public ActionResult New()
        {
            // Load the target groups
            //var targetGroups = _context.TargetGroups.ToList();

            var viewModel = new NewCourseViewModel();

            viewModel.Course = new Course();

            viewModel.TargetGroups = _context.TargetGroups.Select(t => new SelectListItem {  Text = t.Name,Value =  t.Id.ToString()})
                .ToList();
           
            return View("CourseForm",viewModel);
        }
        public ActionResult Edit(int id)
        {

            var course = _context.Courses.SingleOrDefault(c => c.Id == id);
            //if (course == null)
                

            var viewModel = new NewCourseViewModel();
            viewModel.Course = course;
            viewModel.TargetGroups = _context.TargetGroups.Select(t => new SelectListItem { Text = t.Name, Value = t.Id.ToString() })
                .ToList();

            viewModel.CourseTargetGroups = _context.CourseTargetGroups.Where(c => c.CourseId == id).Select(c => c.TargetGroupId);
            

            return View("CourseForm",viewModel);
        }
    }
}