using Microsoft.AspNetCore.Mvc;
using coffee_shop_registration.Models;

namespace coffee_shop_registration.Controllers
{
    public class RegistrationController : Controller
    {
        //Temp in-memory store
        static List<Registration> _registration = new List<Registration>
        {
            new Registration {
                Id = 1,
                FirstName = "Max",
                LastName = "Rando",
                Email = "maxrando@example.com",
                Password = "P@ssw0rd!" },
            new Registration {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe",
                Email = "janedoe@example.com",
                Password = "SuperSecrete123!" },
        };

        //Get Registration
        public IActionResult Index()
        {
            return View();
        }

        //GET: Registration/Details/5
        [HttpGet]
        public IActionResult Details(int id)
        {
            var registration = _registration.FirstOrDefault(x => x.Id == id);
            return View(registration);
        }

        //GET: Registration/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //POST: Registration/ Create
        [HttpPost]
        public IActionResult Create(Registration registration)
        {
            if (ModelState.IsValid)
            {
                registration.Id = _registration.Max(x => x.Id) + 1;
                _registration.Add(registration);

                return RedirectToAction("Registration", registration);
            }

            return View(registration);
        }
    }
}
