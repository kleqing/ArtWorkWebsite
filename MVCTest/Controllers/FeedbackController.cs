using ArtworkDTO;
using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Services;
using System.Threading.Tasks;

namespace ProductManagementWebClient.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackServices _feedbackService;

        public FeedbackController(IFeedbackServices feedbackService)
        {
            _feedbackService = feedbackService;
        }

        // GET: FeedbackController
        public async Task<ActionResult> Index()
        {
            var feedbacks = await _feedbackService.GetAllFeedbacks();
            return View(feedbacks);
        }

        // GET: FeedbackController/Details/5
        public async Task<ActionResult> Details(int userId, int artworkId)
        {
            var feedback = await _feedbackService.GetFeedbackById(userId, artworkId);
            if (feedback == null)
            {
                return NotFound();
            }
            return View(feedback);
        }

        // GET: FeedbackController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FeedbackController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FeedbackDTO feedback)
        {
            if (ModelState.IsValid)
            {
                await _feedbackService.Add(feedback);
                return RedirectToAction(nameof(Index));
            }
            return View(feedback);
        }

        // GET: FeedbackController/Edit/5
        public async Task<ActionResult> Edit(int userId, int artworkId)
        {
            var feedback = await _feedbackService.GetFeedbackById(userId, artworkId);
            if (feedback == null)
            {
                return NotFound();
            }
            return View(feedback);
        }

        // POST: FeedbackController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int userId, int artworkId, FeedbackDTO feedback)
        {
            /*if (id != feedback.FeedbackId)
            {
                return NotFound();
            }*/
            if (userId != feedback.UserId || artworkId != feedback.ArtworkId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _feedbackService.Update(feedback);
                return RedirectToAction(nameof(Index));
            }
            return View(feedback);
        }

        // GET: FeedbackController/Delete/5
        public async Task<ActionResult> Delete(int userId, int artworkId)
        {
            var feedback = await _feedbackService.GetFeedbackById(userId, artworkId);
            if (feedback == null)
            {
                return NotFound();
            }
            return View(feedback);
        }

        // POST: FeedbackController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int userId, int artworkId, Feedback feedback)
        {
            try
            {
                await _feedbackService.Delete(userId, artworkId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(feedback);
            }
        }
    }
}
