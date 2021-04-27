﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTest.Models
{
    public class DepartmentCourse
    {
        [Key,Column(Order =1),ForeignKey("Course")]
        public int CourseId { get; set; }
        [Key, Column(Order = 0), ForeignKey("Department")]
        public int DepNo { get; set; }
        public int Duration { get; set; }
        public Department Department { get; set; }
        public Course Course { get; set; }
    }
}
