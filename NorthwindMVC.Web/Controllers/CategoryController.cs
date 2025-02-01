using System.Transactions;
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
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IValidator<CategoryViewModel> _validator;
        private readonly IMapper _mapper;
        private readonly IToastr _toastr;
        private readonly IPhotoService _photoService;
        private readonly IStringLocalizer<Resources.Resources> _translate;

        public CategoryController(ICategoryService categoryService,
                                  IValidator<CategoryViewModel> validator,
                                  IMapper mapper,
                                  IToastr toastr,
                                  IPhotoService photoService,
                                  IStringLocalizer<Resources.Resources> translate)
        {
            _categoryService = categoryService;
            _validator = validator;
            _mapper = mapper;
            _toastr = toastr;
            _photoService = photoService;
            _translate = translate;
        }
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 8, string searchTerm = "")
        {
            var categories = await _categoryService.GetPagedCategories(pageNumber, pageSize, searchTerm);
            return View("Index", categories);
        }

        [HttpPost]
        public async Task<IActionResult> Add(IFormFile photo, CategoryViewModel modelVM)
        {
            ModelState.Clear();

            ValidationResult result = await _validator.ValidateAsync(modelVM);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                _toastr.Danger(_translate["AddFailed"]);
                return PartialView("_add", modelVM);
            }
            try
            {
                var model = _mapper.Map<Category>(modelVM);
                await _photoService.AddPhotoAsync(photo, model, "category");
                await _categoryService.Add(model);

                _toastr.Success(_translate["AddSuccessful"]);
                return Json(new { success = true, redirectUrl = Url.Action("Index", "Category") });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Json(new { success = false, message = "An unexpected error occurred. Please try again later." });
            }

        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetById(id);
            var categoryVM = _mapper.Map<CategoryViewModel>(category);

            return PartialView("_edit", categoryVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, IFormFile photo, CategoryViewModel modelVM)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                try
                {
                    if (photo != null && photo.Length > 0)
                    {
                        await _photoService.DeletePhotoAsync(modelVM.PhotoPath);
                        var newPhoto = await _photoService.AddPhotoAsync(photo, modelVM, "category");
                        modelVM.PhotoPath = newPhoto;
                    }

                    var model = _mapper.Map<Category>(modelVM);
                    await _categoryService.Update(model);
                    _toastr.Success(_translate["EditSuccessful"]);

                    transaction.Complete();
                    return Json(new { success = true, redirectUrl = Url.Action("Index", "Category") });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, ex });
                }
        }

        public async Task<IActionResult> DeleteView(int id)
        {
            var model = await _categoryService.GetById(id);
            return PartialView("_delete", model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, Category model)
        {
            var modelDelete = await _categoryService.GetById(id);
            try
            {
                await _photoService.DeletePhotoAsync(modelDelete.PhotoPath);
                await _categoryService.Delete(modelDelete);
                _toastr.Success("Uspješno obrisano!");
                return Json(new { success = true, redirectUrl = Url.Action("Index", "Category") });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message, });
            }
        }
        public async Task<IActionResult> Search(int pageNumber = 1, int pageSize = 8, string searchTerm ="")
        {
            return RedirectToAction("Index", new {pageNumber, pageSize, searchTerm});
        }
        
    }
}
