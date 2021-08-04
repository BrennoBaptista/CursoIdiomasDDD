using Autofac;
using System;

namespace CursoIdiomas.Infrastructure.CrossCutting.IoC
{
    public class ModuleIoC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Carrega IoC
            ConfigurationIoC.Load(builder);
            #endregion
        }
    }
}
