using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingHub.Models
{
    public class CourseTargetGroup
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public TargetGroup TargetGroup { get; set; }
        public int TargetGroupId { get; set; }
        
    }
}