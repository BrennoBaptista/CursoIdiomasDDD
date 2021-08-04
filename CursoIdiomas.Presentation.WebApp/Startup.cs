using CursoIdiomas.Application.Services;
using CursoIdiomas.Domain.Interfaces.Repositories;
using CursoIdiomas.Domain.Interfaces.Services;
using CursoIdiomas.Domain.Services;
using CursoIdiomas.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CursoIdiomas.Application.Interfaces.Services;
using Autofac;
using CursoIdiomas.Infrastructure.CrossCutting.IoC;
using Microsoft.AspNetCore.Mvc;

namespace CursoIdiomas.Presentation.WebApp
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
            services.AddTransient(typeof(IBaseAppService<,>), typeof(BaseAppService<,>));
            services.AddTransient(typeof(IBaseService<,>), typeof(BaseService<,>));
            services.AddTransient(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddControllersWithViews();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ModuleIoC());
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