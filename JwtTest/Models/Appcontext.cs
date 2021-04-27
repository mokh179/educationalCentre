using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTest.Models
{
    public class Appcontext:IdentityDbContext<users>
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<DepartmentCourse> DepartmentCourses { get; set; }
        public DbSet<studentcourses> Studentcourses { get; set; }

        public Appcontext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DepartmentCourse>()
                .HasKey(e => new { e.DepNo, e.CourseId });
            modelBuilder.Entity<studentcourses>()
                .HasKey(e => new { e.studentID, e.CourseId });
        }
    }
}
