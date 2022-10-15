using Calend.Data;
using Calend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Calend.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IDataAccessLayer _dataAccessLayer;
        private readonly UserManager<AppUser> _usermanager;

        public EventController(DataAccessLayer dataAccessLayer, UserManager<AppUser> usermanager)
        {
            _dataAccessLayer = dataAccessLayer;
            _usermanager = usermanager;
        }

    

        // GET: EventController
        public ActionResult Index()
        {
            if (TempData["Alert"] != null)
            {
                ViewData["Alert"] = TempData["Alert"];
            }
            return View(_dataAccessLayer.GetMyEvents(User.FindFirstValue(ClaimTypes.NameIdentifier)));

        }



        // GET: EventController/Details/5
        public ActionResult Details(int id)
        {
            if(id == null)
            {
                 return NotFound();
            }

            var @event = _dataAccessLayer.GetEvent((int)id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // GET: EventController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection form)
        {
            try
            {
                _dataAccessLayer.CreateEvent(form);
                TempData["Alert"] = "Success! You created + " + form["Event.Name"];
                return RedirectToAction(nameof(Index));
            }
            catch(Exception exception)
            {
                ViewData["Alert"] = "Error:  " + exception.Message;
                return View();
            }
        }


        // GET: EventController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = _dataAccessLayer.GetEvent((int)id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(_dataAccessLayer.GetEvent((int)id));
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection form)
        {
            try
            {
                _dataAccessLayer.UpdateEvent(form);
                TempData["Alert"] = "Success! You modified an event ";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception exception)

            {
                ViewData["Alert"] = "Error" + exception.Message;
                return View(_dataAccessLayer.GetEvent((int)id));
            }
        }

        // GET: EventController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = _dataAccessLayer.GetEvent((int)id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: EventController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _dataAccessLayer.DeleteEvent(id);
            TempData["Alert"] = "You deleted an event.";
            return RedirectToAction(nameof(Index));
        }
    }
}
