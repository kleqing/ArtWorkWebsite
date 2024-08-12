using ArtworkDTO;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services;

namespace ArtworkWebsiteMVC.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsersServices _userService;

        public UserController(IUsersServices userService)
        {
            _userService = userService;
        }

        // GET: ArtistController
        public async Task<ActionResult> Index()
        {
            var artists = await _userService.GetAllUsers();
            return View(artists);
        }

        // GET: ArtistController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var artist = await _userService.GetUserById(id);
            if (artist == null)
            {
                return NotFound();
            }
            return View(artist);
        }

        // GET: ArtistController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtistController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserDTO user)
        {
            if (ModelState.IsValid)
            {
                await _userService.Add(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: ArtistController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var artist = await _userService.GetUserById(id);
            if (artist == null)
            {
                return NotFound();
            }
            return View(artist);
        }

        // POST: ArtistController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UserDTO user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _userService.Update(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: ArtistController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var artist = await _userService.GetUserById(id);
            if (artist == null)
            {
                return NotFound();
            }
            return View(artist);
        }

        // POST: ArtistController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, User user)
        {
            try
            {
                await _userService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(user);
            }
        }
    }
}
