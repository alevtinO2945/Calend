using Calend.Data;
using Calend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Calend.Controllers
{
    [Authorize]
    public class LocationController : Controller
    {

        private readonly IDataAccessLayer _dataAccessLayer;
        private readonly UserManager<AppUser> _usermanager;

        public LocationController(DataAccessLayer dataAccessLayer, UserManager<AppUser> usermanager)
        {
            _dataAccessLayer = dataAccessLayer;
            _usermanager = usermanager;
        }



        // GET: LocationController
        public ActionResult Index()
        {
            if (TempData["Alert"] != null)
            {
                ViewData["Alert"] = TempData["Alert"];
            }
            return View(_dataAccessLayer.GetLocations());
        }

        // GET: LocationController/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var location = _dataAccessLayer.GetLocation((int)id);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // GET: LocationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,Name")] Location location, IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dataAccessLayer.CreateLocation(location);
                    TempData["Alert"] = "Success! You created a location ";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception exception)
                {
                    ViewData["Alert"] = "Error: " + exception.Message;
                    return View(location);
                }

            }
            return View(location);
        }

       
    }
}
