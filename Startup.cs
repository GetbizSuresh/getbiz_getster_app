using getbiz_getster_app.Repository.Get_Categories_Getster_Apps;
using getbiz_getster_app.Repository.Getster_App;
using getbiz_getster_app.Repository.Getster_App_About_Demo;
using getbiz_getster_app.Repository.Getster_App_Category_Location;
using getbiz_getster_app.Repository.Getster_App_Comments_Section;
using getbiz_getster_app.Repository.Getster_App_Communication;
using getbiz_getster_app.Repository.Getster_App_Time_Stamp_Description;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace getbiz_getster_app
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

            String mySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<Getbizdb_DbContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));

            services.AddControllers().AddNewtonsoftJson();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "getbiz_getster_app", Version = "v1" });
            });

            services.AddScoped<IGetster_App_About_DemoRespository, Getster_App_About_DemoRespository>();
            services.AddScoped<IGetsterAppCategoryLocationRespository, GetsterAppCategoryLocationRespository>();
            services.AddScoped<IGetsterAppCommentsSectionRepository, GetsterAppCommentsSectionRepository>();
            services.AddScoped<IGetsterAppTimeStampDescriptionRepository, GetsterAppTimeStampDescriptionRepository>();
            services.AddScoped<IGetsterAppRepository, GetsterAppRepository>();
            services.AddScoped<IGetsterAppCommunicationRepository, GetsterAppCommunicationRepository>();
            services.AddScoped<IGetCategoriesGetsterAppsRepository, GetCategoriesGetsterAppsRepository>();

            services.AddCors(option => option.AddPolicy("getbiz_getster_app", builder => {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            }));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "getbiz_getster_app v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true)
               .AllowCredentials());


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
