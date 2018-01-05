using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingHub.Models;

namespace TrainingHub.ViewModels
{
    public class NewCourseViewModel
    {
      
        public Course Course{ get; set; }
        public IEnumerable<SelectListItem> TargetGroups { get; set; }
        public IEnumerable<int> CourseTargetGroups { get; set; }

        

    }
}