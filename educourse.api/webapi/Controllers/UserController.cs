using webapi.Models;
using webapi.Services;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using System.Linq;
using System.Security.Claims;

namespace webapi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [EnableCors]
        [HttpGet]
        public ActionResult<List<User>> Get() =>
            _userService.Get();

        [EnableCors("Policy")]
        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var user = _userService.Get(id);
            
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [EnableCors]
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            _userService.Create(user);

            return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, user);
        }

        [EnableCors]
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, User bookIn)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.Update(id, bookIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var book = _userService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _userService.Remove(id);

            return NoContent();
        }

        [EnableCors]
        [AllowAnonymous]
        [Route("authenticate")]
        [HttpPost]
        public ActionResult Login([FromBody] User user)
        {
            var token = _userService.Authenticate(user.Email, user.Password);
            
            if (token == null)
                return Unauthorized();

            return Ok(new { token, user.Email });
        }
    }
}
