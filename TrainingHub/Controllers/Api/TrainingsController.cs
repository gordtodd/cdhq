using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Helpers;
using System.Web.Http;


using TrainingHub.Models;

namespace TrainingHub.Controllers.Api
{
    public class TrainingsController : ApiController
    {
        private ApplicationDbContext _context;
        
        public TrainingsController()
        {
            _context = new ApplicationDbContext();
        }
     
        [HttpPost]
        public  object GetTrainings()
        {

            var trainingRecords = _context.TrainingRecords.Include(t => t.Course).ToList();

            return new {Result = "OK", Records = trainingRecords};

        }


        [HttpPost]
        public object GetTrainings(int id)
        {
            var trainingRecords = _context.TrainingRecords.Include(t=> t.Course).Where(t => t.Employee.Id == id).ToList();
            return new { Result = "OK", Records = trainingRecords };
        }

        [HttpPost]
        [Route("api/trainings/{employeeId:int}/expired")]
        public object GetExpiredTrainings(int employeeId)
        {
            var trainingRecords = _context.TrainingRecords.Include(t => t.Course).Where(t => t.Employee.Id == employeeId).ToList();
            List<object> trainingList = new List<object>();


            foreach (var training in trainingRecords)
            {

                var response = new 
                {
                    Id = training.Id,
                    CourseId = training.Course.Id,
                    CourseName = training.Course.Name,
                    CompletedDate = training.CompletedDate,
                    ExpiryDate = training.ExpiryDate,
                };

                trainingList.Add(response);

            }
            return new { Result = "OK", Records = trainingList};
        }

        [HttpPost]
        [Route("api/trainings/delete")]
        public object Delete(object response)
        {
            try
            {
                dynamic jsonObj = System.Web.Helpers.Json.Decode(response.ToString());
                int trainingId = Convert.ToInt32(jsonObj.Id);

                var training = _context.TrainingRecords.Single(t => t.Id == trainingId);
                _context.TrainingRecords.Remove(training);
                _context.SaveChanges();

                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/trainings/create/{employeeId:int}")]
        public object Create(object response,int employeeId)
        {
            try
            {
                dynamic jsonObj = System.Web.Helpers.Json.Decode(response.ToString());

               // int employeeId = Convert.ToInt32(jsonObj.Record.EmployeeId);
                int courseId = Convert.ToInt32(jsonObj.Record.CourseId);

                var employee = _context.Employees.SingleOrDefault(e => e.Id == employeeId);
                var course = _context.Courses.SingleOrDefault(c => c.Id == courseId);

                var newTrainingRecord = new Training
                {
                    Id = 0,
                    Employee = employee,
                    Course = course,
                    CompletedDate = Convert.ToDateTime(jsonObj.Record.CompletedDate),
                    ExpiryDate = Convert.ToDateTime(jsonObj.Record.ExpiryDate),
                };


                var addedTraining = _context.TrainingRecords.Add(newTrainingRecord);
                _context.SaveChanges();

                var result = new
                {
                    Id = addedTraining.Id,
                    CourseId = addedTraining.Course.Id,
                    CourseName = addedTraining.Course.Name,
                    CompletedDate = addedTraining.CompletedDate,
                    ExpiryDate = addedTraining.ExpiryDate,
                };


                return new { Result = "OK", Record = result };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };

            }
        }

        [HttpPost]
        [Route("api/trainings/update")]
        public object Update(object response)
        {
            dynamic jsonObj = System.Web.Helpers.Json.Decode(response.ToString());

            int trainingId = Convert.ToInt32(jsonObj.Record.Id);
            int courseId = Convert.ToInt32(jsonObj.Record.CourseId);
            try
            {

                var trainingInDb = _context.TrainingRecords.Include(e=> e.Employee).Include(c=> c.Course).Single(t=> t.Id == trainingId);
                trainingInDb.CompletedDate = Convert.ToDateTime(jsonObj.Record.CompletedDate);
                trainingInDb.ExpiryDate = Convert.ToDateTime(jsonObj.Record.ExpiryDate);

                var course = _context.Courses.Single(c => c.Id == courseId);
                trainingInDb.Course = course;

                _context.SaveChanges();

                return new { Result = "OK", Record = trainingInDb };
            }
            catch (Exception ex)
            {
                return new { Result = "ERROR", Message = ex.Message };

            }

        }
    }
}
