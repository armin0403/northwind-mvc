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
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 5, string searchTerm = "")
        {
            var employees = await _employeeService.GetPagedEmployee(pageNumber, pageSize, searchTerm);
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

        public async Task<IActionResult> EditEmployee(int id)
        {
            var employee = await _employeeService.GetById(id);
            var employeeVM = _mapper.Map<EmployeeViewModel>(employee);
            return View(employeeVM);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(int id, EmployeeViewModel employeeVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit employee");
                return View(employeeVM);
            }
            var editEmployee = await _employeeService.GetById(id);
            _mapper.Map(employeeVM, editEmployee);
            
            await _employeeService.Update(editEmployee);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _employeeService.GetById(id);
            if (employee == null) return View("Error");

            await _employeeService.Delete(employee);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Search(int pageNumber = 1, int pageSize = 5,  string searchTerm = "")
        {
            return RedirectToAction("Index", new {pageNumber, pageSize, searchTerm});
        }
    }
}
