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
            var departments = _context.Departments.ToList();
            var viewModel = new CourseFormViewModel()
            {
                Departments = departments
            };
            return View("CourseForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var course = _context.Courses.SingleOrDefault(c => c.ID == id);
            if (course == null)
                return HttpNotFound();

            var departments = _context.Departments.ToList();
            var viewModel = new CourseFormViewModel(course)
            {
                Departments = departments
            };
            return View("CourseForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Course course)
        {
            if (!ModelState.IsValid)
            {
                var departments = _context.Departments.ToList();
                var viewModel = new CourseFormViewModel(course)
                {
                    Departments = departments
                };

                return View("CourseForm", viewModel);
            }

            if (course.ID == 0)
                _context.Courses.Add(course);
            else
            {
                var courseInDb = _context.Courses.Single(c => c.ID == course.ID);
                courseInDb.Code = course.Code;
                courseInDb.Name = course.Name;
                courseInDb.DepartmentId = course.DepartmentId;
                courseInDb.Credits = course.Credits;
                courseInDb.Hours = course.Hours;
                courseInDb.Semester = course.Semester;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Courses");
        }
    }
}