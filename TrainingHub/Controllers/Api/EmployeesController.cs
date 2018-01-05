using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using AutoMapper;
using TrainingHub.Dtos;
using TrainingHub.Models;

namespace TrainingHub.Controllers.Api
{
    public class EmployeesController : ApiController
    {
        private ApplicationDbContext _context;
        public EmployeesController()
        {
                _context = new ApplicationDbContext();
            
        }

        //GET /api/employees
        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        
    }
   
}
