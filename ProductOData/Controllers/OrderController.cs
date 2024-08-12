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
    public class OrderController : ODataController
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController()
        {
            _orderRepository = new OrderRepository();
        }

        [HttpGet("")]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Order>>> GetAll()
        {
            var list = await _orderRepository.GetAllOrders();
            return Ok(list);
        }

        [HttpGet("{key}")]
        [EnableQuery]
        public async Task<ActionResult<Order>> GetById([FromODataUri] int key)
        {
            var order = await _orderRepository.GetOrderById(key);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost("")]
        public async Task<ActionResult> Post([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _orderRepository.Add(order);
            return Created(order);
        }

        [HttpPut("{key}")]
        public async Task<ActionResult> Put([FromODataUri] int key, [FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exist = await _orderRepository.GetOrderById(key);
            if (exist == null)
            {
                return NotFound();
            }
            order.OrderId = exist.OrderId;
            await _orderRepository.Update(order);
            return Updated(order);
        }

        [HttpDelete("{key}")]
        public async Task<ActionResult> Delete([FromODataUri] int key)
        {
            var order = await _orderRepository.GetOrderById(key);
            if (order == null)
            {
                return NotFound();
            }
            await _orderRepository.Delete(key);
            return Content("Delete success!");
        }
    }
}
