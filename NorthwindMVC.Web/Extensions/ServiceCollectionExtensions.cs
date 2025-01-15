using FluentValidation;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NorthwindMVC.Core.Models;
using NorthwindMVC.Infrastructure;
using NorthwindMVC.Infrastructure.UnitOfWork;
using NorthwindMVC.Services;
using NorthwindMVC.Services.Services;
using NorthwindMVC.Web.Helpers;
using NorthwindMVC.Web.Helpers.ToastNotifications;
using NorthwindMVC.Web.Validator;
using NorthwindMVC.Web.ViewModels;

namespace NorthwindMVC.Web
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<IValidator<UserViewModel>, UserViewModelValidator>();
            services.AddScoped<IValidator<EmployeeViewModel>, EmployeeViewModelValidator>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.RegisterMapsterConfiguration();

            services.AddScoped<IMapper, MapsterMapper.Mapper>();
            services.AddScoped<IToastr, Toastr>();
            services.AddScoped<LanguageService>();

            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IPaginationService, PaginationService>();
            services.AddScoped<IDropdownService, DropdownService>();

            services.AddDbContext<NorthwindDbContext>((sp, opts) =>
            {
                opts.UseNpgsql(sp.GetRequiredService<IConfiguration>().GetConnectionString("NorthwindConnection"));
            });

            services.AddDistributedMemoryCache(); // for sessions

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            }); //for sessions


            return services;
        }
    }
}