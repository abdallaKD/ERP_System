using ERP.Domain.Models;
using ERP.Repositories;
//using ERP.Repositories.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace ERP.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ERPDBContext>(optionsBuilder => {
                optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
                //options=>options.Password.RequireDigit= true
            ).
            AddEntityFrameworkStores<ERPDBContext>()
            .AddDefaultTokenProviders();    //password recovery or account activation


            ////// DI for Repositories and Services
            //builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


            //builder.Services.AddScoped<IInventoryService, InventoryService>();
            //builder.Services.AddScoped<ISalesService, SalesService>();
            //builder.Services.AddScoped<IPurchaseService, PurchaseService>();



            var app = builder.Build();
            app.UseStaticFiles();
   
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
