using ArtworkDTO;
using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ArtworkWebsiteMVC.Areas.Admin.Controllers
{
    [Area("Admin")]  
    public class ArtistController : Controller
    {
        private readonly IArtistServices _artistServices;

        public ArtistController(IArtistServices artistServices)
        {
            _artistServices = artistServices;
        }

        // GET: ArtistController
        public async Task<ActionResult> Index()
        {
            var artist = await _artistServices.GetAllArtists();
            return View(artist);
        }

        // GET: ArtistController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var artist = await _artistServices.GetArtistById(id);
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
        public async Task<ActionResult> Create(ArtistDTO artist)
        {
            if (ModelState.IsValid)
            {
                await _artistServices.Add(artist);
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        // GET: ArtistController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var artist = await _artistServices.GetArtistById(id);
            if (artist == null)
            {
                return NotFound();
            }
            return View(artist);
        }

        // POST: ArtistController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ArtistDTO artist)
        {
            if (id != artist.ArtistId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _artistServices.Update(artist);
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        // GET: ArtistController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var artist = await _artistServices.GetArtistById(id);
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
                await _artistServices.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(artist);
            }
        }
    }
}
