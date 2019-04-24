using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Webapp.Context;
using Webapp.Context.Login;
using Webapp.Converters;
using Webapp.Handlers;
using Webapp.Interfaces;
using Webapp.Models.Data;
using Webapp.Parsers;
using Webapp.Repository;
using Webapp.Context.MSSQLContext;
using Webapp.Context.MemoryContext;
using Webapp.Context.InterfaceContext;

namespace Webapp
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddTransient<IParser, DataRowParser>();
            services.AddTransient<IHandler, MSSQLHandler>();

            //services.AddScoped<ITreatmentTypeContext, MSSQLTreatmentTypeContext>();
            //services.AddScoped<IDepartmentContext, MSSQLDepartmentContext>();
            //services.AddScoped<IInstitutionContext, MSSQLInstitutionContext>();
            //services.AddScoped<ICommentContext, MSSQLCommentContext>();
            //services.AddScoped<IDoctorContext, MSSQLDoctorContext>();
            //services.AddScoped<IPatientContext, MSSQLPatientContext>();
            //services.AddScoped<ITreatmentContext, MSSQLTreatmentContext>();

            services.AddSingleton<ITreatmentTypeContext, MemoryTreatmentTypeContext>();
            services.AddSingleton<IDepartmentContext, MemoryDepartmentContext>();
            services.AddSingleton<IInstitutionContext, MemoryInstitutionContext>();
            services.AddSingleton<ICommentContext, MemoryCommentContext>();
            services.AddSingleton<IDoctorContext, MemoryDoctorContext>();
            services.AddSingleton<IPatientContext, MemoryPatientContext>();
            services.AddSingleton<ITreatmentContext, MemoryTreatmentContext>();
            //Add test data into static lists
            TestData testData = new TestData();

            services.AddScoped<PatientRepository>();
            services.AddScoped<TreatmentTypeRepository>();
            services.AddScoped<DoctorRepository>();
            services.AddScoped<DepartmentRepository>();
            services.AddScoped<InstitutionRepository>();
            services.AddScoped<TreatmentRepository>();

            services.AddTransient<IUserStore<BaseAccount>, UserMemoryContext>();
            services.AddTransient<IRoleStore<Role>, RoleMemoryContext>();
            services.AddIdentity<BaseAccount, Role>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                // TODO: access denied pagina maken
                options.AccessDeniedPath = new PathString("/");
                options.Cookie.Name = "Cookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(720);
                options.LoginPath = new PathString("/");
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
        //    app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
