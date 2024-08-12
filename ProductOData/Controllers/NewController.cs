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
    public class NewController : ODataController
    {
        private readonly INewsRepository _newsRepository;

        public NewController()
        {
            _newsRepository = new NewsRepository();
        }

        [HttpGet("")]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<News>>> GetAll()
        {
            var list = await _newsRepository.GetAllNews();
            return Ok(list);
        }

        [HttpGet("{key}")]
        [EnableQuery]
        public async Task<ActionResult<News>> GetById([FromODataUri] int key)
        {
            var news = await _newsRepository.GetNewsById(key);
            if (news == null)
            {
                return NotFound();
            }
            return Ok(news);
        }

        [HttpPost("")]
        public async Task<ActionResult> Post([FromBody] News news)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _newsRepository.Add(news);
            return Created(news);
        }

        [HttpPut("{key}")]
        public async Task<ActionResult> Put([FromODataUri] int key, [FromBody] News news)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exist = await _newsRepository.GetNewsById(key);
            if (exist == null)
            {
                return NotFound();
            }
            news.Id = exist.Id;
            await _newsRepository.Update(news);
            return Updated(news);
        }

        [HttpDelete("{key}")]
        public async Task<ActionResult> Delete([FromODataUri] int key)
        {
            var news = await _newsRepository.GetNewsById(key);
            if (news == null)
            {
                return NotFound();
            }
            await _newsRepository.Delete(key);
            return Content("Delete success!");
        }
    }
}
