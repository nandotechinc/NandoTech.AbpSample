using System.Data.Entity;
using System.Reflection;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;
using NandoTech.AbpSample.Configuration;
using NandoTech.AbpSample.EntityFramework;

namespace NandoTech.AbpSample.Migrator
{
    [DependsOn(typeof(AbpSampleEntityFrameworkModule))]
    public class AbpSampleMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public AbpSampleMigratorModule()
        {
            _appConfiguration = AppConfigurations.Get(
                typeof(AbpSampleMigratorModule).Assembly.GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Database.SetInitializer<AbpSampleDbContext>(null);

            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                AbpSampleConsts.ConnectionStringName
                );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(typeof(IEventBus), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}