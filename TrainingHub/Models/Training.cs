using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainingHub.Models
{
    public class Training
    {
        public int Id { get; set; }

        [Required]
        public Employee Employee { get; set; }

        [Required]
        public Course   Course { get; set; }

        public DateTime CompletedDate{ get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}