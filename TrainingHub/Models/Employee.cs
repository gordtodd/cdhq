using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingHub.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public string Name { get; set; }

        public BusinessUnit BusinessUnit { get; set; }
        public byte BusinessUnitId { get; set; }

        public string Trade { get; set; }
        public byte Type { get; set; }
        public byte Status { get; set; }
        public byte CourseStatus { get; set; }


        public static readonly byte ActiveStatus = 0;
        public static readonly byte TerminatedStatus = 1;

        public static readonly byte Compliant = 0;
        public static readonly byte Warning = 1;
        public static readonly byte Uncompliant = 2;

    }
}