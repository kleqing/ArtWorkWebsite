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
    public class DiscountController : ODataController
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountController()
        {
            _discountRepository = new DiscountRepository();
        }

        [HttpGet("")]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Discount>>> GetAll()
        {
            var list = await _discountRepository.GetAllDiscounts();
            return Ok(list);
        }

        [HttpGet("{key}")]
        [EnableQuery]
        public async Task<ActionResult<Discount>> GetById([FromODataUri] int key)
        {
            var discount = await _discountRepository.GetDiscountById(key);
            if (discount == null)
            {
                return NotFound();
            }
            return Ok(discount);
        }

        [HttpPost("")]
        public async Task<ActionResult> Post([FromBody] Discount discount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _discountRepository.Add(discount);
            return Created(discount);
        }

        [HttpPut("{key}")]
        public async Task<ActionResult> Put([FromODataUri] int key, [FromBody] Discount discount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exist = await _discountRepository.GetDiscountById(key);
            if (exist == null)
            {
                return NotFound();
            }
            discount.Id = exist.Id;
            await _discountRepository.Update(discount);
            return Updated(discount);
        }

        [HttpDelete("{key}")]
        public async Task<ActionResult> Delete([FromODataUri] int key)
        {
            var discount = await _discountRepository.GetDiscountById(key);
            if (discount == null)
            {
                return NotFound();
            }
            await _discountRepository.Delete(key);
            return Content("Delete success!");
        }
    }
}
