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
    public class UserRoleController : ODataController
    {
        private readonly IUserRolesRepository _userRoleRepository;

        public UserRoleController()
        {
            _userRoleRepository = new UserRolesRepository();
        }

        [HttpGet("")]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<UserRole>>> GetAll()
        {
            var list = await _userRoleRepository.GetAllUserRoles();
            return Ok(list);
        }

        [HttpGet("{keyUserId}/{keyRoleId}")]
        [EnableQuery]
        public async Task<ActionResult<UserRole>> GetById([FromODataUri] int keyUserId, [FromODataUri] int keyRoleId)
        {
            var userRole = await _userRoleRepository.GetUserRoleById(keyUserId, keyRoleId);
            if (userRole == null)
            {
                return NotFound();
            }
            return Ok(userRole);
        }

        [HttpPut("{keyUserId}/{keyRoleId}")]
        public async Task<ActionResult> Put([FromODataUri] int keyUserId, [FromODataUri] int keyRoleId, [FromBody] UserRole userRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exist = await _userRoleRepository.GetUserRoleById(keyUserId, keyRoleId);
            if (exist == null)
            {
                return NotFound(ModelState);
            }
            userRole.UserId = exist.UserId;
            userRole.RoleId = exist.RoleId;
            await _userRoleRepository.Update(userRole);
            return Created(userRole);
        }

        [HttpPost("")]
        public async Task<ActionResult> Post([FromBody] UserRole userRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _userRoleRepository.Add(userRole);
            return Created(userRole);
        }

        [HttpDelete("{keyUserId}/{keyRoleId}")]
        public async Task<ActionResult> Delete([FromODataUri] int keyUserId, [FromODataUri] int keyRoleId)
        {
            var userRole = await _userRoleRepository.GetUserRoleById(keyUserId, keyRoleId);
            if (userRole == null)
            {
                return NotFound();
            }
            await _userRoleRepository.Delete(keyUserId, keyRoleId);
            return Content("Delete success!");
        }
    }
}
