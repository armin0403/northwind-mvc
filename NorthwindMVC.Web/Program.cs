using System.Globalization;
using Microsoft.AspNetCore.Mvc.Razor;
using NorthwindMVC.Web;
using NorthwindMVC.Web.CustomExceptionMiddleware;

var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddHttpContextAccessor();
builder.Services.RegisterServices();
builder.Services.AddLocalization();
builder.Services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();


var app = builder.Build();

var defaultDataCulture = "bs-Latn-BA";
var ci = new CultureInfo(defaultDataCulture);

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(ci),
    SupportedCultures = new List<CultureInfo>
    {
        ci,
        new CultureInfo("en-US")
    },
    SupportedUICultures = new List<CultureInfo>
    {
        ci,
        new CultureInfo("en-US")
    }
});


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

//app.UseMiddleware<ErrorHandleMiddleware>();

app.UseRouting();

app.UseSession(); // for sessions

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();