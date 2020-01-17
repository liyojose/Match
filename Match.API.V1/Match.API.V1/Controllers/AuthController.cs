using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Match.API.V1.Data;
using Match.API.V1.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Match.API.V1.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {

        private readonly IAuthRepository _repo;

        public AuthController (IAuthRepository repo) {
            this._repo = repo;
        }

        // POST: api/Values
        [HttpPost ("register")]
        public async Task<IActionResult> Register (UserForRegDto input) {
            if (await _repo.UserExists (input.Username.ToLower ())) {
                return BadRequest ("User name already exists");
            }
            var user = new User {
                Username = input.Username.ToLower (),
            };
            var ouser = _repo.Register (user, input.Password);
            return StatusCode(201);

        }
        [HttpPost ("login")]
        public async Task<IActionResult> Login (UserForRegDto input) {
            var user = await _repo.Login (input.Username,input.Password);
           if(user == null)
           {
               return Unauthorized();
           }
           var claim = new Claims();
           return Ok();

        }
    }

}