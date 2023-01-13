using BookWebApp.Data;
using BookWebApp.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using BookWebApp.Models;
using BookWebApp.Helpers;
using BookWebApp.Service;
using Microsoft.AspNetCore.Identity;

internal class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// defining services used in application
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<BookStoreContext>(
        options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

        services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<BookStoreContext>();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequiredLength = 5;
            options.Password.RequiredUniqueChars = 1;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
        });

        services.ConfigureApplicationCookie(config =>
        {
            config.LoginPath = _configuration["Application:LoginPath"];
        });

        services.AddControllersWithViews();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<ILanguageRepository, LanguageRepository>();
        services.AddSingleton<IMessageRepository, MessageRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPrincipalFactory>();

        
    }

    /// <summary>
    /// middelwares used in application
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
        });
    }

}