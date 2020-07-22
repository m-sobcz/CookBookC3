using CookBookASP.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CookBookBLL.Logic;
using CookBookBLL.DataAccess;
using AutoMapper;
using CookBookBLL.Models;
using CookBookASP.Session;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace CookBookASP
{
    public class Startup
    {
        IMapper mapper;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Automapper
            MapperConfiguration mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<IngredientUIO, IngredientDTO>();
                config.CreateMap<CategoryUIO, CategoryDTO>();
                config.CreateMap<CuisineUIO, CuisineDTO>();
                config.CreateMap<RecipeUIO, RecipeDTO>();
                config.CreateMap<StepUIO, StepDTO>();
            });
            mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton<IMapper>(mapper);
            //Identity
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CookBookIdentity")));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();
            //MVC and Microsoft
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddMemoryCache();
            services.AddSession();
            //Custom
            services.AddSingleton<SqlDataAccess>();
            services.AddSingleton<IngredientProcessor>();
            services.AddSingleton<CategoryProcessor>();
            services.AddSingleton<RecipeProcessor>();
            services.AddSingleton<CuisineProcessor>();
            services.AddTransient<SessionManager<Purchase>>();
            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            services.AddMvcCore()
    .AddApiExplorer();

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();


            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "IngredientPagination",
                //    pattern: "Skladniki/{id:int?}",
                //    defaults: new { Controller = "Ingredients", action = "Index" }
                //    );
                //endpoints.MapControllerRoute(
                //    name: "Ingredient",
                //    pattern: "Skladniki/{action}/{id?}",
                //    defaults: new { Controller = "Ingredients"}
                //    );
                endpoints.MapControllerRoute(
                    name: "Category",
                    pattern: "Skladniki/{category}/{id?}",
                    defaults: new { Controller = "Ingredient", action = "Index" }
                    );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
