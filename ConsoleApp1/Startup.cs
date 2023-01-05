using ConsoleApp1.Data;
using ConsoleApp1.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ConsoleApp1.Models;
using ConsoleApp1.Helpers;
using ConsoleApp1.Service;
using Microsoft.AspNetCore.Identity;

internal class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    //public IConfiguration config { get; }

    //public Startup ( IConfiguration conf)
    //{
    //    config = conf;
    //}

    //public void ConfigurationServices(IServiceCollection services)
    //{
    //    // services.AddControllersWithViews();
    //    services.AddMvc();
    //    services.AddRazorPages();
    //   // IServiceCollection.AddControllers;
    //}

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

            //options.SignIn.RequireConfirmedEmail = true;
        });

        services.ConfigureApplicationCookie(config =>
        {
            config.LoginPath = _configuration["Application:LoginPath"];
        });

        services.AddControllersWithViews();
        //services.AddMvc();
        //services.AddRazorPages();
        // IServiceCollection.AddControllers;
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<ILanguageRepository, LanguageRepository>();

        services.AddSingleton<IMessageRepository, MessageRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPrincipalFactory>();

        services.Configure<SMTPConfigModel>(_configuration.GetSection("SMTPConfig"));
        services.Configure<NewBookAlertConfig>("InternalBook", _configuration.GetSection("NewBookAlert"));
        services.Configure<NewBookAlertConfig>("ThirdPartyBook", _configuration.GetSection("ThirdPartyBook"));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        //app.Use(async (context, next) =>
        //{
        //    await context.Response.WriteAsync("Hello from 1st middleware");

        //    await next();
        //});

        //app.Run(async (context) =>
        //{
        //    await context.Response.WriteAsync("Hello from 2nd middleware");
        //});

        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        //app.UseEndpoints(endpoints =>
        //{
        //    endpoints.MapGet("/", async context =>
        //    {
        //       await context.Response.WriteAsync("Hello from new application");
        //    });
        //});

        app.UseEndpoints(endpoints =>
        {
            //endpoints.MapRazorPages();
            //endpoints.MapControllers();
            endpoints.MapDefaultControllerRoute();
            //endpoints.MapControllerRoute(
            //    name: "Default",
            //    pattern: "bookApp/{controller=Home}/{action=Index}/{id?}");
        });
    }

}