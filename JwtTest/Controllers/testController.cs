using JwtTest.Models;
using JwtTest.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
        private IAuthService _auth;

        public testController(IAuthService auth)
        {
            _auth = auth;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] Registermodel rm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = await _auth.RegisterAsync(rm);
            if (!res.IsAuthenticated)
                return BadRequest(res.Message);
            return Ok(res);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Loginmodel lm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var res = await _auth.LoginAsync(lm);
            if (!res.IsAuthenticated)
                return BadRequest(res.Message);
            return Ok(res);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] Role r)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            string res = await _auth.assignRole(r);
            if (res!="Done")
                return BadRequest(res);
            return Ok(r);
        }
    }
}
