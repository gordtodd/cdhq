using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainingHub.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int ValidNoOfDays { get; set; }
        [Required]
        public int WarnNoOfDayBeforeExpire { get; set; }

        public bool SupervisorTraining { get; set; }
        public ICollection<CourseTargetGroup> CourseTargetGroups { get; set; }
    }
}