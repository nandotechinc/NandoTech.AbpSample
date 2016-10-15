using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using Microsoft.Extensions.Configuration;
using NandoTech.AbpSample.Authorization.Roles;
using NandoTech.AbpSample.Configuration;
using NandoTech.AbpSample.MultiTenancy;
using NandoTech.AbpSample.Users;
using NandoTech.AbpSample.Web;

namespace NandoTech.AbpSample.EntityFramework
{
    [DbConfigurationType(typeof(AbpSampleDbConfiguration))]
    public class AbpSampleDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        /* Define an IDbSet for each entity of the application */

        /* Default constructor is needed for EF command line tool. */
        public AbpSampleDbContext()
            : base(GetConnectionString())
        {

        }

        private static string GetConnectionString()
        {
            var configuration = AppConfigurations.Get(
                WebContentDirectoryFinder.CalculateContentRootFolder()
                );

            return configuration.GetConnectionString(
                AbpSampleConsts.ConnectionStringName
                );
        }

        /* This constructor is used by ABP to pass connection string.
         * Notice that, actually you will not directly create an instance of AbpSampleDbContext since ABP automatically handles it.
         */
        public AbpSampleDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        /* This constructor is used in tests to pass a fake/mock connection. */
        public AbpSampleDbContext(DbConnection dbConnection)
            : base(dbConnection, true)
        {

        }
    }

    public class AbpSampleDbConfiguration : DbConfiguration
    {
        public AbpSampleDbConfiguration()
        {
            SetProviderServices(
                "System.Data.SqlClient",
                System.Data.Entity.SqlServer.SqlProviderServices.Instance
            );
        }
    }
}
