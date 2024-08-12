using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OData.Controllers
{
    [Route("odata/[controller]")]
    [ApiController]
    public class OrderDetailController : ODataController
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailController()
        {
            _orderDetailRepository = new OrderDetailRepository();
        }

        // GET: odata/OrderDetails
        [HttpGet("")]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetAll()
        {
            var list = await _orderDetailRepository.GetAllOrderDetails();
            return Ok(list);
        }

        // GET odata/OrderDetails(5)
        [HttpGet("{key}")]
        [EnableQuery]
        public async Task<ActionResult<OrderDetail>> GetById([FromODataUri] int key)
        {
            var orderDetail = await _orderDetailRepository.GetOrderDetailById(key);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return Ok(orderDetail);
        }

        // PUT odata/OrderDetails(5)
        [HttpPut("{key}")]
        public async Task<IActionResult> Put([FromODataUri] int key, [FromBody] OrderDetail orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingOrderDetail = await _orderDetailRepository.GetOrderDetailById(key);
            if (existingOrderDetail == null)
            {
                return NotFound();
            }
            orderDetail.OrderDetailID = existingOrderDetail.OrderDetailID;
            await _orderDetailRepository.Update(orderDetail);
            return Updated(orderDetail);
        }

        // POST odata/OrderDetails
        [HttpPost("")]
        public async Task<ActionResult<OrderDetail>> Post([FromBody] OrderDetail orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _orderDetailRepository.Add(orderDetail);
            return Created(orderDetail);
        }

        // DELETE odata/OrderDetails(5)
        [HttpDelete("{key}")]
        public async Task<IActionResult> Delete([FromODataUri] int key)
        {
            var orderDetail = await _orderDetailRepository.GetOrderDetailById(key);
            if (orderDetail == null)
            {
                return NotFound();
            }
            await _orderDetailRepository.Delete(key);
            return Content("Delete success!");
        }
    }
}
