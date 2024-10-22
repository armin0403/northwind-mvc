using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NorthwindMVC.Web.AuthConfig
{
    public class CustomAuthenticationFilter : Attribute, IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync (AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Session.GetString ("UserData");
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
