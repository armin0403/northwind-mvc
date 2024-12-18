using Microsoft.AspNetCore.Html;

namespace NorthwindMVC.Web.Helpers.ToastNotifications
{
    public interface IToastr
    {
        void Success(string  message);
        void Danger (string message);
        void Warning (string message);
        IHtmlContent Display();
    }
}
