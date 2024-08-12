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
    public class ArtworkController : ODataController
    {
        private readonly IArtworkRepository _artworkRepository;

        public ArtworkController()
        {
            _artworkRepository = new ArtworkRepository();
        }

        [HttpGet("")]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Artwork>>> GetAll()
        {
            var list = await _artworkRepository.GetAllArtworks();
            return Ok(list);
        }

        [HttpGet("{key}")]
        [EnableQuery]
        public async Task<ActionResult<Artwork>> GetById([FromODataUri] int key)
        {
            var artwork = await _artworkRepository.GetArtworkById(key);
            if (artwork == null)
            {
                return NotFound();
            }
            return Ok(artwork);
        }

        [HttpPost("")]
        public async Task<ActionResult> Post([FromBody] Artwork artwork)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _artworkRepository.Add(artwork);
            return Created(artwork);
        }

        [HttpPut("{key}")]
        public async Task<ActionResult> Put([FromODataUri] int key, [FromBody] Artwork artwork)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exist = await _artworkRepository.GetArtworkById(key);
            if (exist == null)
            {
                return NotFound();
            }
            artwork.Id = exist.Id;
            await _artworkRepository.Update(artwork);
            return Updated(artwork);
        }

        [HttpDelete("{key}")]
        public async Task<ActionResult> Delete([FromODataUri] int key)
        {
            var artwork = await _artworkRepository.GetArtworkById(key);
            if (artwork == null)
            {
                return NotFound();
            }
            await _artworkRepository.Delete(key);
            return Content("Delete success!");
        }
    }
}
