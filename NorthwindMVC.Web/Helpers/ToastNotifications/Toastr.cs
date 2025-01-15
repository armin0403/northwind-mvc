using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace NorthwindMVC.Web.Helpers.ToastNotifications
{
    public class Toastr : IToastr
    {
        public enum ToastMessageType
        {
            Success,
            Error,
            Warning
        }

        public const string Key = "_temp_data_toast_message";
        private const string ToastTemplate = "toastr.{0}('{1}');";

        private readonly ITempDataDictionary _tempData;

        public Toastr(IHttpContextAccessor httpContextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory)
        {
            _tempData = tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
        }
        public void Danger(string message)
        {
            Message(ToastMessageType.Error, message);
        }
              
        public void Success(string message)
        {
            Message(ToastMessageType.Success, message);
        }

        public void Warning(string message)
        {
            Message(ToastMessageType.Warning, message);
        }

        private void Message(ToastMessageType type, string message)
        {
            if(_tempData.ContainsKey(Key))
               _tempData.Remove(Key);

            _tempData.Add(Key, string.Format(ToastTemplate, type.ToString().ToLower(), message));
        }
        public IHtmlContent Display()
        {
            if (!_tempData.TryGetValue(Key, out var text))
                return HtmlString.Empty;

            var htmlString = new HtmlString($"<script>{text}</script>");
            if (htmlString.Value == null)
                return HtmlString.Empty;

            _tempData.Remove(Key);

            return htmlString;
        }

    }
}
