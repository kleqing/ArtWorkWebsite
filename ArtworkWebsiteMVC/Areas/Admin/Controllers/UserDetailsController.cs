using ArtworkDTO;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Threading.Tasks;

namespace ProductManagementWebClient.Controllers
{
    public class UserDetailsController : Controller
    {
        private readonly IUserDetailsServices _userDetailsService;

        public UserDetailsController(IUserDetailsServices userDetailsService)
        {
            _userDetailsService = userDetailsService;
        }

        // GET: UserDetailsController
        public async Task<ActionResult> Index()
        {
            var userDetails = await _userDetailsService.GetAllUserDetails();
            return View(userDetails);
        }

        // GET: UserDetailsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var userDetails = await _userDetailsService.GetUserDetailsById(id);
            if (userDetails == null)
            {
                return NotFound();
            }
            return View(userDetails);
        }

        // GET: UserDetailsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserDetailDTO userDetails)
        {
            if (ModelState.IsValid)
            {
                await _userDetailsService.Add(userDetails);
                return RedirectToAction(nameof(Index));
            }
            return View(userDetails);
        }

        // GET: UserDetailsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var userDetails = await _userDetailsService.GetUserDetailsById(id);
            if (userDetails == null)
            {
                return NotFound();
            }
            return View(userDetails);
        }

        // POST: UserDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UserDetailDTO userDetails)
        {
            if (id != userDetails.UserDetailId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _userDetailsService.Update(userDetails);
                return RedirectToAction(nameof(Index));
            }
            return View(userDetails);
        }

        // GET: UserDetailsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var userDetails = await _userDetailsService.GetUserDetailsById(id);
            if (userDetails == null)
            {
                return NotFound();
            }
            return View(userDetails);
        }

        // POST: UserDetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, UserDetail userDetails)
        {
            try
            {
                await _userDetailsService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(userDetails);
            }
        }
    }
}
