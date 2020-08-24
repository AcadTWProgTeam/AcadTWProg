using AcadTWProg.Models;
using AcadTWProg.Models.MyModels;
using AcadTWProg.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace AcadTWProg.Controllers.MyControllers
{
    [Authorize]
    public class SchedulesController : Controller
    {
        private ApplicationDbContext _context;

        public SchedulesController()
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
            var courses = _context.Courses.ToList();
            var teachers = _context.Teachers.ToList();
            var scheduleFormViewModel = new ScheduleFormViewModel()
            {
                Departments = departments,
                Courses = courses,
                Teachers = teachers
            };
            return View("ScheduleForm", scheduleFormViewModel);
        }

        public ActionResult Edit(int id)
        {
            var schedule = _context.Schedules.SingleOrDefault(c => c.ID == id);
            if (schedule == null)
                return HttpNotFound();

            var departments = _context.Departments.ToList();
            var courses = _context.Courses.ToList();
            var teachers = _context.Teachers.ToList();
            var scheduleFormViewModel = new ScheduleFormViewModel(schedule)
            {
                Departments = departments,
                Courses = courses,
                Teachers = teachers
            };
            return View("ScheduleForm", scheduleFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Schedule schedule)
        {
            if (!ModelState.IsValid)
            {
                var departments = _context.Departments.ToList();
                var courses = _context.Courses.ToList();
                var teachers = _context.Teachers.ToList();
                var scheduleFormViewModel = new ScheduleFormViewModel(schedule)
                {
                    Departments = departments,
                    Courses = courses,
                    Teachers = teachers
                };

                return View("ScheduleForm", scheduleFormViewModel);
            }

            if (schedule.ID == 0)
                _context.Schedules.Add(schedule);
            else
            {
                var scheduleInDb = _context.Schedules.Single(c => c.ID == schedule.ID);
                scheduleInDb.Name = schedule.Name;
                scheduleInDb.DepartmentId = schedule.DepartmentId;
                scheduleInDb.Semester = schedule.Semester;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Schedules");
        }
    }
}