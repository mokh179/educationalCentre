using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTest.Models
{
    public class studentcourses
    {
        [Key, Column(Order = 1), ForeignKey("Course")]
        public int CourseId { get; set; }
        [Key, Column(Order = 0), ForeignKey("User")]
        public string studentID { get; set; }
        public int? Grade { get; set; }
        public users User { get; set; }
        public Course Course { get; set; }
    }
}
