using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using NandoTech.AbpSample.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace NandoTech.AbpSample.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<AbpSample.EntityFramework.AbpSampleDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AbpSample";
        }

        protected override void Seed(AbpSample.EntityFramework.AbpSampleDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
