using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;

namespace NandoTech.AbpSample.EntityFramework
{
    [DependsOn(
        typeof(AbpSampleCoreModule), 
        typeof(AbpZeroEntityFrameworkModule))]
    public class AbpSampleEntityFrameworkModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AbpSampleDbContext>());
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}