using ArtworkDTO;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Threading.Tasks;

namespace ProductManagementWebClient.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountServices _discountService;

        public DiscountController(IDiscountServices discountService)
        {
            _discountService = discountService;
        }

        // GET: DiscountController
        public async Task<ActionResult> Index()
        {
            var discounts = await _discountService.GetAllDiscounts();
            return View(discounts);
        }

        // GET: DiscountController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var discount = await _discountService.GetDiscountById(id);
            if (discount == null)
            {
                return NotFound();
            }
            return View(discount);
        }

        // GET: DiscountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiscountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DiscountDTO discount)
        {
            if (ModelState.IsValid)
            {
                await _discountService.Add(discount);
                return RedirectToAction(nameof(Index));
            }
            return View(discount);
        }

        // GET: DiscountController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var discount = await _discountService.GetDiscountById(id);
            if (discount == null)
            {
                return NotFound();
            }
            return View(discount);
        }

        // POST: DiscountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, DiscountDTO discount)
        {
            if (id != discount.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _discountService.Update(discount);
                return RedirectToAction(nameof(Index));
            }
            return View(discount);
        }

        // GET: DiscountController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var discount = await _discountService.GetDiscountById(id);
            if (discount == null)
            {
                return NotFound();
            }
            return View(discount);
        }

        // POST: DiscountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Discount discount)
        {
            try
            {
                await _discountService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(discount);
            }
        }
    }
}
