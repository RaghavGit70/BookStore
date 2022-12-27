using ConsoleApp1.Data;
using ConsoleApp1.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

internal class Startup
{
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
        options => options.UseSqlServer("Server=.;Database=BookStore;Integrated Security=True;TrustServerCertificate=Yes;"));

        services.AddControllersWithViews();
        //services.AddMvc();
        //services.AddRazorPages();
        // IServiceCollection.AddControllers;
        services.AddScoped<BookRepository, BookRepository>();
        services.AddScoped<LanguageRepository, LanguageRepository>();
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