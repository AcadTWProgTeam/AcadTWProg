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
    public class CoursesController : Controller
    {
        private ApplicationDbContext _context;

        public CoursesController()
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

        public ActionResult Create()
        {
            var viewModel = new CourseFormViewModel();
            return View("CourseForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var course = _context.Courses.SingleOrDefault(c => c.ID == id);
            if (course == null)
                return HttpNotFound();

            var viewModel = new CourseFormViewModel(course);
            return View("CourseForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Course course)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CourseFormViewModel(course);

                return View("CourseForm", viewModel);
            }

            if (course.ID == 0)
                _context.Courses.Add(course);
            else
            {
                var courseInDb = _context.Courses.Single(c => c.ID == course.ID);
                courseInDb.Code = course.Code;
                courseInDb.Name = course.Name;
                courseInDb.Credits = course.Credits;
                courseInDb.Hours = course.Hours;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Courses");
        }
    }
}