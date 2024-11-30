using Microsoft.AspNetCore.Mvc;

namespace NorthwindMVC.Web.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddEmployee()
        {
            return View();
        }
        public IActionResult EditEmployee()
        {
            return View();
        }
        public IActionResult DeleteEmployee()
        {
            return View();
        }
    }
}
