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

        public Appcontext(DbContextOptions options):base(options)
        {

        }
    }
}
