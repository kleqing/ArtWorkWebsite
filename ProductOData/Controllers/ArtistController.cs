using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace OData.Controllers
{
    [Route("odata/[controller]")]
    [ApiController]
    public class ArtistController : ODataController
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistController()
        {
            _artistRepository = new ArtistRepository();
        }

        [HttpGet("")]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Artist>>> GetAll()
        {
            var list = await _artistRepository.GetAllArtists();
            return Ok(list);
        }

        [HttpGet("{key}")]
        [EnableQuery]
        public async Task<ActionResult<Artist>> GetById([FromODataUri] int key)
        {
            var artist = await _artistRepository.GetArtistById(key);
            if (artist == null)
            {
                return NotFound();
            }
            return Ok(artist);
        }

        [HttpPost("")]
        public async Task<ActionResult> Post([FromBody] Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _artistRepository.Add(artist);
            return Created(artist);
        }

        [HttpPut("{key}")]
        public async Task<ActionResult> Put([FromODataUri] int key, [FromBody] Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exist = await _artistRepository.GetArtistById(key);
            if (exist == null)
            {
                return NotFound();
            }
            artist.ArtistId = exist.ArtistId;
            await _artistRepository.Update(artist);
            return Updated(artist);
        }

        [HttpDelete("{key}")]
        public async Task<ActionResult> Delete([FromODataUri] int key)
        {
            var artist = await _artistRepository.GetArtistById(key);
            if (artist == null)
            {
                return NotFound();
            }
            await _artistRepository.Delete(key);
            return Content("Delete success!");
        }
    }
}
