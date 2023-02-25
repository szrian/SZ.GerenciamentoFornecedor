using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SZ.GF.Site.Data;

namespace SZ.GF.Site.Configurations
{
	public static class IdentityConfig
	{
		public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, ConfigurationManager configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
			services.AddDatabaseDeveloperPageExceptionFilter();

			services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddEntityFrameworkStores<ApplicationDbContext>();

			return services;
		}
	}
}
