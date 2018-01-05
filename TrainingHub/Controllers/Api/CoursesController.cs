using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using AutoMapper;
using Microsoft.Owin.Security;
using TrainingHub.Dtos;
using TrainingHub.Models;

namespace TrainingHub.Controllers.Api
{
    public class CoursesController : ApiController
    {
        private ApplicationDbContext _context;

        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/courses
        public IEnumerable<CourseDto> GetCourses()
        {
            return _context.Courses.ToList().Select(Mapper.Map<Course,CourseDto>);
        }

        // GET /api/courses/1
        public IHttpActionResult GetCourse(int id)
        {
            var course = _context.Courses.SingleOrDefault(c => c.Id == id);

            if (course == null)
                return NotFound();

            return Ok(Mapper.Map<Course,CourseDto>(course));

        }

        // POST 
        [HttpPost]
        public IHttpActionResult CreateCourse(CourseDto courseDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var course = Mapper.Map<CourseDto, Course>(courseDto);

            _context.Courses.Add(course);
            _context.SaveChanges();

            courseDto.Id = course.Id;

            return Created(new Uri(Request.RequestUri + "/" + course.Id), courseDto);

        }

        [HttpPut]
        public void UpdateCourse(int id, CourseDto courseDto)
        {

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var courseInDb = _context.Courses.SingleOrDefault(c => c.Id == id);
            if (courseInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // map the fields or use mapper later
            Mapper.Map(courseDto, courseInDb);

            _context.SaveChanges();

        }


        [HttpDelete]
        [Route("api/courses/delete/{id}")]
        public void DeleteCourse(int id)
        {
            var courseInDb = _context.Courses.SingleOrDefault(c => c.Id == id);
            if (courseInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Courses.Remove(courseInDb);
            _context.SaveChanges();

        }

        [HttpPost]
        [Route("api/courses/list")]
        public object List(object response)
        {
            var courses =_context.Courses.ToList();
            List<object> courseList = new List<object>();
            foreach (var course in courses)
            {
                var courseListData = new {DisplayText = course.Name, Value = course.Id};
                courseList.Add(courseListData);
            }

            return new { Result = "OK", Options = courseList };
        }

    }
}
