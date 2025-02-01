using FluentValidation;
using FluentValidation.Results;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using NorthwindMVC.Core.Models;
using NorthwindMVC.Services.Services;
using NorthwindMVC.Web.Helpers.ToastNotifications;
using NorthwindMVC.Web.ViewModels;

namespace NorthwindMVC.Web.Controllers
{
    public class SupplierController : Controller
    {
		private readonly IStringLocalizer<Resources.Resources> _localizer;
		private readonly ISupplierService _supplierService;
		private readonly IMapper _mapper;
		private readonly IValidator<SupplierViewModel> _validator;
		private readonly IToastr _toastr;
        private readonly IStringLocalizer<Resources.Resources> _translate;

        public SupplierController(IStringLocalizer<Resources.Resources> localizer,
                                  ISupplierService supplierService,
                                  IMapper mapper,
                                  IValidator<SupplierViewModel> validator,
                                  IToastr toastr,
                                  IStringLocalizer<Resources.Resources> translate)
        {
            _localizer = localizer;
            _supplierService = supplierService;
            _mapper = mapper;
            _validator = validator;
            _toastr = toastr;
            _translate = translate;
        }
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, string searchTerm = "")
        {
            var suppliers = await _supplierService.GetPagedSuppliers(pageNumber, pageSize, searchTerm);
            return View(suppliers);
        }
        public async Task<IActionResult> AddView()
        {
            return PartialView("_add");
        }
        [HttpPost]
        public async Task<IActionResult> Add(SupplierViewModel supplierVM)
        {
            ModelState.Clear();
            ValidationResult result = await _validator.ValidateAsync(supplierVM);
            if (!result.IsValid)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return PartialView("_add", supplierVM);
            }

            var supplier = _mapper.Map<Supplier>(supplierVM);
            await _supplierService.Add(supplier);

            _toastr.Success(_translate["AddSuccessful"]);
			return Json(new { success = true, redirectUrl = Url.Action("Index", "Supplier") });
		}

		public async Task<IActionResult> EditView(int id)
        {
            var supplier = await _supplierService.GetByIdAsync(id);
            var supplierVM = _mapper.Map<SupplierViewModel>(supplier);

            return PartialView("_edit", supplierVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SupplierViewModel supplierVM)
        {
            ModelState.Clear();
            ValidationResult result = await _validator.ValidateAsync(supplierVM);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return PartialView("_edit", supplierVM);
            }

            var supplier = _mapper.Map<Supplier>(supplierVM);
            await _supplierService.Update(supplier);

            _toastr.Success(_translate["EditSuccessful"]);
			return Json(new { success = true, redirectUrl = Url.Action("Index", "Supplier") });
		}

		public async Task<IActionResult> DeleteView(int id)
        {
            var supplier = await _supplierService.GetByIdAsync(id);
            return PartialView("_delete", supplier);
        }

        public async Task<IActionResult> Delete(Supplier supplier)
        {
            var supplierDelete = await _supplierService.GetByIdAsync(supplier.Id);

            try
            {
                await _supplierService.Delete(supplierDelete);

                _toastr.Success(_translate["DeleteSuccessful"]);
                return Json(new { success = true, redirectUrl = Url.Action("Index", "Supplier") });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", ex);
            }
           
        }

        public async Task<IActionResult> Search(int pageNumber = 1, int pageSize = 5, string searchTerm = "")
        {
            return RedirectToAction("Index", new { pageNumber, pageSize, searchTerm });
        }
    }
}
