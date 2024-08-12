using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Repositories;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;

namespace OData.Controllers
{
    [Route("odata/[controller]")]
    [ApiController]
    public class RoleController : ODataController
    {
        private readonly IRolesRepository _roleRepository;

        public RoleController()
        {
            _roleRepository = new RolesRepository();
        }

        [HttpGet("")]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Role>>> GetAll()
        {
            var list = await _roleRepository.GetAllRoles();
            return Ok(list);
        }

        [HttpGet("{key}")]
        [EnableQuery]
        public async Task<ActionResult<Role>> GetById([FromODataUri] int key)
        {
            var role = await _roleRepository.GetRoleById(key);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPut("{key}")]
        public async Task<ActionResult> Put([FromODataUri] int key, [FromBody] Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exist = await _roleRepository.GetRoleById(key);
            if (exist == null)
            {
                return NotFound(ModelState);
            }
            role.RoleId = exist.RoleId;
            await _roleRepository.Update(role);
            return Created(role);
        }

        [HttpPost("")]
        public async Task<ActionResult> Post([FromBody] Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _roleRepository.Add(role);
            return Created(role);
        }

        [HttpDelete("{key}")]
        public async Task<ActionResult> Delete([FromODataUri] int key)
        {
            var role = await _roleRepository.GetRoleById(key);
            if (role == null)
            {
                return NotFound();
            }
            await _roleRepository.Delete(key);
            return Content("Delete success!");
        }
    }
}
