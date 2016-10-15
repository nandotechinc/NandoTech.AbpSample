using Abp.MultiTenancy;
using NandoTech.AbpSample.Users;

namespace NandoTech.AbpSample.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {
            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}