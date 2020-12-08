using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http;
using ORM;
using Repository;
using WebSiteCinema.Middleware;
using WebSiteCinema.Models;
using WebSiteCinema.Services;

namespace WebSiteCinema
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
            services.AddLinqToDbContext<UsersRepository>((provider, options) =>
            {
                options
                    .UseSqlServer(Configuration.GetConnectionString("SqlServer"))
                    .UseDefaultLogging(provider);
            });
            services.AddHttpContextAccessor();
            services.AddScoped<IAuthentication, Authentication>();
            services.AddScoped<IAuthorization, Authorization>();
            services.AddDistributedMemoryCache();
            services.AddSession(options => 
                options.Cookie.Name = "AuthorizationSession");
            services.AddRazorPages();
                
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
                HttpOnly = HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.Always
            });
            app.UseSession();
            app.UseMiddleware<AuthenticationMiddleware>();
            app.UseMiddleware<AuthorizationMiddleware>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
        }
    }
}