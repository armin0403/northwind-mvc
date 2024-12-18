﻿using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NorthwindMVC.Web.Helpers.ToastNotifications;

namespace NorthwindMVC.Web.Controllers
{
    public class ToastController : Controller
    {
        private readonly ITempDataDictionary _tempData;

        public ToastController(IHttpContextAccessor httpContextAccessor, ITempDataDictionaryFactory tempData) 
        {
            _tempData = tempData.GetTempData(httpContextAccessor.HttpContext);
        }
        public IActionResult GetMessage()
        {
            if (!_tempData.TryGetValue(Toastr.Key, out var text))
                return Ok(string.Empty);

            var htmlString = new HtmlString($"{text}");
            if (htmlString.Value == null)
                return Ok(string.Empty);

            _tempData.Remove(Toastr.Key);

            return Ok(htmlString.ToString());
        }
    }
}
