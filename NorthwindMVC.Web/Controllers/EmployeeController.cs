using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using NorthwindMVC.Core.Models;
using NorthwindMVC.Services.Services;
using NorthwindMVC.Web.ViewModels;

namespace NorthwindMVC.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IPhotoService _photoService;
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IPhotoService photoService,
                                  IEmployeeService employeeService,
                                  IMapper mapper)
        {
            _photoService = photoService;
            _employeeService = employeeService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 5)
        {
            var employees = await _employeeService.GetPagedEmployee(pageNumber, pageSize);
            return View("Index", employees);
        }

        public IActionResult AddEmployee()
        {
            return View("AddEmployee");
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(IFormFile photoUpload, EmployeeViewModel employeeVM)
        {
            var employee = _mapper.Map<Employee>(employeeVM);

            await _photoService.AddPhotoAsync(photoUpload, employee, "uploads/employee");

            await _employeeService.Add(employee);

            return RedirectToAction("Index");
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
