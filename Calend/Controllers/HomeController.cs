using Calend.Data;
using Calend.Helpers;
using Calend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Calend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataAccessLayer _dataAccessLayer;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(ILogger<HomeController> logger, IDataAccessLayer dataAccessLayer, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _dataAccessLayer = dataAccessLayer;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewData["Resources"] = JSONListHelper.GetResourceListJSONString(_dataAccessLayer.GetLocations());
            return View();
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