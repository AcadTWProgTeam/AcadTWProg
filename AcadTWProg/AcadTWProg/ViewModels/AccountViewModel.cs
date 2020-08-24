using AcadTWProg.Models;
using AcadTWProg.Models.MyModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web;

namespace AcadTWProg.ViewModels
{
    public class AccountViewModel
    {
        protected static ApplicationDbContext ApplicationDbContext = new ApplicationDbContext();
        protected static UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ApplicationDbContext));

        public static string GetDepartmentName()
        {
            ApplicationUser user = UserManager.FindById(HttpContext.Current.User.Identity.GetUserId());
            Department department = ApplicationDbContext.Departments.First(d => d.ID == user.DepartmentId);
            return department.Name;
        }
    }
}