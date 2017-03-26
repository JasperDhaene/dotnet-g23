using System;
using System.Security.Claims;
using dotnet_g23.Data;
using dotnet_g23.Data.Repositories;
using dotnet_g23.Filters;
using dotnet_g23.Models.Domain;
using dotnet_g23.Models.Domain.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace dotnet_g23
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
                builder.AddApplicationInsightsSettings(true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddSession();
            services.AddMvc();

            // Database setup
            services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddScoped<DataInitializer>();

            // Identity framework
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 5;

                // Cookie settings
                options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(150);
                options.Cookies.ApplicationCookie.LoginPath = "/Account/LogIn";
                options.Cookies.ApplicationCookie.LogoutPath = "/Account/LogOff";
            });

            /**
             * Filters
             * 
             * */
            services.AddScoped<UserFilter>();
            services.AddScoped<ParticipantFilter>();

            /**
             * Repositories
             * 
             * */
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IParticipantRepository, ParticipantRepository>();
            services.AddScoped<IInvitationRepository, InvitationRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ILabelRepository, LabelRepository>();
            services.AddScoped<IPostRepository, PostRepository>();

            /**
             * Authorization
             * 
             * */
            services.AddAuthorization(options =>
            {
                options.AddPolicy("volunteer", policy => policy.RequireClaim(ClaimTypes.Role, "volunteer"));
                options.AddPolicy("participant", policy => policy.RequireClaim(ClaimTypes.Role, "participant"));
                options.AddPolicy("lector", policy => policy.RequireClaim(ClaimTypes.Role, "lector"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            DataInitializer initializer)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();


            app.UseApplicationInsightsRequestTelemetry();
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
            app.UseBrowserLink();

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();
            app.UseStatusCodePagesWithRedirects("/error");
            app.UseIdentity();

            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });

            initializer.InitializeData().Wait();
        }
    }
}