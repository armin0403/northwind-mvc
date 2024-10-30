using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NorthwindMVC.Web
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthenticationFilter : Attribute, IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Session.GetString("UserData");
            if (user == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"controller", "User"},
                        {"action", "Login"}
                    });
            }
            await Task.CompletedTask;
        }
    }
}