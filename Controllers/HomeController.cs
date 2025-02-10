using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TP2.Models;
using TPLOCAL;

namespace TP2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }
        public IActionResult Avis()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "resources", "DataAvis.xml");

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("Fichier introuvable.");
            }

            ListReviews listReviews = new ListReviews();
            List<Reviews> avisList = listReviews.GetAvis(filePath);

            return View("Avis", avisList);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private static List<Validation> _validations = new List<Validation>();

        [HttpPost]
        public IActionResult SubmitForm(Validation model)
        {
            if (ModelState.IsValid)
            {
                _validations.Add(model);
                return RedirectToAction("PageDeValidation");
            }
            return View("Form", model);
        }

        public IActionResult PageDeValidation()
        {
            return View(_validations);
        }
    }
}