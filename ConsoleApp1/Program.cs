using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using System;

// See https://aka.ms/new-console-template for more information

CreateHostBuilder(args).Build().Run();


static IHostBuilder CreateHostBuilder(string[] args) =>

    Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
    });
