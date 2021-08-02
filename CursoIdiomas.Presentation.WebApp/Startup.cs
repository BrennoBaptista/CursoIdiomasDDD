using AutoMapper;
using CursoIdiomas.Application;
using CursoIdiomas.Application.Interfaces;
using CursoIdiomas.Domain.Interfaces.Repositories;
using CursoIdiomas.Domain.Interfaces.Services;
using CursoIdiomas.Domain.Services;
using CursoIdiomas.Infrastructure.Data.Repositories;
using CursoIdiomas.Presentation.WebApp.AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            var config = new MapperConfiguration(cfg => 
            {
                cfg.AddProfile<AlunoProfile>();
                cfg.AddProfile<TurmaProfile>();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient(typeof(IBaseAppService<,>), typeof(BaseAppService<,>));
            services.AddTransient<ITurmaAppService, TurmaAppService>();
            services.AddTransient<IAlunoAppService, AlunoAppService>();

            services.AddTransient(typeof(IBaseService<,>), typeof(BaseService<,>));
            services.AddTransient<ITurmaService, TurmaService>();
            services.AddTransient<IAlunoService, AlunoService>();

            services.AddTransient(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            services.AddTransient<ITurmaRepository, TurmaRepository>();
            services.AddTransient<IAlunoRepository, AlunoRepository>();

            services.AddControllersWithViews();
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