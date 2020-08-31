using AcadTWProg.Models;
using AcadTWProg.Models.MyModels;
using AcadTWProg.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcadTWProg.Controllers.MyControllers
{
    [Authorize]
    public class RoomsController : Controller
    {
        private ApplicationDbContext _context;

        public RoomsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RoomView(int id)
        {
            var room = _context.Rooms.SingleOrDefault(c => c.ID == id);
            if (room == null)
                return HttpNotFound();

            var viewModel = new RoomFormViewModel(room);
            return View("View", viewModel);
        }

        public ActionResult Create()
        {
            var viewModel = new RoomFormViewModel();
            return View("RoomForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var room = _context.Rooms.SingleOrDefault(c => c.ID == id);
            if (room == null)
                return HttpNotFound();

            var viewModel = new RoomFormViewModel(room);
            return View("RoomForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Room room)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new RoomFormViewModel(room);

                return View("RoomForm", viewModel);
            }

            if (room.ID == 0)
                _context.Rooms.Add(room);
            else
            {
                var roomInDb = _context.Rooms.Single(c => c.ID == room.ID);
                roomInDb.Name = room.Name;
                roomInDb.Capacity = room.Capacity;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Rooms");
        }
    }
}