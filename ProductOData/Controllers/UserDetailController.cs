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
    public class UserDetailController : ODataController
    {
        private readonly IUserDetailsRepository _userDetailRepository;

        public UserDetailController()
        {
            _userDetailRepository = new UserDetailsRepository();
        }

        [HttpGet("")]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<UserDetail>>> GetAll()
        {
            var list = await _userDetailRepository.GetAllUserDetails();
            return Ok(list);
        }

        [HttpGet("{key}")]
        [EnableQuery]
        public async Task<ActionResult<UserDetail>> GetById([FromODataUri] int key)
        {
            var userDetail = await _userDetailRepository.GetUserDetailsById(key);
            if (userDetail == null)
            {
                return NotFound();
            }
            return Ok(userDetail);
        }

        [HttpPut("{key}")]
        public async Task<ActionResult> Put([FromODataUri] int key, [FromBody] UserDetail userDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exist = await _userDetailRepository.GetUserDetailsById(key);
            if (exist == null)
            {
                return NotFound(ModelState);
            }
            userDetail.UserDetailId = exist.UserDetailId;
            await _userDetailRepository.Update(userDetail);
            return Created(userDetail);
        }

        [HttpPost("")]
        public async Task<ActionResult> Post([FromBody] UserDetail userDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _userDetailRepository.Add(userDetail);
            return Created(userDetail);
        }

        [HttpDelete("{key}")]
        public async Task<ActionResult> Delete([FromODataUri] int key)
        {
            var userDetail = await _userDetailRepository.GetUserDetailsById(key);
            if (userDetail == null)
            {
                return NotFound();
            }
            await _userDetailRepository.Delete(key);
            return Content("Delete success!");
        }
    }
}
