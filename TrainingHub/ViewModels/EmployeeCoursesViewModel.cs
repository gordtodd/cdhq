using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingHub.Models;

namespace TrainingHub.ViewModels
{
    public class EmployeeCoursesViewModel
    {
        public Employee Employee { get; set; }
        public List<Training> TrainingRecords { get; set; }

    }
}