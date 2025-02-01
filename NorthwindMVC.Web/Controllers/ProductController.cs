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
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
		private readonly IValidator<ProductViewModel> _validator;
		private readonly IToastr _toastr;
		private readonly IMapper _mapper;
        private readonly IDropdownService _dropdownService;
        private readonly IStringLocalizer<Resources.Resources> _translate;

        public ProductController(IProductService productService,
                                 IValidator<ProductViewModel> validator,
                                 IToastr toastr,
                                 IMapper mapper,
                                 IDropdownService dropdownService,
                                 IStringLocalizer<Resources.Resources> translate)
        {
            _productService = productService;
            _validator = validator;
            _toastr = toastr;
            _mapper = mapper;
            _dropdownService = dropdownService;
            _translate = translate;
        }
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, string searchTerm = "", int? categoryId = null)
        {
            var products = await _productService.GetPagedProducts(pageNumber, pageSize, searchTerm, categoryId);
            var categoriesDropDown = (await _dropdownService.GetCategoriesDropdownList(null)).Take(5);
            var productsVM = new ProductViewModel
            {
                Products = products,
                CategoriesDropdown = categoriesDropDown,
                SelectedCategoryId = categoryId
            };
			return View(productsVM);
        }

        public async Task<IActionResult> Search(int pageNumber=1, int pageSize= 10, string searchTerm = "", int? categoryId = null)
        {
            return RedirectToAction("Index", new {pageNumber, pageSize, searchTerm, categoryId});
        }
        public async Task<IActionResult> AddView()
        {
            var categoriesDropdown = (await _dropdownService.GetCategoriesDropdownList(null)).Take(5);
            var suppliersDropdown = (await _dropdownService.GetSuppliersDropdownList(null)).Take(5);
            var productVM = new ProductViewModel
            {
                CategoriesDropdown = categoriesDropdown,
                SuppliersDropdown = suppliersDropdown,
            };
            return PartialView("_add", productVM);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel productViewModel)
        {
            ModelState.Clear();
            ValidationResult result = await _validator.ValidateAsync(productViewModel);
            if(!result.IsValid)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                _toastr.Danger(_translate["AddFailed"]);
                return PartialView("_add", productViewModel);  
            }

            var product = _mapper.Map<Product>(productViewModel);
            await _productService.Add(product);
            _toastr.Success(_translate["AddSuccessful"]);

			return Json(new { success = true, redirectUrl = Url.Action("Index", "Product") });
		}

		public async Task<IActionResult> EditView(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var productVM = _mapper.Map<ProductViewModel>(product);
            var categoriesDropdown = (await _dropdownService.GetCategoriesDropdownList(null)).Take(5);
            var suppliersDropdown = (await _dropdownService.GetSuppliersDropdownList(null)).Take(5);
            productVM.CategoriesDropdown = categoriesDropdown;
            productVM.SuppliersDropdown = suppliersDropdown;

            return PartialView("_edit", productVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel productVM)
        {
            ModelState.Clear();
            ValidationResult result = await _validator.ValidateAsync(productVM);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                _toastr.Danger(_translate["EditFailed"]);
                return PartialView("_add", productVM);
            }

            var product = _mapper.Map<Product>(productVM);
            await _productService.Update(product);
            _toastr.Success(_translate["EditSuccessful"]);

			return Json(new { success = true, redirectUrl = Url.Action("Index", "Product") });
		}

		public async Task<IActionResult> DeleteView(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return PartialView("_delete", product);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var productDelete = await _productService.GetByIdAsync(id);
            try
            {
                await _productService.Delete(productDelete);

                _toastr.Success(_translate["DeleteSuccessful"]); //lokalizacija
				return Json(new { success = true, redirectUrl = Url.Action("Index", "Product") });
			}
			catch (Exception ex)
            {
                return View("Error", ex);
            }            
        }
        [HttpGet]
        public async Task<IActionResult> GetCategoryDropdown(string? searchTerm)
        {
            var categories = await _dropdownService.GetCategoriesDropdownList(searchTerm);
            var results = categories.Select(categories => new { id = categories.Value, text = categories.Text });
            return Json(new { results });
        }
        [HttpGet]
        public async Task<IActionResult> GetSupplierDropdown(string? searchTerm)
        {
            var suppliers = await _dropdownService.GetSuppliersDropdownList(searchTerm);
            var results = suppliers.Select(suppliers => new { id = suppliers.Value, text = suppliers.Text });
            return Json(new { results });
        }


    }
}
