using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using WebkinzManagement.Services;
using WebkinzManagement.Models;
using Microsoft.AspNetCore.Identity;

namespace WebkinzManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //services.AddSingleton<IProductRepository, ProductRepository>(); // in memory
            services.AddScoped<IProductRepository, DBProductRepository>(); // database
            // This step connects app to the database
            services.AddDbContext<ProductContext>(options => options.UseSqlServer("Server = desktop-11ev2hh\\sqlserver2019; " +
                "Database = WebkinzManagement; Trusted_Connection = true; MultipleActiveResultSets = true"));
            services.AddIdentity<User, IdentityRole>(options =>
            {
                // determine password strength
                options.Password.RequiredLength = 3;
            }).AddEntityFrameworkStores<UserContext>();
            services.AddDbContext<UserContext>(options => options.UseSqlServer("Server = desktop-11ev2hh\\sqlserver2019; " +
                "Database = WebkinzUsers; Trusted_Connection = true; MultipleActiveResultSets = true"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(UserContext userContext, ProductContext productContext, IApplicationBuilder app, IWebHostEnvironment env)
        {
            // check if the DB is there, if not it will create it
            userContext.Database.EnsureCreated();
            productContext.Database.EnsureCreated();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
