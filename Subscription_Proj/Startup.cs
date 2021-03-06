using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Subscription_Proj.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Subscription_Proj.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.AspNetCore.Identity;

namespace Subscription_Proj
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
            services.AddScoped<ISubsRepository, DBSubscription>();

            services.AddDbContext<SubscriptionInfoContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<UserContext>();

            services.AddDbContext<UserContext>(options => options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;" +
                "Database=UserSubsDB;" +
                "Trusted_Connection = true;" +
                "MultipleActiveResultSets=true"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(UserContext userContext, SubscriptionInfoContext subscriptionInfoContext, IApplicationBuilder app, IWebHostEnvironment env)
        {
            //userContext.Database.EnsureDeleted();
            userContext.Database.EnsureCreated();
            //subscriptionInfoContext.Database.EnsureDeleted();
            subscriptionInfoContext.Database.EnsureCreated();

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
