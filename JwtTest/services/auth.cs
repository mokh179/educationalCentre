using JwtTest.helpers;
using JwtTest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtTest.services
{
    public class auth : IAuthService
    {
        private readonly UserManager<users> _user;
        private readonly RoleManager<IdentityRole> _role;
        private readonly JWT _jwt;

        public auth(UserManager<users> user, IOptions<JWT> jwt, RoleManager<IdentityRole> role)
        {
            _jwt = jwt.Value;
            _user = user;
            _role = role;
        }
        public async Task<Authmodel> RegisterAsync(Registermodel rm)
        {
            if (await _user.FindByEmailAsync(rm.Email) != null)
                return new Authmodel { Message = "This email is exist Before" };
            if (await _user.FindByNameAsync(rm.Username) != null)
                return new Authmodel { Message = "This Username is exist Before" };
            var user = new users() {
                firstName = rm.Firstname,
                lastName = rm.Lastname,
                Email = rm.Email,
                UserName = rm.Username,
                DeptId = 100
            };

            var result = await _user.CreateAsync(user, rm.Password);
            if (!result.Succeeded)
            {
                var errs = "";
                foreach (var item in result.Errors)
                {
                    errs = $"{item.Description} , ";
                }
                return new Authmodel { Message = errs };
            }
            await _user.AddToRoleAsync(user, "Student");
            //To make user login Automatic
            var token = await Generatetoken(user);
            return new Authmodel
            {
                Email = user.Email,
                Tokenlife = token.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "Student" },
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Username = user.UserName,
                DeptID = user.DeptId  
            };
        }
        public async Task<Authmodel> LoginAsync(Loginmodel lm)
        {
            var model = new Authmodel();
            var user = await _user.FindByNameAsync(lm.username);
            if (user is null || !await _user.CheckPasswordAsync(user, lm.password))
            {
                model.Message = "Username Or Password inCorrect";
                return model;
            }
            var token = await Generatetoken(user);
            var roles = await _user.GetRolesAsync(user);

            model.IsAuthenticated = true;
            model.Username = user.UserName;
            model.Email = user.Email;
            model.DeptID = user.DeptId;
            model.Tokenlife = token.ValidTo;
            model.Token = new JwtSecurityTokenHandler().WriteToken(token);
            model.Roles = roles.ToList();
            return model;
        }
        public async Task<JwtSecurityToken> Generatetoken(users user)
        {
            var Userclaims = await _user.GetClaimsAsync(user); //get user claims
            var Userroles = await _user.GetRolesAsync(user); //get user rols
            var Roleclaims = new List<Claim>();
            foreach (var item in Userroles)
            {
                Roleclaims.Add(new Claim("roles", item));
            }
            var claims = new[]
            {
                 new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //New ID foreach claim
                 new Claim(JwtRegisteredClaimNames.Email, user.Email),
                 new Claim("uid", user.Id)
            }.Union(Userclaims).Union(Roleclaims);
            var symmetrickey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingcredentials = new SigningCredentials(symmetrickey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
             issuer: _jwt.Issuer,
             audience: _jwt.Audience,
             claims: claims,
             expires: DateTime.Now.AddDays(_jwt.DurationInDay),
             signingCredentials: signingcredentials);
            return jwtSecurityToken;
        }

        public async Task<string> assignRole(Role r)
        {
            var user = await _user.FindByIdAsync(r.UserID);
            if (user is null || !await _role.RoleExistsAsync(r.role))
                return "Invalid Data";
           if(await _user.IsInRoleAsync(user,r.role))
                return "User already in role";
            var res = await _user.AddToRoleAsync(user, r.role);

            return res.Succeeded ? "Done" : "Something went Wrong";

            //if (res.Succeeded)
            //    return "Done";
            //return "Something went Wrong";
        }

        public async Task<bool> resetPasswoord(ResetPassword pw)
        {
            var user = await _user.FindByIdAsync(pw.UserID);
            var res = await _user.ChangePasswordAsync(user,pw.CurrentPassword,pw.NewPassword);
          
            return res.Succeeded;
        }


    } 
}
    