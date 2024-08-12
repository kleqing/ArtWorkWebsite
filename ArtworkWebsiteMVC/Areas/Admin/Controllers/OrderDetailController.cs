using ArtworkDTO;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Threading.Tasks;

namespace ProductManagementWebClient.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly IOrderDetailServices _orderDetailService;

        public OrderDetailController(IOrderDetailServices orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        // GET: OrderDetailController
        public async Task<ActionResult> Index()
        {
            var orderDetails = await _orderDetailService.GetAllOrderDetails();
            return View(orderDetails);
        }

        // GET: OrderDetailController/Details/5
        public async Task<ActionResult> Details(int ordID)
        {
            var orderDetail = await _orderDetailService.GetOrderDetailById(ordID);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return View(orderDetail);
        }

        // GET: OrderDetailController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderDetailController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(OrderDetailDTO orderDetail)
        {
            if (ModelState.IsValid)
            {
                await _orderDetailService.Add(orderDetail);
                return RedirectToAction(nameof(Index));
            }
            return View(orderDetail);
        }

        // GET: OrderDetailController/Edit/5
        public async Task<ActionResult> Edit(int ordID)
        {
            var orderDetail = await _orderDetailService.GetOrderDetailById(ordID);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return View(orderDetail);
        }

        // POST: OrderDetailController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int ordID, OrderDetailDTO orderDetail)
        {
            if (ordID != orderDetail.OrderDetailID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _orderDetailService.Update(orderDetail);
                return RedirectToAction(nameof(Index));
            }
            return View(orderDetail);
        }

        // GET: OrderDetailController/Delete/5
        public async Task<ActionResult> Delete(int ordID)
        {
            var orderDetail = await _orderDetailService.GetOrderDetailById(ordID);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return View(orderDetail);
        }

        // POST: OrderDetailController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int ordID, OrderDetail orderDetail)
        {
            try
            {
                await _orderDetailService.Delete(ordID);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(orderDetail);
            }
        }
    }
}
