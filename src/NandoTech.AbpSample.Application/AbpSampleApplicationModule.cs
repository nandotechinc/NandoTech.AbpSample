using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using NandoTech.AbpSample.Authorization;

namespace NandoTech.AbpSample
{
    [DependsOn(
        typeof(AbpSampleCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AbpSampleApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AbpSampleAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}