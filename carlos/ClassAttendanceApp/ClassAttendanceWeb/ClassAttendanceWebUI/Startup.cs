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
        }

        private void SetGitHubAuthentication(GitHubAuthenticationOptions options)
        {
            options.ClientId = "26060c9aef1a28c58919";
            options.ClientSecret = "6d8b44ae95253b4d00d1f66e082175a3b53c3480";
            options.CallbackPath = new PathString("/github/auth");
        }

        private void SetAppOAuthAuthentication(OAuthOptions options)
        {
            // Client Id : 26060c9aef1a28c58919
            // Client Secret : 6d8b44ae95253b4d00d1f66e082175a3b53c3480

            options.ClientId = "26060c9aef1a28c58919";
            options.ClientSecret = "6d8b44ae95253b4d00d1f66e082175a3b53c3480";
            options.CallbackPath = new PathString("/github/auth");
            options.AuthorizationEndpoint = "https://github.com/login/oauth/authorize";
            options.TokenEndpoint = "https://github.com/login/oauth/access_token";
            options.UserInformationEndpoint = "https://api.github.com/user";
            options.SaveTokens = true;
            options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
            options.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
            options.ClaimActions.MapJsonKey("urn:github:login", "login");
            options.ClaimActions.MapJsonKey("urn:github:url", "html_url");
            options.ClaimActions.MapJsonKey("urn:github:avatar", "avatar_url");
            options.Events = new OAuthEvents
            {
                /*
                OnCreatingTicket = async context =>
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);
                    var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
                    response.EnsureSuccessStatusCode();
                    var json = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
                    context.RunClaimActions(json.RootElement);
                }
                */
            };
        }


        private void SetAppAuthentication(AuthenticationOptions options)
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        }

        private void SetAppCookieAuthentication(CookieAuthenticationOptions options)
        {
            options.LoginPath = "/Home/Login";
            options.LogoutPath = "/Home/Logout";
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
