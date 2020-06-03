using AcadTWProg.Models;
using AcadTWProg.Models.MyModels;
using AcadTWProg.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace AcadTWProg.Controllers.MyControllers
{
    public class DepartmentsController : Controller
    {
        private ApplicationDbContext _context;

        public DepartmentsController()
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
            var viewModel = new DepartmentFormViewModel();
            return View("DepartmentForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var department = _context.Departments.SingleOrDefault(c => c.ID == id);
            if (department == null)
                return HttpNotFound();

            var viewModel = new DepartmentFormViewModel(department);
            return View("DepartmentForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Department department)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new DepartmentFormViewModel(department);

                return View("DepartmentForm", viewModel);
            }

            if (department.ID == 0)
                _context.Departments.Add(department);
            else
            {
                var departmentInDb = _context.Departments.Single(c => c.ID == department.ID);
                departmentInDb.Name = department.Name;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Departments");
        }
    }
}