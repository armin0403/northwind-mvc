using FluentValidation;
using FluentValidation.Results;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using NorthwindMVC.Core.Models;
using NorthwindMVC.Services.Services;
using NorthwindMVC.Web.Helpers.ToastNotifications;
using NorthwindMVC.Web.Resources;
using NorthwindMVC.Web.ViewModels;

namespace NorthwindMVC.Web.Controllers
{
    public class ShipperController : Controller
    {
        private readonly IValidator<ShipperViewModel> _validator;
        private readonly IStringLocalizer<Resources.Resources> _localizer;
        private readonly IToastr _toastr;
        private readonly IShipperService _shipperService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<Resources.Resources> _translate;

        public ShipperController(IValidator<ShipperViewModel> validator,
                                 IStringLocalizer<Resources.Resources> localizer,
                                 IToastr toastr,
                                 IShipperService shipperService,
                                 IMapper mapper,
                                 IStringLocalizer<Resources.Resources> translate) 
        {
            _validator = validator;
            _localizer = localizer;
            _toastr = toastr;
            _shipperService = shipperService;
            _mapper = mapper;
            _translate = translate;
        }
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, string searchTerm ="")
        {
            var pagedShippers = await _shipperService.GetPagedShippers(pageNumber, pageSize, searchTerm);
            return View("Index", pagedShippers);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var shipper = await _shipperService.GetShipperById(id);
            var shipperVM = _mapper.Map<ShipperViewModel>(shipper);
            return PartialView("_edit", shipperVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ShipperViewModel shipperVM)
        {
            ModelState.Clear();
            ValidationResult result = await _validator.ValidateAsync(shipperVM);
            if (!result.IsValid)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                _toastr.Danger(_translate["EditFailed"]);
                return PartialView("_edit", shipperVM);
            }
            var shipper = _mapper.Map<Shipper>(shipperVM);
            await _shipperService.Update(shipper);

            _toastr.Success(_translate["EditSuccessful"]);
            return Json(new { success = true, redirectUrl = Url.Action("Index", "Shipper") });
        }
        public async Task<IActionResult> DeleteView(int id)
        {
            var shipper = await _shipperService.GetShipperById(id);
            return PartialView("_delete", shipper);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Shipper shipper)
        {
            await _shipperService.Delete(shipper);
            _toastr.Success(_translate["DeleteSuccessful"]);
            return Json(new { success = true, redirectUrl = Url.Action("Index", "Shipper") });
        }

        public async Task<IActionResult> Add()
        {
            return PartialView("_add");
        }

        [HttpPost]
        public async Task <IActionResult> Add(ShipperViewModel model) 
        {
            ModelState.Clear();
            ValidationResult result = await _validator.ValidateAsync(model);
            if(!result.IsValid)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                _toastr.Danger(_localizer["ShipperNotAdded"]);
                return PartialView("_add", model);
            }

            var shipper = _mapper.Map<Shipper>(model);
            await _shipperService.Add(shipper);

            _toastr.Success(_localizer["ShipperAddedSuccessfully"]);
            return Json(new { success = true, redirectUrl = Url.Action("Index", "Shipper") });
        }
    }
}
