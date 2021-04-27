using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTest.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }
        [Required]
        public int CourseName { get; set; }
        public List<DepartmentCourse> departmentCourses { get; set; }
        public List<studentcourses> Studentcourses { get; set; }

    }
}
