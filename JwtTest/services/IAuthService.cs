using JwtTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTest.services
{
    public interface IAuthService
    {
        Task<Authmodel> RegisterAsync(Registermodel rm);
        Task<Authmodel> LoginAsync(Loginmodel lm);
        Task<string> assignRole(Role r);
    }
}
