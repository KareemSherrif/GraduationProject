using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

using GraduationProject.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using GraduationProject.Repositry;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using GraduationProject.Services;


namespace GraduationProject
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

            #region Business Classes

            services.AddTransient<IAreaRepositry, AreaRepositry>();
            services.AddTransient<ICitiesRepositry, CitiesRepositry>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IAttributeRepositry, AttributeRepositry>();
            services.AddTransient<ICategoryRepositry, CategoryRepositry>();
            services.AddTransient<IModelRepositry, ModelsRepositry>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IUserProductRepository, UserProductRepository>();
            services.AddTransient<IUserProductImagesRepository, UserProductImagesRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductAttributesRepository, ProductAttributesRepository>();
            #endregion


            services.AddControllers().AddNewtonsoftJson(x => 
            x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
            services.AddControllersWithViews();
            services.AddIdentity<ApplicationUser, IdentityRole>(a =>
            {
                a.Password.RequireDigit = false;
                a.Password.RequireLowercase = false;
                a.Password.RequireNonAlphanumeric = false;
                a.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddCookie().AddJwtBearer(options =>
            //{
            //    options.SaveToken = true;
            //    options.TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"].ToString())),
            //        ValidateIssuer = false,
            //        ValidateAudience = false,
            //    };
            //});


            services.AddAuthentication().AddCookie().AddJwtBearer(options =>
            {
              
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"].ToString())),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });


            services.AddAutoMapper(Assembly.GetExecutingAssembly());

 

            services.AddDbContext<ApplicationDbContext>(a =>
            {
                a.UseSqlServer(Configuration.GetConnectionString("con"));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nareeden Api", Version = "v1" });

            });



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
                app.UseHsts();
            }
           
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseNodeModules();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
               name: "MyArea",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


            });
        }
    }
}
