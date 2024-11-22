using Anden_SemesterProjekt.Server.Context;
using Anden_SemesterProjekt.Server.Repositories;
using Anden_SemesterProjekt.Server.Services;
using Anden_SemesterProjekt.Shared.Models;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

namespace Anden_SemesterProjekt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddSingleton<IAnsatRepository, AnsatRepository>();
            builder.Services.AddScoped<IAnsatService, AnsatService>();

            builder.Services.AddScoped<IMærkeRepository, MærkeRepository>();
            builder.Services.AddScoped<IMærkeService, MærkeService>();

            builder.Services.AddScoped<IScooterRepository,ScooterRepository>();
            builder.Services.AddScoped<IScooterService, ScooterService>();

            //builder.Services.AddSingleton<IUdlejningRepository, UdlejningRepository>();
            //builder.Services.AddScoped<IUdlejningService, UdlejningService>();

            //builder.Services.AddSingleton<IOrdreRepository, OrdreRepository>();
            //builder.Services.AddScoped<IOrdreService, OrdreService>();

            builder.Services.AddSingleton<IKundeRepository, KundeRepository>();
            builder.Services.AddScoped<IKundeService, KundeService>();
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");
            app.Run();
            
        }
      
    }
}
