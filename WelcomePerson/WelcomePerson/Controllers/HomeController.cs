using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WelcomePerson.Models;

namespace WelcomePerson.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(Person person)
        {
            if (person == null)
            {
                var newPerson = new Person();
                return View(newPerson);
            }

            return View(person);
        }

        [HttpPost]
        public IActionResult CreatePerson(Person person)
        {
            if (person.Name == null)
            {
                person.Name = "Unknown";
            }

            return RedirectToAction("Index", person);
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
    }
}
