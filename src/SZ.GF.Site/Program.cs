using Microsoft.EntityFrameworkCore;
using SZ.GF.Data.Context;
using SZ.GF.Site.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
	.SetBasePath(builder.Environment.ContentRootPath)
	.AddJsonFile("appsettings.json", true, true)
	.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
	.AddEnvironmentVariables();

builder.Services.AddIdentityConfiguration(builder.Configuration);

builder.Services.AddDbContext<MeuDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.ResolveDependencies();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddMvcConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Home/Error");
    app.UseStatusCodePagesWithRedirects("/erro/{0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseGlobalizationConfig();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
