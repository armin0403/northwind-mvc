using FluentValidation;
using FluentValidation.Results;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using NorthwindMVC.Core.Models;
using NorthwindMVC.Services.Services;
using NorthwindMVC.Web.Helpers;
using NorthwindMVC.Web.Helpers.ToastNotifications;
using NorthwindMVC.Web.ViewModels;

namespace NorthwindMVC.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IPhotoService _photoService;
        private readonly IEmployeeService _employeeService;
        private readonly IDropdownService _dropdownService;
        private readonly IMapper _mapper;
        private readonly IToastr _toastr;
        private readonly IStringLocalizer<Resources.Resources> _translate;
        private readonly IValidator<EmployeeViewModel> _validator;

        public EmployeeController(IPhotoService photoService,
                                  IEmployeeService employeeService,
                                  IDropdownService dropdownService,
                                  IValidator<EmployeeViewModel> validator,
                                  IMapper mapper,
                                  IToastr toastr,
                                  IStringLocalizer<Resources.Resources> localizer)
        {
            _photoService = photoService;
            _employeeService = employeeService;
            _dropdownService = dropdownService;
            _mapper = mapper;
            _toastr = toastr;
            _translate = localizer;
            _validator = validator;
        }
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 5, string searchTerm = "")
        {
            var employees = await _employeeService.GetPagedEmployee(pageNumber, pageSize, searchTerm);
            return View("Index", employees);
        }

        public async Task<IActionResult> Add()
        {
            var employeeDropdown = (await _dropdownService.GetEmployeesDropdownList(null)).Take(5);
            var viewModel = new EmployeeViewModel
            {
                EmployeeDropdown = employeeDropdown
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeDropdown(string? searchTerm)
        {
            var employees = await _dropdownService.GetEmployeesDropdownList(searchTerm);
            var results = employees.Select(employees => new { id = employees.Value, text = employees.Text });
            return Json(new { results });
        }

        [HttpPost]
        public async Task<IActionResult> Add(IFormFile photoUpload, EmployeeViewModel employeeVM)
        {
            ModelState.Clear();
            ValidationResult result = await _validator.ValidateAsync(employeeVM);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                var employeeDropdown = (await _dropdownService.GetEmployeesDropdownList(null)).Take(5);
                employeeVM.EmployeeDropdown = employeeDropdown;

                return View(employeeVM);
            }

            try
            {
                var employee = _mapper.Map<Employee>(employeeVM);
                await _photoService.AddPhotoAsync(photoUpload, employee, "employee");
                await _employeeService.Add(employee);
                _toastr.Success(_translate["AddEmploySuc"]);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _toastr.Warning(_translate["AddEmployFail"]);
                return View(employeeVM);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeService.GetById(id);

            var employeeVM = _mapper.Map<EmployeeViewModel>(employee);
            var employeeDropdown = (await _dropdownService.GetEmployeesDropdownList(null)).Take(5);
            employeeVM.EmployeeDropdown = employeeDropdown;
            return View(employeeVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, IFormFile photoUpload, EmployeeViewModel employeeVM)
        {
            var employeeEdit = await _employeeService.GetById(id);
            if (photoUpload != null && photoUpload.Length > 0)
            {
                await _photoService.DeletePhotoAsync(employeeEdit.PhotoPath);
                var newPhoto = await _photoService.AddPhotoAsync(photoUpload, employeeVM, "employee");
                employeeVM.PhotoPath = newPhoto;
            }
            else
            {
                employeeVM.PhotoPath = employeeEdit.PhotoPath;
            }

            _mapper.Map(employeeVM, employeeEdit);

            if (!string.IsNullOrEmpty(employeeVM.PhotoPath))
            {
                employeeEdit.PhotoPath = employeeVM.PhotoPath;
            }

            await _employeeService.Update(employeeEdit);
            _toastr.Success(_translate["EditSuccessful"]);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeService.GetById(id);
            if (employee == null) return View("Error");

            try
            {
                var isDeleted = await _employeeService.DeleteEmployeeAsync(employee);
                if (isDeleted)
                {
                    _toastr.Success(_translate["EmployeeDeleteSuc"]);
                }
                else
                {
                    _toastr.Danger(_translate["EmployeeUnsuc"]);
                }
            }
            catch
            {
                _toastr.Danger(_translate["ErrorHappened"]);
            }

            return RedirectToAction("Index");
        }
            public async Task<IActionResult> Search(int pageNumber = 1, int pageSize = 5,  string searchTerm = "")
        {
            return RedirectToAction("Index", new {pageNumber, pageSize, searchTerm});
        }
    }
}
