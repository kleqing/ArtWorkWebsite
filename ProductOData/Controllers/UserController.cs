using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace OData.Controllers
{
    [Route("odata/[controller]")]
    [ApiController]
    public class UserController : ODataController
    {
        private readonly IUsersRepository _userRepository;

        public UserController()
        {
            _userRepository = new UsersRepository();
        }

        [HttpGet("")]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var list = await _userRepository.GetAllUsers();
            return Ok(list);
        }

        [HttpGet("{key}")]
        [EnableQuery]
        public async Task<ActionResult<User>> GetById([FromODataUri] int key)
        {
            var user = await _userRepository.GetUserById(key);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("{key}")]
        public async Task<ActionResult> Put([FromODataUri] int key, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exist = await _userRepository.GetUserById(key);
            if (exist == null)
            {
                return NotFound(ModelState);
            }
            user.Id = exist.Id;
            await _userRepository.Update(user);
            return Created(user);
        }

        [HttpPost("")]
        public async Task<ActionResult> Post([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _userRepository.Add(user);
            return Created(user);
        }

        [HttpDelete("{key}")]
        public async Task<ActionResult> Delete([FromODataUri] int key)
        {
            var user = await _userRepository.GetUserById(key);
            if (user == null)
            {
                return NotFound();
            }
            await _userRepository.Delete(key);
            return Content("Delete success!");
        }
    }
}
