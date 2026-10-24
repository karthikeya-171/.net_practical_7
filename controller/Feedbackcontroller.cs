
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FeedbackManagement.Models;

namespace FeedbackManagement.Controllers
{
    public class FeedbackController : Controller
    {
        // Demo storage: feedback is kept during this application session.
        private static readonly List<Feedback> FeedbackList =
            new List<Feedback>();

        public ActionResult Index()
        {
            ViewBag.FeedbackList = FeedbackList.ToList();
            return View(new Feedback());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                FeedbackList.Add(feedback);
                TempData["Success"] =
                    "Thank you! Your feedback was submitted.";

                return RedirectToAction("Index");
            }

            ViewBag.FeedbackList = FeedbackList.ToList();
            return View(feedback);
        }
    }
}
