using AmanaTechnology.AppService;
using AmanaTechnology.IAppService;
using AmanaTechnology.Model;
using AmanaTechnology.Reposatory;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmanaTechnology
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
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();

            services.AddDbContext<AmanaDbContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AmanaTechnology", Version = "v1" });
            });
            services.AddTransient<IReposatory<Blogs>, Reposatory<Blogs>>();
            services.AddTransient<IBlogAppService, BlogAppService>();
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AmanaCorse",
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:4200", "https://localhost:4200")
                                      .AllowAnyHeader().AllowAnyMethod();
                                  });
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AmanaTechnology v1"));
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("AmanaCorse");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
