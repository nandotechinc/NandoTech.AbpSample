using System.Reflection;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using NandoTech.AbpSample.Configuration;
using NandoTech.AbpSample.EntityFramework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Zero.Configuration;

namespace NandoTech.AbpSample.Web.Startup
{
    [DependsOn(
        typeof(AbpSampleApplicationModule), 
        typeof(AbpSampleEntityFrameworkModule), 
        typeof(AbpAspNetCoreModule))]
    public class AbpSampleWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public AbpSampleWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(AbpSampleConsts.ConnectionStringName);

            //Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            Configuration.Navigation.Providers.Add<AbpSampleNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(AbpSampleApplicationModule).Assembly
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}