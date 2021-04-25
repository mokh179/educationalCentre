using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTest.Models
{
    public class users:IdentityUser
    {
        [Required,MaxLength(50)]
        public string firstName { get; set; }
        [Required,MaxLength(50)]
        public string lastName { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public Department Department { get; set; }
    }
}
