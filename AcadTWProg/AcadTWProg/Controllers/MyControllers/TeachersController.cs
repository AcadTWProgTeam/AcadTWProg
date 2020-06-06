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
    public class TeachersController : Controller
    {
        private ApplicationDbContext _context;

        public TeachersController()
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
            var viewModel = new TeacherFormViewModel();
            return View("TeacherForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var teacher = _context.Teachers.SingleOrDefault(c => c.ID == id);
            if (teacher == null)
                return HttpNotFound();

            var viewModel = new TeacherFormViewModel(teacher);
            return View("TeacherForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new TeacherFormViewModel(teacher);

                return View("TeacherForm", viewModel);
            }

            if (teacher.ID == 0)
                _context.Teachers.Add(teacher);
            else
            {
                var teacherInDb = _context.Teachers.Single(c => c.ID == teacher.ID);
                teacherInDb.Name = teacher.Name;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Teachers");
        }
    }
}