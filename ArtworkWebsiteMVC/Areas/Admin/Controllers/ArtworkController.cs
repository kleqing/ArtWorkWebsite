using ArtworkDTO;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Threading.Tasks;

namespace ProductManagementWebClient.Controllers
{
    public class ArtworkController : Controller
    {
        private readonly IArtworkServices _artworkService;

        public ArtworkController(IArtworkServices artworkService)
        {
            _artworkService = artworkService;
        }

        // GET: ArtworkController
        public async Task<ActionResult> Index()
        {
            var artworks = await _artworkService.GetAllArtworks();
            return View(artworks);
        }

        // GET: ArtworkController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var artwork = await _artworkService.GetArtworkById(id);
            if (artwork == null)
            {
                return NotFound();
            }
            return View(artwork);
        }

        // GET: ArtworkController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtworkController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ArtworksDTO artwork)
        {
            if (ModelState.IsValid)
            {
                await _artworkService.Add(artwork);
                return RedirectToAction(nameof(Index));
            }
            return View(artwork);
        }

        // GET: ArtworkController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var artwork = await _artworkService.GetArtworkById(id);
            if (artwork == null)
            {
                return NotFound();
            }
            return View(artwork);
        }

        // POST: ArtworkController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ArtworksDTO artwork)
        {
            if (id != artwork.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _artworkService.Update(artwork);
                return RedirectToAction(nameof(Index));
            }
            return View(artwork);
        }

        // GET: ArtworkController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var artwork = await _artworkService.GetArtworkById(id);
            if (artwork == null)
            {
                return NotFound();
            }
            return View(artwork);
        }

        // POST: ArtworkController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Artwork artwork)
        {
            try
            {
                await _artworkService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(artwork);
            }
        }
    }
}
