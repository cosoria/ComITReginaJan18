using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.Security.Claims;
using AspNet.Security.OAuth.GitHub;
using ClassAttendanceCommon.Interfaces;
using ClassAttendanceData.Repositories;
using ClassAttendanceDomain;
using ClassAttendanceWebUI.Services;
using Microsoft.AspNetCore.Http;

namespace ClassAttendanceWebUI
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
            services.AddAuthentication(SetAppAuthentication)
                    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, 
                               SetAppCookieAuthentication)

                    .AddGitHub(GitHubAuthenticationDefaults.AuthenticationScheme, 
                                SetGitHubAuthentication);
            
            services.AddControllersWithViews();

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<INativeAuthenticationService, NativeAuthenticationService>();
        }

        private void SetGitHubAuthentication(GitHubAuthenticationOptions options)
        {
            options.ClientId = "26060c9aef1a28c58919";
            options.ClientSecret = "6d8b44ae95253b4d00d1f66e082175a3b53c3480";
            options.CallbackPath = new PathString("/github/auth");
        }
        
        private void SetAppAuthentication(AuthenticationOptions options)
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        }

        private void SetAppCookieAuthentication(CookieAuthenticationOptions options)
        {
            options.LoginPath = "/Account/Login";
            options.LogoutPath = "/Account/Logout";
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                // app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
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
