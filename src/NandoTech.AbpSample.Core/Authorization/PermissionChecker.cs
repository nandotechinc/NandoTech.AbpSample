using Abp.Authorization;
using NandoTech.AbpSample.Authorization.Roles;
using NandoTech.AbpSample.MultiTenancy;
using NandoTech.AbpSample.Users;

namespace NandoTech.AbpSample.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
