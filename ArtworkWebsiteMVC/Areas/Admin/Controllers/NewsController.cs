using ArtworkDTO;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Threading.Tasks;

namespace ProductManagementWebClient.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsServices _newsService;

        public NewsController(INewsServices newsService)
        {
            _newsService = newsService;
        }

        // GET: NewsController
        public async Task<ActionResult> Index()
        {
            var news = await _newsService.GetAllNews();
            return View(news);
        }

        // GET: NewsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var newsItem = await _newsService.GetNewsById(id);
            if (newsItem == null)
            {
                return NotFound();
            }
            return View(newsItem);
        }

        // GET: NewsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NewsDTO news)
        {
            if (ModelState.IsValid)
            {
                await _newsService.Add(news);
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: NewsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var newsItem = await _newsService.GetNewsById(id);
            if (newsItem == null)
            {
                return NotFound();
            }
            return View(newsItem);
        }

        // POST: NewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, NewsDTO news)
        {
            if (id != news.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _newsService.Update(news);
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: NewsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var newsItem = await _newsService.GetNewsById(id);
            if (newsItem == null)
            {
                return NotFound();
            }
            return View(newsItem);
        }

        // POST: NewsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, News news)
        {
            try
            {
                await _newsService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(news);
            }
        }
    }
}
