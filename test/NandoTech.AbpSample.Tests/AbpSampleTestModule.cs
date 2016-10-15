using System;
using Abp.Modules;
using Abp.MultiTenancy;
using Abp.TestBase;
using Abp.Zero.Configuration;
using NandoTech.AbpSample.EntityFramework;
using Castle.MicroKernel.Registration;
using NSubstitute;

namespace NandoTech.AbpSample.Tests
{
    [DependsOn(
        typeof(AbpSampleApplicationModule),
        typeof(AbpSampleEntityFrameworkModule),
        typeof(AbpTestBaseModule)
        )]
    public class AbpSampleTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.Timeout = TimeSpan.FromMinutes(30);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;

            //Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            RegisterFakeService<IAbpZeroDbMigrator>();
        }

        private void RegisterFakeService<TService>() where TService : class
        {
            IocManager.IocContainer.Register(
                Component.For<TService>()
                    .UsingFactoryMethod(() => Substitute.For<TService>())
                    .LifestyleSingleton()
            );
        }
    }
}