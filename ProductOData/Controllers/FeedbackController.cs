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
    public class FeedbackController : ODataController
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackController()
        {
            _feedbackRepository = new FeedbackRepository();
        }

        [HttpGet("")]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetAll()
        {
            var list = await _feedbackRepository.GetAllFeedbacks();
            return Ok(list);
        }

        [HttpGet("{userId},{artworkId}")]
        [EnableQuery]
        public async Task<ActionResult<Feedback>> GetById([FromODataUri] int userId, [FromODataUri] int artworkId)
        {
            var feedback = await _feedbackRepository.GetFeedbackById(userId, artworkId);
            if (feedback == null)
            {
                return NotFound();
            }
            return Ok(feedback);
        }

        [HttpPost("")]
        public async Task<ActionResult> Post([FromBody] Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _feedbackRepository.Add(feedback);
            return Created(feedback);
        }

        [HttpPut("{userId},{artworkId}")]
        public async Task<ActionResult> Put([FromODataUri] int userId, [FromODataUri] int artworkId, [FromBody] Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exist = await _feedbackRepository.GetFeedbackById(userId, artworkId);
            if (exist == null)
            {
                return NotFound();
            }
            feedback.UserId = exist.UserId;
            feedback.ArtworkId = exist.ArtworkId;
            await _feedbackRepository.Update(feedback);
            return Updated(feedback);
        }

        [HttpDelete("{userId},{artworkId}")]
        public async Task<ActionResult> Delete([FromODataUri] int userId, [FromODataUri] int artworkId)
        {
            var feedback = await _feedbackRepository.GetFeedbackById(userId, artworkId);
            if (feedback == null)
            {
                return NotFound();
            }
            await _feedbackRepository.Delete(userId, artworkId);
            return Content("Delete success!");
        }
    }
}
