using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTest.Models
{
    public class Authmodel
    {
        public string Message { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; }

        public DateTime Tokenlife { get; set; }
        public bool IsAuthenticated { get; set; }
        public int DeptID { get; set; }
    }
}
