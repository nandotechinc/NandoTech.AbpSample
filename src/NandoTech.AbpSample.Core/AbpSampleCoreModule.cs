using System.Reflection;
using Abp.Modules;
using Abp.Timing;
using Abp.Zero;
using NandoTech.AbpSample.Localization;
using Abp.Zero.Configuration;
using NandoTech.AbpSample.MultiTenancy;
using NandoTech.AbpSample.Authorization.Roles;
using NandoTech.AbpSample.Users;
using NandoTech.AbpSample.Timing;

namespace NandoTech.AbpSample
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class AbpSampleCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            //Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            AbpSampleLocalizationConfigurer.Configure(Configuration.Localization);

            //Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = true;

            //Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}