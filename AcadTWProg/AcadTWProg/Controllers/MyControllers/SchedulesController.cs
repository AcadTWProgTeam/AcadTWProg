using AcadTWProg.Models;
using AcadTWProg.Models.MyModels;
using AcadTWProg.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web.Mvc;

namespace AcadTWProg.Controllers.MyControllers
{
    [Authorize]
    public class SchedulesController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public SchedulesController()
        {
            _context = new ApplicationDbContext();
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            ApplicationUser user = _userManager.FindById(User.Identity.GetUserId());
            ViewBag.DepartmentId = user.DepartmentId;
            return View();
        }

        public ActionResult Create()
        {
            var departments = _context.Departments.ToList();
            var courses = _context.Courses.ToList();
            var teachers = _context.Teachers.ToList();
            var rooms = _context.Rooms.ToList();
            var scheduleFormViewModel = new ScheduleFormViewModel()
            {
                Departments = departments,
                Courses = courses,
                Teachers = teachers,
                Rooms = rooms
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
            var rooms = _context.Rooms.ToList();
            var scheduleFormViewModel = new ScheduleFormViewModel(schedule)
            {
                Departments = departments,
                Courses = courses,
                Teachers = teachers,
                Rooms = rooms
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
                var rooms = _context.Rooms.ToList();
                var scheduleFormViewModel = new ScheduleFormViewModel(schedule)
                {
                    Departments = departments,
                    Courses = courses,
                    Teachers = teachers,
                    Rooms = rooms
                };

                return View("ScheduleForm", scheduleFormViewModel);
            }

            if (schedule.ID == 0)
            {
                _context.Schedules.Add(schedule);
            }
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