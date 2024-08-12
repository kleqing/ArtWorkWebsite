using ArtworkDTO;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Data;

namespace ArtworkWebsiteMVC.Areas.Admin.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRolesServices _rolesService;

        public RolesController(IRolesServices rolesService)
        {
            _rolesService = rolesService;
        }

        // GET: ArtistController
        public async Task<ActionResult> Index()
        {
            var artists = await _rolesService.GetAllRoles();
            return View(artists);
        }

        // GET: ArtistController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var artist = await _rolesService.GetRoleById(id);
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
        public async Task<ActionResult> Create(RoleDTO role)
        {
            if (ModelState.IsValid)
            {
                await _rolesService.Add(role);
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }

        // GET: ArtistController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var artist = await _rolesService.GetRoleById(id);
            if (artist == null)
            {
                return NotFound();
            }
            return View(artist);
        }

        // POST: ArtistController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, RoleDTO role)
        {
            if (id != role.RoleId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _rolesService.Update(role);
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }

        // GET: ArtistController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var artist = await _rolesService.GetRoleById(id);
            if (artist == null)
            {
                return NotFound();
            }
            return View(artist);
        }

        // POST: ArtistController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Artist artist)
        {
            try
            {
                await _rolesService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(artist);
            }
        }
    }
}
