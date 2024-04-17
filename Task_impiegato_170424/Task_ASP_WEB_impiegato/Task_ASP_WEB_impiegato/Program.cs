using Microsoft.EntityFrameworkCore;
using Task_ASP_WEB_impiegato.Models;
using Task_ASP_WEB_impiegato.Repositories;
using Task_ASP_WEB_impiegato.Services;

namespace Task_ASP_WEB_impiegato
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // 

            builder.Services.AddDbContext<TaskImpiegatoContext>(
                options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("Locale")
                    )
                );
            builder.Services.AddScoped<CittumRepository>();
            builder.Services.AddScoped<CittumService>();

            //


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
                pattern: "{controller=Cittum}/{action=Lista}/{id?}");

            app.Run();
        }
    }
}
