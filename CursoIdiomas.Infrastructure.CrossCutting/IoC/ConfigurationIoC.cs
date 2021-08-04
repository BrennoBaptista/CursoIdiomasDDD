using Autofac;
using AutoMapper;
using CursoIdiomas.Application.Interfaces.Services;
using CursoIdiomas.Application.Services;
using CursoIdiomas.Domain.Interfaces.Repositories;
using CursoIdiomas.Domain.Interfaces.Services;
using CursoIdiomas.Domain.Services;
using CursoIdiomas.Infrastructure.Data.Repositories;
using CursoIdiomas.Presentation.WebApp.AutoMapper;

namespace CursoIdiomas.Infrastructure.CrossCutting.IoC
{
    public class ConfigurationIoC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IoC Application
            builder.RegisterType<TurmaAppService>().As<ITurmaAppService>();
            builder.RegisterType<AlunoAppService>().As<IAlunoAppService>();
            #endregion

            #region IoC Services
            builder.RegisterType<TurmaService>().As<ITurmaService>();
            builder.RegisterType<AlunoService>().As<IAlunoService>();
            #endregion

            #region IoC Repositories
            builder.RegisterType<TurmaRepository>().As<ITurmaRepository>();
            builder.RegisterType<AlunoRepository>().As<IAlunoRepository>();
            #endregion

            #region IoC AutoMapper
            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AlunoProfile>();
                cfg.AddProfile<TurmaProfile>();
            }));
            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
            #endregion
        }
    }
}
