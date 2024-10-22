using FluentValidation;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using NorthwindMVC.Infrastructure;
using NorthwindMVC.Infrastructure.UnitOfWork;
using NorthwindMVC.Services;
using NorthwindMVC.Web.Helpers;
using NorthwindMVC.Web.ViewModels;

namespace NorthwindMVC.Web
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection RegisterServices(this IServiceCollection services)
		{
			services.AddControllersWithViews();
			services.AddScoped<IValidator<UserViewModel>, UserViewModelValidator>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IMapper, Mapper>();

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
