using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTest.Models
{
    public class ResetPassword
    {
        [Required]
        public string UserID { get; set; }
        [Required,DataType(DataType.Password),Display(Name ="Current password")]
        public string CurrentPassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "New password")]
        public string NewPassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Confirm password"),Compare("NewPassword",ErrorMessage = "Password must be match the New password")]
        public string ConfirmPassword { get; set; }
    }
}
