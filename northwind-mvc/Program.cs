using FluentValidation;
using NorthwindMVC;
using NorthwindMVC.Core;
using NorthwindMVC.Infrastructure.Helpers.Validator;
using NorthwindMVC.Infrastructure.Services;
using NorthwindMVC.Infrastructure.UnitOfWork;
using NorthwindMVC.Infrastucture;
using NorthwindMVC.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<NorthwindDbContext>();
builder.Services.AddScoped<IValidator<UserViewModel>, UserViewModelValidator>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();