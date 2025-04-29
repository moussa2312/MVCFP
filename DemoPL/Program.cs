using Demo.BLL.Services;
using Demo.DAL.Data;
using Demo.DAL.Data.Repositries.Classes;
using Demo.DAL.Data.Repositries.Interfacies;
using Microsoft.EntityFrameworkCore;

namespace DemoPL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Services [DI]
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //builder.Services.AddScoped<AppDbContext>(); // Add the repository to the DI container and allow DI for AppDbcontext 
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IDepartmentRepositire, DepartmentRepository>(); // Add the repository to the DI container

            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>(); // Add the service to the DI container
            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //1
            app.UseHttpsRedirection(); // Redirect HTTP to HTTPS\
            //2
            app.UseStaticFiles(); // Serve static files
            //3
            app.UseRouting(); // Enable routing 
            //4
            //app.UseAuthorization(); // Enable authorization

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}